using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using MODEL.ViewModel;
using MODEL.DataTableModel;

namespace IBLLService
{
    public partial interface IFW_USER_MANAGER : IBaseBLLService<FW_USER>
    {
        
        FW_USER Login(string loginName, string pwd);

        #region 业务逻辑
        #region 用户信息
        /// 根据条件获取所有用户
        /// </summary>
        /// <param name="request">请求条件</param>
        /// <param name="Count">记录总数</param>
        /// <returns></returns>
        IEnumerable<FW_USER> GetAllUsers(DataTableRequest request, ref int Count);
        /// <summary>
        /// 根据条件获取所有菜单
        /// </summary>
        /// <param name="request">请求条件</param>
        /// <returns></returns>
        DataTableGrid GetAllUsers(DataTableRequest request);
        /// <summary>
        /// 获取用户所有的角色信息
        /// </summary>
        /// <param name="User">用户信息实体</param>
        /// <returns>用户所有的角色用,隔开</returns>
        string GetUserAllRole(FW_USER User);

        /// <summary>
        /// 获取用户角色信息
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        string GetUserAllRole(int UserID);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="requestInfo"></param>
        /// <returns></returns>
        //bool ChangePassword(UserRequest requestInfo, int UserID);

        #endregion

        #endregion

        /// <summary>
        /// 请求一级菜单树
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
       // IEnumerable<ViewModelMenu> GetUserTreeMenus(EasyUITreeRequest request, string userRoles);
        /// <summary>
        /// 获取用户的菜单
        /// </summary>
        /// <param name="Roles"></param>
        /// <returns></returns>
        //IEnumerable<ViewModelMenu> GetUserPermissionMenus(List<int> userMenuIds);
        /// <summary>
        /// 获取请求的Grid菜单列表的LigeruiGrid格式
        /// </summary>
        /// <param name="request">请求</param>
        /// <param name="userRoles">角色组</param>
        /// <param name="AdminUserRoleID">超级管理员角色ID</param>
        /// <returns></returns>
        DataTableGrid GetUserGridMenus(DataTableRequest request, List<int> userMenuId, int parentid);
        /// <summary>
        /// 获取角色指定菜单的按钮信息
        /// </summary>
        /// <param name="Roles">角色信息</param>
        /// <param name="RequestController">请求信息</param>
        /// <param name="AdminUserRoleID">超级管理员角色ID</param>
        /// <returns></returns>
        IEnumerable<MyButton> GetUserRoleButtons(string USER_CD, List<int> UserRoles, ButtonRequest RequestController);
    }
}
