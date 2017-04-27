using Common;
using IBLLService;
using IDALRepository;
using MODEL;
using MODEL.DataTableModel;
using MODEL.ViewModel;
using ShengUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLService
{
    public partial class FW_ROLEPERMISSION_MANAGER : BaseBLLService<FW_ROLEPERMISSION>, IFW_ROLEPERMISSION_MANAGER
    {
        //ISample_RolePermissionRepository RolePermissionRepository { get; set; }
        IFW_ROLE_MANAGER RoleManager { get; set; }
        IFW_MODULEPERMISSION_MANAGER ModulePermissionManager = OperateContext.Current.BLLSession.IFW_MODULEPERMISSION_MANAGER;
        IFW_PERMISSION_MANAGER PermissionManager = OperateContext.Current.BLLSession.IFW_PERMISSION_MANAGER;


        public DataTableGrid GetPermissionForGridTree(DataTableRequest request)
        {
            throw new NotImplementedException();
        }

        public object GetAllRolePermission(string rolecd)
        {
            var data = base.LoadListBy(rp => rp.RP_ID == rolecd);
            return data.Select(rp => new { RoleID = rp.RP_ID, ModulePermissionID = rp.MP_ID });
        }

        public bool GrantRolePermission(GrantRoleRequest request)
        {
            bool status = false;
            //3.1原来的所有权限id 3
            var listOldPer = base.GetListBy(rp => rp.RP_ID == request.RoleID).Select(r => r.MP_ID).ToList();

            //3.2新权限id  3,5,6
            var listNewPer = request.ModulePermissionIDs.ToList();
            //3.3将两个集合中 相同的元素 都删除，之后，新权限集合里的权限就是要新增到数据库的，旧权限集合里的权限 就是要从数据库删除的
            for (int i = listOldPer.Count - 1; i >= 0; i--)
            {
                string old = listOldPer[i];
                if (listNewPer.Contains(old))
                {
                    listOldPer.Remove(old);
                    listNewPer.Remove(old);
                }
            }
            try
            {

                listNewPer.ForEach(add =>
                {
                    idal.Add(new MODEL.FW_ROLEPERMISSION() { RP_ID = request.RoleID, MP_ID = add, CREATE_DT = DateTime.Now, MODIFY_DT = DateTime.Now });
                });
                if (listOldPer.Count > 0)
                {
                    idal.DelBy(rp => listOldPer.Contains(rp.MP_ID) && rp.RP_ID == request.RoleID);
                }
                IDBSession.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //return ;
                throw;
            }
        }

        public bool TranSetRolePermission(List<string> addIds, List<string> delIds, string roleId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<VIEW_FW_ROLEPERMISSION> GetAllPermissionListByRole(out int count)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取子集
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="allList"></param>
        public void GetPermissionChildren(ref VIEW_FW_PERMISSION parent, List<FW_PERMISSION> allList)
        {
            foreach (FW_PERMISSION permission in allList)
            {

                if (permission.PERMISSION_PID == parent.PERMISSION_ID)
                {

                    //实体转化
                    VIEW_FW_PERMISSION child = VIEW_FW_PERMISSION.ToViewModel(permission);
                    if (parent.children == null)
                        parent.children = new List<VIEW_FW_PERMISSION>();
                    //添加到父级的Children中
                    parent.children.Add(child);
                    GetPermissionChildren(ref child, allList);//递归添加子树
                }
            }
        }
    }
}
