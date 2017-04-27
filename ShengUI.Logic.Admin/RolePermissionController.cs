/*  作者：       盛世海
*  创建时间：   2012/8/3 15:44:01
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using Common.Attributes;
using ShengUI.Helper;
using MODEL.ViewModel;
using IBLLService;
using Common;
using MODEL.DataTableModel;

namespace ShengUI.Logic.Admin
{
    public class RolePermissionController : Controller
    {
        IFW_ROLEPERMISSION_MANAGER RolePermissionManager = OperateContext.Current.BLLSession.IFW_ROLEPERMISSION_MANAGER;
        IFW_MODULEPERMISSION_MANAGER ModulePermissionManager = OperateContext.Current.BLLSession.IFW_MODULEPERMISSION_MANAGER;
        IFW_ROLE_MANAGER RoleManager = OperateContext.Current.BLLSession.IFW_ROLE_MANAGER;
        // GET: /Admin/RolePermission/
        [DefaultPage]
        [ActionParent]
        [ActionDesc("角色权限管理首页")]
        [Description("[角色权限管理]角色权限管理首页")]
        public ActionResult RolePermissionInfo()
        {
            ViewBag.RoleList = RoleManager.GetListBy(r=>true);
            var data = ModulePermissionManager.GetAllModulePermission();
            ViewBag.PermissionList = data;
            return View();
        }
        [ActionDesc("获取角色权限Grid数据")]
        [Description("[角色权限管理]获取角色权限Grid数据")] 
        public ActionResult GetPermissionGrid()
        {
            DataTableRequest request = new DataTableRequest(HttpContext);
            //GridTree禁用分页,设置每页5000条
            request.PageSize = 5000;
            return this.JsonFormat(RolePermissionManager.GetPermissionForGridTree(request));

        }
        [ActionDesc("授予","Y")]
        [Description("[角色权限管理]授予角色权限")] 
        public ActionResult GrantRolePermission()
        {
            GrantRoleRequest request = new GrantRoleRequest(HttpContext);
            bool status = false;
            try
            {
                status = RolePermissionManager.GrantRolePermission(request);
            }
            catch (Exception e)
            {
                return this.JsonFormat(status, status, SysOperate.Operate);
            }
            //UserOperateLog.WriteOperateLog("[角色权限管理]对角色:" + request.RoleID + "进行权限分配:" + SysOperate.Operate.ToMessage(status));
            return this.JsonFormat(status, status, SysOperate.Operate);
        }
        [ActionDesc("获取授予权限的数据")]
        [Description("[角色权限管理]获取角色权限数据信息(权限授予的数据)")] 
        public ActionResult GetRolePermissionForData()
        {
            var roleid = (HttpContext.Request["roleid"]);
            return this.JsonFormat(RolePermissionManager.GetAllRolePermission(roleid), SysOperate.Load);
        }


    }
}
