/*  作者：       盛世海
*  创建时间：   2012/8/4 15:49:40
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Common;
namespace MODEL.ViewModel
{
    public class GrantRoleRequest
    {
        #region - 属性 -

        public string ModulePermissions { get; set; }
        
        public string[] ModulePermissionIDs { get; set; }
        public string RoleID { get; set; }
        #endregion

        #region - 构造函数 -

        public GrantRoleRequest(HttpContextBase context)
        {
            ModulePermissions = context.Request["ModulePermissions"];
            ModulePermissionIDs = GetPermissionIds(ModulePermissions);
            RoleID =context.Request["RoleID"];
        }

        public GrantRoleRequest()
        {

        }

        #endregion

        #region - 方法 -

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public string[] GetPermissionIds(string permission)
        {
           
            string[] permissIDs = permission.Split(',');
             string[] ids=new string[permissIDs.Length-1];
            for (int i = 0; i < permissIDs.Length; i++)
            {
                if (!string.IsNullOrEmpty(permissIDs[i]))
                {
                    ids[i] = permissIDs[i];
                }
            }
            return ids;
        }

        #endregion


    }
}
