
using Common;
using IBLLService;
using MODEL.ViewModel;
using SampleUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SampleUI.Logic.Admin
{
    public class SiteNavController : Controller
    {
        ISample_Navigation_ItemManager MenuItemManager = OperateContext.Current.BLLSession.ISample_Navigation_ItemManager;
          
        [Description("[公司Config--SiteNav页面]")]
        public ActionResult Index()
        {
            ViewData["MenuList"] = MenuItemManager.GetListBy(m => true);
            UserOperateLog.WriteOperateLog("[公司Config--SiteNav页面]浏览公司Config--SiteNav页面" + SysOperate.Load.ToMessage(true));
            return View();
        }
        public ActionResult Detail(int id)
        {
            var model = MenuItemManager.Get(m => m.smiid == id);
            return View(model);
        }
        [Description("[公司Config--SiteNav页面]添加")]
        public ActionResult Add()
        {
            ViewModelSiteNav request = new ViewModelSiteNav(HttpContext);

            bool status = false;
            try
            {
                MenuItemManager.Add(ViewModelSiteNav.ToEntity(request));
                status = true;

            }
            catch (Exception ex)
            {
                UserOperateLog.WriteOperateLog("[公司Config--SiteNav页面]添加导航操作" + SysOperate.Add.ToMessage(status), ex.ToString());
                return this.JsonFormat(status, !status, ex.Message + ex.StackTrace);
            }
            UserOperateLog.WriteOperateLog("[公司Config--SiteNav页面]添加导航操作" + SysOperate.Add.ToMessage(status));
            return this.JsonFormat(status, status, SysOperate.Update);

        }
        [Description("[公司Config--SiteNav页面]修改")]
        public ActionResult Update()
        {
            ViewModelSiteNav request = new ViewModelSiteNav(HttpContext);
           
            bool status = false;
            try
            {
                MenuItemManager.Modify(ViewModelSiteNav.ToEntity(request), "menuname","url","ordering");
                status = true;
            }
            catch (Exception e)
            {
                UserOperateLog.WriteOperateLog("[公司Config--SiteNav页面]修改导航操作" + SysOperate.Update.ToMessage(status),e.ToString());
                return this.JsonFormat(status, status, SysOperate.Update);
            }
            UserOperateLog.WriteOperateLog("[公司Config--SiteNav页面]修改导航操作" + SysOperate.Update.ToMessage(status));
            return this.JsonFormat(status, status, SysOperate.Update);
        }
        [Description("[公司Config--SiteNav页面]修改")]
        public ActionResult UpdateDetail()
        {
            ViewModelSiteNav request = new ViewModelSiteNav(HttpContext);

            bool status = false;
            try
            {
                MenuItemManager.Modify(ViewModelSiteNav.ToEntity(request), "menuname", "url", "ordering", "menutitle", "bindname");
                status = true;
            }
            catch (Exception e)
            {
                UserOperateLog.WriteOperateLog("[公司Config--SiteNav页面]修改导航操作" + SysOperate.Update.ToMessage(status), e.ToString());
                return this.JsonFormat(status, status, SysOperate.Update);
            }
            UserOperateLog.WriteOperateLog("[公司Config--SiteNav页面]修改导航操作" + SysOperate.Update.ToMessage(status));
            return this.JsonFormat(status, status, SysOperate.Update);
        }
       
    }
}
