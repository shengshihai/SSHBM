using Common;
using IBLLService;
using MODEL;
using MODEL.ViewModel;
using ShengUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
    public partial class FW_USER_MANAGER : BaseBLLService<FW_USER>, IFW_USER_MANAGER
    {


        public FW_USER Login(string loginName, string pwd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FW_USER> GetAllUsers(MODEL.DataTableModel.DataTableRequest request, ref int Count)
        {
            throw new NotImplementedException();
        }

        public MODEL.DataTableModel.DataTableGrid GetAllUsers(MODEL.DataTableModel.DataTableRequest request)
        {
            try
            {

                var predicate = PredicateBuilder.True<FW_USER>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");

                int total = 0;
                var list = IDBSession.ISYS_USERLOGIN_REPOSITORY.LoadListBy(su => su.LOGIN_ID == OperateContext.Current.UsrId).Select(su => su.SLSORG_CD);

                predicate = predicate.And(p => list.Contains(p.TREENODE_ID)&&p.USER_ID!=OperateContext.Current.UsrId);
                //predicate = predicate.And(p => p.isdelete != 1);

                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName).Select(u => new VIEW_FW_USER()
                {
                    USER_ID = u.USER_ID,
                    USER_NAME = u.USER_NAME,
                    USER_TYPE = u.USER_TYPE,
                    PHONE = u.PHONE,
                    POSITION = u.POSITION,
                    ENG_NAME = u.ENG_NAME,
                    EMAIL = u.EMAIL,
                    LOCK_IND = u.LOCK_IND,
                    ACTIVE = u.ACTIVE,
                    CREATE_DT=u.CREATE_DT,
                    LAST_LOGON_DT = u.LAST_LOGON_DT
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

        public string GetUserAllRole(FW_USER User)
        {
            throw new NotImplementedException();
        }

        public string GetUserAllRole(int UserID)
        {
            throw new NotImplementedException();
        }

        public MODEL.DataTableModel.DataTableGrid GetUserGridMenus(MODEL.DataTableModel.DataTableRequest request, List<int> userMenuId, int parentid)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<MyButton> GetUserRoleButtons(string USER_CD,List<int>UserRoles, ButtonRequest RequestController)
        {
            List<MyButton> listButtons = new List<MyButton>();
            IEnumerable<FW_PERMISSION> Actions = new List<FW_PERMISSION>();
            //获取当前角色的按钮模块数组
            if (USER_CD == "Administrator")
                listButtons = OperateContext.Current.BLLSession.IFW_MODULEPERMISSION_MANAGER.GetListBy(p => p.FW_MODULE.MODULE_ID == RequestController.MenuNo && p.FW_PERMISSION.ISBUTTON == "Y").OrderBy(p => p.FW_PERMISSION.SEQ_NO).Select(p => new MyButton()
                {
                    BtnNo = p.FW_PERMISSION.ACTIONNAME,
                    BtnName = p.FW_PERMISSION.NAME,
                    BtnIcon = p.FW_PERMISSION.ICON,
                    BtnClick = p.FW_PERMISSION.SCRIPT
                }).ToList();
            else
            {
                var buttonids = OperateContext.Current.UsrPermissionId;
                listButtons = OperateContext.Current.BLLSession.IFW_MODULEPERMISSION_MANAGER.GetListBy(p => p.FW_MODULE.MODULE_ID == RequestController.MenuNo && buttonids.Contains(p.FW_PERMISSION.PERMISSION_ID) && p.FW_PERMISSION.ISBUTTON == "Y").OrderBy(p => p.FW_PERMISSION.SEQ_NO).Select(p => new MyButton()
                {
                    BtnNo = p.FW_PERMISSION.ACTIONNAME,
                    BtnName = p.FW_PERMISSION.NAME,
                    BtnIcon = p.FW_PERMISSION.ICON,
                    BtnClick = p.FW_PERMISSION.SCRIPT
                }).ToList();
            }



            //Actions = OperateContext.Current.BLLSession.IFW_PERMISSION_MANAGER.GetListBy(p => p.CONTROLLERNAME == RequestController.MenuNo && p.ISBUTTON == "Y").OrderBy(p => p.SEQ_NO).ToList();
            //foreach (FW_PERMISSION data in Actions)
            //{
            //    //添加到按钮数组
            //    listButtons.Add(MyButton.ToEntity(data));
            //}
            return listButtons;
        }
    }
}
