
using Common;
using Common.Attributes;
using Common.EfSearchModel.Model;
using IBLLService;
using MODEL.ActionModel;
using MODEL.DataTableModel;
using MODEL.ViewModel;
using ShengUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShengUI.Logic.Admin
{
    [AjaxRequestAttribute]
    [Description("菜单管理")]
    public class MenusController : Controller
    {
        IFW_MODULE_MANAGER ModuleManager = OperateContext.Current.BLLSession.IFW_MODULE_MANAGER;
        #region 菜单管理部分
        //
        // GET: /Admin/Menus/
        [ActionDesc("菜单管理主页")]
        [Description("[菜单管理]菜单管理主页")]
        [DefaultPage]
        [ActionParent]
        public ActionResult MenuInfo()
        {
            ViewBag.ModuleLeftMenus =MODEL.ViewModel.VIEW_FW_MODULE.ToListViewModel( ModuleManager.GetListBy(m => m.MODULE_PID == "MAIN_FIRST" || m.MODULE_ID == "MAIN_FIRST"));
            //  UserOperateLog.WriteOperateLog("[菜单管理]浏览菜单管理主页"+SysOperate.Load.ToString());
            return View();
        }
         [ActionDesc("菜单详细信息")]
         [Description("[菜单管理]菜单详细信息")]
        public ActionResult MenusDetail(string id)
        {
            ViewBag.TYPE = "Add";
            ViewBag.PID= DataSelect.ToListViewModel(VIEW_FW_MODULE.ToListViewModel(ModuleManager.GetListBy(m => true)));
            ViewBag.MVCController = DataSelect.ToListViewModel(LINQHelper.GetIenumberable<MVCController>(ConfigSettings.GetAllController(), p => p.ControllerName.ToLower() != "",
                     q => q.ControllerName, 200,
                     1));
            var model = ModuleManager.Get(m => m.MODULE_ID == id);
            if (model == null)
            {
                return View(new VIEW_FW_MODULE() { });
            }
            ViewBag.TYPE = "Update";
            return View(VIEW_FW_MODULE.ToViewModel(model));
        }
        [ActionDesc("添加","Y")]
        [Description("[菜单管理]菜单管理Add")]
        public ActionResult Add(VIEW_FW_MODULE model)
        {
            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, status, "ERROR");
            var menu = VIEW_FW_MODULE.ToEntity(model);
            try
            {
                ModuleManager.Add(menu);
                status = true;
            }
            catch (Exception e)
            {
                return this.JsonFormat("SYSERROR", status, e.Message);
            }
            return this.JsonFormat("/admin/menus/MenuInfo", status, SysOperate.Add.ToMessage(status), status);
        }
        [ActionDesc("编辑", "Y")]
        [Description("[菜单管理]菜单管理Update")]
        public ActionResult Update(VIEW_FW_MODULE model)
        {
            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, status, "ERROR");
            var menu = VIEW_FW_MODULE.ToEntity(model);
            try
            {
                menu.MODIFY_DT = DateTime.Now;
                ModuleManager.Modify(menu, "MODULE_PID", "MODULE_NAME", "MODULE_CONTROLLER", "ISMENU", "ISVISIBLE", "ICON", "MODULE_LINK", "MODIFY_DT");
                status = true;
            }
            catch (Exception e)
            {
                return this.JsonFormat("SYSERROR", status, e.Message);
            }
            return this.JsonFormat("/admin/menus/MenuInfo", status, SysOperate.Update.ToMessage(status), status);
        }
        [ActionDesc("获取菜单Grid信息")]
        [Description("[菜单管理]获取菜单下的子菜单的Grid信息(首页必须)")]
        public ActionResult GetMenusForGrid(QueryModel model)
        {
            DataTableRequest requestGrid = new DataTableRequest(HttpContext, model);
            return this.JsonFormat(ModuleManager.GetMenusForGrid(requestGrid) );
        }
        #endregion
        #region 菜单按钮管理
        [ActionDesc("菜单按钮管理", "Y")]
        [Description("[菜单管理]菜单按钮管理")]
        public ActionResult MenuButtonConfig()
        {
            MODEL.ViewPage.ViewSelectParamPage page = new MODEL.ViewPage.ViewSelectParamPage(HttpContext);
            var data = ModuleManager.GetListBy(p => p.MODULE_CONTROLLER == page.ControllerName).FirstOrDefault();
            return this.JsonFormatSuccess(data.MODULE_CONTROLLER, "允许访问");

        }
        #endregion
    }
}
