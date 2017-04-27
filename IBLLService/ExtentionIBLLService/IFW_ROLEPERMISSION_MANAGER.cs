using MODEL;
using MODEL.DataTableModel;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IBLLService
{
    public partial interface IFW_ROLEPERMISSION_MANAGER : IBaseBLLService<FW_ROLEPERMISSION>
    {
        /// <summary>
        /// 获取角色权限Grid信息(如果数据量大需要考虑用异步的GridTree)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DataTableGrid GetPermissionForGridTree(DataTableRequest request);
        /// <summary>
        /// 获取角色权限Grid信息(如果数据量大需要考虑用异步的GridTree)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IEnumerable<VIEW_FW_ROLEPERMISSION> GetAllPermissionListByRole(out int count);
        /// <summary>
        /// 获取所有角色权限的json格式
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        object GetAllRolePermission(string rolecd);
        /// <summary>
        /// 授予角色权限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool GrantRolePermission(GrantRoleRequest request);



        bool TranSetRolePermission(List<string> addIds, List<string> delIds,string roleId);
    }
}
 