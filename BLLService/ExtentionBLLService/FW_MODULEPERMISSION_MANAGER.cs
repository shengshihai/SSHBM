using Common;
using IBLLService;
using IDALRepository;
using MODEL;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLLService
{

    public partial class FW_MODULEPERMISSION_MANAGER : BaseBLLService<FW_MODULEPERMISSION>, IFW_MODULEPERMISSION_MANAGER
    {

        public MODEL.DataTableModel.DataTableGrid GetMenusButtonsForGrid(MODEL.DataTableModel.DataTableRequest request)
        {
            try
            {

                var predicate = PredicateBuilder.True<FW_MODULEPERMISSION>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");

                int total = 0;
                //predicate = predicate.And(p => p.isdelete != 1);

                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName).Select(mp => new VIEW_MENUSBUTTONS()
                {
                    ModulePermissionID = mp.MP_ID,
                    MenuUrl = mp.FW_PERMISSION.LINKURL,
                    MenuName = mp.FW_MODULE.MODULE_NAME,
                    MenuID = mp.FW_MODULE.MODULE_ID,
                    MenuNo = mp.FW_MODULE.MODULE_ID,
                    ButtonName = mp.FW_PERMISSION.NAME,
                    ButtonAction = mp.FW_PERMISSION.ACTIONNAME,
                    ButtonID = mp.FW_PERMISSION.PERMISSION_ID,
                    ButtonIcon = mp.FW_PERMISSION.ICON,
                    MenuController = mp.FW_PERMISSION.CONTROLLERNAME,
                    Description = mp.FW_PERMISSION.REMARK,
                    ParentID = mp.FW_PERMISSION.PERMISSION_PID
                });
                //var list = ViewModelProduct.ToListViewModel(data);
                return new MODEL.DataTableModel.DataTableGrid()
                {
                    draw = request.Draw,
                    data = data,
                    total = total
                };
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int SetMenusButtonsByMenuCD(string menu_cd)
        {
            var module = IDBSession.IFW_MODULE_REPOSITORY.Get(m => m.MODULE_ID == menu_cd);
            if (module == null)
                return 0;
            string PID = "A_" + module.MODULE_CONTROLLER + "_" + menu_cd;
            var predicate = PredicateBuilder.True<FW_PERMISSION>(); 
            var mppredicate = PredicateBuilder.True<FW_MODULEPERMISSION>();
            predicate = predicate.And(p => (p.CONTROLLERNAME == module.MODULE_CONTROLLER && (p.PERMISSION_PID == PID || (p.PERMISSION_ID == PID && p.PERMISSION_PID == ""))));
            var list = IDBSession.IFW_PERMISSION_REPOSITORY.GetListasNoTrackingBy(predicate).Select
(p => new FW_MODULEPERMISSION()
            {
                MP_ID = menu_cd + "_" + p.PERMISSION_ID,
                MODULE_ID = module.MODULE_ID,
                PERMISSION_ID = p.PERMISSION_ID,
                CREATE_BY = "",
                CREATE_DT = DateTime.Now,
                MODIFY_BY = "",
                MODIFY_DT = DateTime.Now
            });
           
            if (list.Count() > 0)
            {
                var ActionParent = ShengUI.Helper.ConfigSettings.GetActionParent(module.MODULE_CONTROLLER);
                if (ActionParent != menu_cd)
                {
                    idal.Modify(new FW_MODULEPERMISSION() { MP_ID = ActionParent + "_" + PID, MODULE_ID = menu_cd }, "MODULE_ID");
                    mppredicate = mppredicate.And(mp => mp.MP_ID != (ActionParent + "_" + PID));
                }
            }
            else if (IDBSession.IFW_MODULE_REPOSITORY.LoadListBy(m => m.MODULE_PID == module.MODULE_ID).Count() <= 1)
            {
                list = IDBSession.IFW_PERMISSION_REPOSITORY.GetListBy(p => p.CONTROLLERNAME == module.MODULE_CONTROLLER, p => p.SEQ_NO).Select(p => new FW_MODULEPERMISSION()
                               {
                                   MP_ID = menu_cd + "_" + p.PERMISSION_ID,
                                   MODULE_ID = module.MODULE_ID,
                                   PERMISSION_ID = p.PERMISSION_ID,
                                   CREATE_BY = "",
                                   CREATE_DT = DateTime.Now,
                                   MODIFY_BY = "",
                                   MODIFY_DT = DateTime.Now
                               });
            }
            mppredicate = mppredicate.And(mp => mp.MODULE_ID == menu_cd);
            idal.DelBy(mppredicate);
            foreach (var item in list)
            {
                idal.Add(item);
            }

            return IDBSession.SaveChanges();
        }


        public IEnumerable<VIEW_FW_MODULEPERMISSION> GetAllModulePermission()
        {
            try
            {
                List<VIEW_FW_MODULEPERMISSION> listDepart = new List<VIEW_FW_MODULEPERMISSION>();
                var data = idal.LoadListBy(mp => true).Select(mp => new VIEW_FW_MODULEPERMISSION()
                {
                    PERMISSION_ID = mp.FW_PERMISSION.PERMISSION_ID,
                    PERMISSION_PID = mp.FW_PERMISSION.PERMISSION_PID,
                    MODULE_NAME = mp.FW_MODULE.MODULE_NAME,
                    NAME = mp.FW_PERMISSION.NAME,
                    ICON = mp.FW_PERMISSION.ICON,
                    REMARK = mp.FW_PERMISSION.REMARK,
                    MP_ID = mp.MP_ID,
                    MODULE_ID = mp.FW_MODULE.MODULE_ID,
                    SEQ_NO = mp.FW_PERMISSION.SEQ_NO
                }).ToList();
                var ParentPermission = data.Where(con => con.PERMISSION_PID == "");
                foreach (var parent in ParentPermission)
                {
                    //实体转化 
                    VIEW_FW_MODULEPERMISSION parentItem = parent;
                    //获取子级
                    GetModulePermissionChildren(ref parentItem, data.ToList());
                    listDepart.Add(parentItem);
                }

                return ParentPermission;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #region 获取子集
        /// <summary>
        /// 获取子集
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="allList"></param>
        public void GetModulePermissionChildren(ref VIEW_FW_MODULEPERMISSION parent, List<VIEW_FW_MODULEPERMISSION> allList)
        {
            foreach (VIEW_FW_MODULEPERMISSION permission in allList)
            {
                var MPID = parent.MODULE_ID + "_" + permission.PERMISSION_ID;
                if (permission.PERMISSION_PID == parent.PERMISSION_ID && permission.MP_ID == MPID)
                {

                    //实体转化
                    VIEW_FW_MODULEPERMISSION child = permission;
                    if (parent.children == null)
                        parent.children = new List<VIEW_FW_MODULEPERMISSION>();
                    //添加到父级的Children中
                    parent.children.Add(child);
                    GetModulePermissionChildren(ref child, allList);//递归添加子树
                }
            }
        }
        #endregion
    }
}
