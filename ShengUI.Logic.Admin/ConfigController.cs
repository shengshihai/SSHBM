
using Common;
using Common.Attributes;
using IBLLService;
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
    public class ConfigController : Controller
    {
        public ISYS_REF_MANAGER ConfigManager = OperateContext.Current.BLLSession.ISYS_REF_MANAGER;
        public ISET_COUNTRY_MANAGER CountryManager = OperateContext.Current.BLLSession.ISET_COUNTRY_MANAGER;
        public ISET_REGION_MANAGER RegionManager = OperateContext.Current.BLLSession.ISET_REGION_MANAGER;

        [DefaultPage]
        [ActionParent]
        [ActionDesc("基础数据首页")]
        [Description("[基础数据]Config页面")]
        public ActionResult WebsiteInfo()
        {

            ViewBag.ConfigList = JsonHelper.ToJson(ConfigManager.GetListBy(c => c.REF_TYPE == "WebSiteSYS").ToList(), true);
            return View();
        }
        [ActionDesc("基础数据Seo")]
        [Description("[基础数据]基础数据Seo")]
        public ActionResult GetConfigList()
        {

            return View();
        }

        [ActionDesc("获取基础数据")]
        [Description("[基础数据]获取基础数据根据TYPE")]
        public ActionResult GetConfigs(string id)
        {
            var data = ConfigManager.GetListBy(c => c.REF_TYPE == id).ToList();
            return this.JsonFormat(data);
        }
        [ActionDesc("公司配置信息保存")]
        [Description("[基础数据]公司配置信息保存")]
        public ActionResult Save()
        {
            var data = false;
            var allKeys = HttpContext.Request.Form.AllKeys;
            try
            {
                foreach (var item in allKeys)
                {
                    ConfigManager.Save(item, Request[item]);
                }
                data = true;
                return this.JsonFormat(data,data, SysOperate.Update);
            }
            catch (Exception)
            {
                return this.JsonFormat(data, data,SysOperate.Update);
            }
        }
        [ActionDesc("公司配置信息修改")]
        [Description("[基础数据]公司配置信息修改")]
        public ActionResult Update()
        {
            var status = false;
            var allKeys = HttpContext.Request.Form.AllKeys;
            try
            {
                foreach (var item in allKeys)
                {
                     ConfigManager.Save(item, Request[item]);
                }

                status = true;
                return this.JsonFormat(status, status, SysOperate.Update);
            }
            catch (Exception)
            {
                return this.JsonFormat(status, SysOperate.Update);
            }
        }
        [ActionDesc("国家基础数据")]
        [Description("[国家基础数据]")]
        [Common.Attributes.Skip]
        public ActionResult GetCountry()
        {
            var data = CountryManager.GetListBy(c => true).ToList();

            return this.JsonFormat(data);
        }
         [ActionDesc("地区基础数据]")]
        [Description("地区基础数据]")]
        [Common.Attributes.Skip]
        public ActionResult GetRegion(int parentid)
        {
            var data = RegionManager.GetListBy(r => r.REGION_PID == parentid).ToList();
            return this.JsonFormat(data);
        }
         [ActionDesc("地区基础数据2]")]
         [Description("地区基础数据2]")]
        [Common.Attributes.Skip]
        public ActionResult GetRegionById(int id)
        {
            var model = RegionManager.Get(r => r.REGION_ID == id);
            var data = RegionManager.GetListBy(r => r.REGION_PID == model.REGION_PID).ToList();
            return this.JsonFormat(data);
        }
    }
}
