
using Common;
using Common.Attributes;
using IBLLService;
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
    public class WeChatConfigController : Controller
    {
        public ISYS_REF_MANAGER SYSREF = OperateContext.Current.BLLSession.ISYS_REF_MANAGER;
        public IYX_sysConfigs_MANAGER Yx_ConfigManager = OperateContext.Current.BLLSession.IYX_sysConfigs_MANAGER;
        public IYX_weiXinMenus_MANAGER Yx_Menus_Manager = OperateContext.Current.BLLSession.IYX_weiXinMenus_MANAGER;
        public IYX_news_MANAGER Yx_News_M = OperateContext.Current.BLLSession.IYX_news_MANAGER;
        public IYX_text_MANAGER Yx_Text_M = OperateContext.Current.BLLSession.IYX_text_MANAGER;
        [DefaultPage]
        [ActionParent]
        [ActionDesc("WeChatConfig首页")]
        [Description("[WeChat管理]WeChatConfig页面")]
        public ActionResult WeChatConfigInfo()
        {

            ViewBag.ConfigList = JsonHelper.ToJson(Yx_ConfigManager.GetListBy(c => true).Select(c => new MODEL.YX_sysConfigs { wxkey = c.wxkey, wxkeyvalue = c.wxkeyvalue }).ToList(), true);
            return View();
        }
        [ActionDesc("WeChatConfig配置信息保存")]
        [Description("[WeChat管理]配置信息保存")]
        public ActionResult Save()
        {
            var data = false;
            var allKeys = HttpContext.Request.Form.AllKeys;
            try
            {
                foreach (var item in allKeys)
                {
                    Yx_ConfigManager.Save(item, Request[item]);
                }
                data = true;
                return this.JsonFormat(data, data, SysOperate.Update);
            }
            catch (Exception)
            {
                return this.JsonFormat(data, data, SysOperate.Update);
            }
        }

        #region 管理菜单列表
        [ActionDesc("WeChat管理菜单列表")]
        [Description("[WeChat管理]WeChat管理菜单列表")]
        public ActionResult WeChatMenus()
        {

            return View();
        }
        [ActionDesc("获取WeChat菜单信息Grid")]
        [Description("[WeChat管理]获取WeChat菜单信息")]
        public ActionResult GetWeChatMenusForGrid()
        {
            DataTableRequest requestGrid = new DataTableRequest(HttpContext);
            return this.JsonFormat(Yx_Menus_Manager.GetWeChatMenusForGrid(requestGrid));
        }
        [ActionDesc("菜单View")]
        [Description("[WeChat管理]WeChat管理菜单View")]
        public ActionResult WeChatMenusDetail(string id)
        {
            var wid = TypeParser.ToInt32(id);
            ViewBag.TYPE = "Add";
            ViewBag.PID = DataSelect.ToListViewModel(VIEW_YX_weiXinMenus.ToListViewModel(Yx_Menus_Manager.GetListBy(m => m.WX_Fid == 0)));
            ViewBag.WX_MenuTypes = DataSelect.ToListViewModel(ConfigSettings.GetSysConfigList("WECHATMENUSTYPE"));
            var model = Yx_Menus_Manager.Get(m => m.Id == wid);
            if (model == null)
            {
                return View(new VIEW_YX_weiXinMenus());
            }
            ViewBag.TYPE = "Update";
            return View(VIEW_YX_weiXinMenus.ToViewModel(model));
        }
        [ActionDesc("菜单配置View")]
        [Description("[WeChat管理]WeChat管理菜单配置View")]
        public ActionResult WeChatMenuSetDetail(string id, string type)
        {
            var wid = TypeParser.ToInt32(id);
            ViewBag.Menu_ID = wid;
            ViewBag.TYPE = type;
            ViewBag.WX_NewsTypes = DataSelect.ToListViewModel(ConfigSettings.GetSysConfigList("WECHATNEWSTYPE"));
            var model = new VIEW_YX_MenusMsg() { MID = 0, Event_ID = wid, Event_Type = type, EventCate = "menu" };

            switch (type)
            {
                case "1": model = VIEW_YX_MenusMsg.ToViewModel(VIEW_YX_text.ToViewModel(Yx_Text_M.Get(n => n.EventId == wid && n.EventCate == "menu"))); break;
                case "2": model = VIEW_YX_MenusMsg.ToViewModel(VIEW_YX_news.ToViewModel(Yx_News_M.Get(n => n.EventId == wid && n.EventCate == "menu"))); break;
            }
            return View(model);

        }
        [ActionDesc("配置菜单", "Y")]
        [Description("[WeChat管理]WeChat管理配置菜单")]
        public ActionResult WeChatMenuSet(VIEW_YX_MenusMsg model)
        {

            var data = false;
            //if (model.Event_Type == "2" && !ModelState.IsValid)
            //    return this.JsonFormat(ModelState, data, "ERROR");
           
            try
            {
                Yx_Text_M.DelBy(t => t.EventId == model.Event_ID && t.EventCate == "menu");
                Yx_News_M.DelBy(t => t.EventId == model.Event_ID && t.EventCate == "menu");
                switch (model.Event_Type)
                {
                    case "1": var text = new MODEL.YX_text() { Id = model.MID, EventId = TypeParser.ToInt32(model.Event_ID), EventCate = "menu", msgContent = model.MsgContent };
                      
                            Yx_Text_M.Add(text);
                            Yx_Menus_Manager.Modify(new MODEL.YX_weiXinMenus() { Id = model.Event_ID, flat1 = 1 }, "flat1");
                        break;
                    case "2":
                        var news = new MODEL.YX_news() { Id = model.MID, EventId = TypeParser.ToInt32(model.Event_ID), EventCate = "menu", newsTitle = model.NewsTitle, newsDescription = model.NewsDescription, newsPicUrl = model.NewsPicUrl, newsUrl = model.NewsUrl };
                            Yx_News_M.Add(news);
                            Yx_Menus_Manager.Modify(new MODEL.YX_weiXinMenus() { Id = model.Event_ID, flat1 = 2 }, "flat1");
                        break;
                    
                }
                data = true;
                return this.JsonFormat("/admin/WeChatConfig/WeChatMenus", data, SysOperate.Operate.ToMessage(data), data);
                //return this.JsonFormat(data, data, SysOperate.Add);
            }
            catch (Exception)
            {
                return this.JsonFormat(data, data, SysOperate.Add);
            }
        }
        [ActionDesc("添加菜单", "Y")]
        [Description("[WeChat管理]WeChat管理菜单Add")]
        public ActionResult WeChatMenusAdd(VIEW_YX_weiXinMenus model)
        {
            var data = false;
            try
            {
                Yx_Menus_Manager.Add(VIEW_YX_weiXinMenus.ToEntity(model));
                data = true;
                return this.JsonFormat("/admin/WeChatConfig/WeChatMenus", data, SysOperate.Add.ToMessage(data), data);
            }
            catch (Exception)
            {
                return this.JsonFormat(data, data, SysOperate.Add);
            }
        }
        [ActionDesc("修改菜单", "Y")]
        [Description("[WeChat管理]WeChat管理菜单Update")]
        public ActionResult WeChatMenusUpdate(VIEW_YX_weiXinMenus model)
        {
            var data = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, data, "ERROR");
            var menu = VIEW_YX_weiXinMenus.ToEntity(model);
            try
            {
                Yx_Menus_Manager.Modify(menu, "WX_Fid", "WX_menuName", "WX_MenuType", "WX_MenusKey_URL");
                data = true;
                return this.JsonFormat("/admin/WeChatConfig/WeChatMenus", data, SysOperate.Update.ToMessage(data), data);
            }
            catch (Exception)
            {
                return this.JsonFormat(data, data, SysOperate.Update);
            }
        }
        [ActionDesc("删除菜单", "Y")]
        [Description("[WeChat管理]WeChat管理菜单Delete")]
        public ActionResult WeChatMenusDelete()
        {
            var ids = HttpContext.Request["Ids"].Split(',').Select(id => TypeParser.ToInt32(id)).ToList();
            var data = false;
            try
            {
                if (Yx_Menus_Manager.DelBy(m => ids.Contains(m.Id)) > 0)
                {
                    data = true;
                }
                return this.JsonFormat(data, data, SysOperate.Delete);
            }
            catch (Exception)
            {
                return this.JsonFormat(data, data, SysOperate.Delete);
            }
        }

        #endregion
        [ActionDesc("WeChat消息配置")]
        [Description("[WeChat管理]WeChat消息配置")]
        public ActionResult WeChatMsgSet()
        {

            return View();
        }
        [ActionDesc("获取WeChat消息配置Grid")]
        [Description("[WeChat管理]获取WeChat消息配置")]
        public ActionResult GetWeChatMsgSetForGrid()
        {
            DataTableRequest requestGrid = new DataTableRequest(HttpContext);
            return this.JsonFormat(Yx_Menus_Manager.GetWeChatMsgSetForGrid(requestGrid));
        }

        [ActionDesc("消息配置View")]
        [Description("[WeChat管理]WeChat消息配置View")]
        public ActionResult WeChatSetDetail(string id, string type)
        {
            var wid = TypeParser.ToInt32(id);
            ViewBag.TYPE = "Add";
            ViewBag.PID = DataSelect.ToListViewModel(VIEW_YX_weiXinMenus.ToListViewModel(Yx_Menus_Manager.GetListBy(m => m.WX_Fid == 0)));
            ViewBag.WX_MenuTypes = DataSelect.ToListViewModel(ConfigSettings.GetSysConfigList("WECHATMENUSTYEPE"));
            var model = Yx_Menus_Manager.Get(m => m.Id == wid);
            if (model == null)
            {
                return View(new VIEW_YX_weiXinMenus());
            }
            ViewBag.TYPE = "Update";
            return View(VIEW_YX_weiXinMenus.ToViewModel(model));
        }

        [ActionDesc("添加配置", "Y")]
        [Description("[WeChat管理]WeChat添加配置Add")]
        public ActionResult WeChatSetAdd(VIEW_YX_weiXinMenus model)
        {
            var data = false;
            try
            {

                data = true;
                return this.JsonFormat(data, data, SysOperate.Add);
            }
            catch (Exception)
            {
                return this.JsonFormat(data, data, SysOperate.Add);
            }
        }
        [ActionDesc("配置消息", "Y")]
        [Description("[WeChat管理]WeChat配置消息")]
        public ActionResult WeChatSetSetting()
        {
            var data = false;
            try
            {

                data = true;
                return this.JsonFormat(data, data, SysOperate.Delete);
            }
            catch (Exception)
            {
                return this.JsonFormat(data, data, SysOperate.Delete);
            }
        }
        [ActionDesc("删除配置", "Y")]
        [Description("[WeChat管理]WeChat消息配置Delete")]
        public ActionResult WeChatSetDelete()
        {
            var data = false;
            try
            {

                data = true;
                return this.JsonFormat(data, data, SysOperate.Delete);
            }
            catch (Exception)
            {
                return this.JsonFormat(data, data, SysOperate.Delete);
            }
        }
    }
}
