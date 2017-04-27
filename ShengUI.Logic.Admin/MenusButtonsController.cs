using IBLLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Common;
using MODEL.ViewModel;
using System.ComponentModel;
using Common.Attributes;
using ShengUI.Helper;
using MODEL.ViewPage;
using Common.EfSearchModel.Model;
using MODEL.DataTableModel;

namespace ShengUI.Logic.Admin
{

    public class MenusButtonsController : Controller
    {

        IFW_MODULEPERMISSION_MANAGER ModulePermissionManager = OperateContext.Current.BLLSession.IFW_MODULEPERMISSION_MANAGER;
        IFW_PERMISSION_MANAGER PermissionManager = OperateContext.Current.BLLSession.IFW_PERMISSION_MANAGER;
        [ActionDesc("菜单按钮管理主页")]
        [Description("[菜单按钮管理]菜单按钮管理主页")]
        [DefaultPage]
        public ActionResult MenusButtonInfo()
        {
            ViewSelectParamPage select = new ViewSelectParamPage(HttpContext);
            ViewBag.ControllerName = select.ControllerName;
            ViewBag.MenuID = select.MenuID;
            return View();
        }
        [ActionDesc("菜单按钮管理主页Grid 加载的ajax")]
        [Description("[菜单按钮管理]主页Grid 加载的ajax请求,根据菜单获取按钮(首页必须)")]
        public ActionResult GetMenuButtons(QueryModel model)
        {
            DataTableRequest requestGrid = new DataTableRequest(HttpContext, model);
            return this.JsonFormat(ModulePermissionManager.GetMenusButtonsForGrid(requestGrid));
        }

        //[Description("[菜单按钮管理]加载数据库权限表信息(Add,Update必须)")]
        //public ActionResult SelectPermission()
        //{
        //    //EasyUIGridRequest request = new EasyUIGridRequest(HttpContext);
        //    //return this.JsonFormat(PermissionManager.GetPermissionForGrid(request));
        //    return this.JsonFormat(true, true, SysOperate.Update);
        //}
        [ActionDesc("重置权限", "Y")]
        [Description("[菜单按钮管理]重置权限")]
        public ActionResult SetPermission(string menu_cd)
        {
            int i = 0;
            try
            {
                i = ModulePermissionManager.SetMenusButtonsByMenuCD(menu_cd);
            }
            catch (Exception)
            {
                   return this.JsonFormat(false, false, "程序异常！是否存子节点MPID重复");
                throw;
            }
            if(i>0)
                return this.JsonFormat(true, true, SysOperate.Update);
            else
                return this.JsonFormat(false, false, SysOperate.Update);

        }
        [ActionDesc("添加", "Y")]
        [Description("[菜单按钮管理]添加请求")]
        public ActionResult Add(string menu_cd)
        {
            ModulePermissionManager.DelBy(mp => mp.MODULE_ID == menu_cd);
            return this.JsonFormat(true, true, SysOperate.Update);

        }
        [ActionDesc("编辑", "Y")]
        [Description("[菜单按钮管理]修改请求")]
        public ActionResult Update()
        {

            return this.JsonFormat(true, true, SysOperate.Update);

        }
        [ActionDesc("删除", "Y")]
        [Description("[菜单按钮管理]删除(假删除)")]
        public ActionResult Delete()
        {


            bool status = false;

            return this.JsonFormat(status, status, SysOperate.Delete);
        }
        [ActionDesc("永久删除", "Y")]
        [Description("[菜单按钮管理]永久删除动作")]
        public ActionResult RealDelete()
        {

            return this.JsonFormat(true, true, SysOperate.Update);

        }


    }
}
