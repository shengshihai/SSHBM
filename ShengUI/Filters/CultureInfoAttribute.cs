using ShengUI.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShengUI.Filters
{
    public class CultureInfoAttribute : FilterAttribute, IActionFilter
    {
        /// <summary>
        /// 站点支持的语言列表
        /// </summary>
        public static readonly List<string> AvailableCultures = new List<string>
        {
            "en-US","zh-CN"
        };
        public void OnActionExecuting(ActionExecutingContext
            filterContext)
        {
            string cultureCode = GetBrowserCulture(filterContext);
            if (string.IsNullOrEmpty(cultureCode) ||
                !AvailableCultures.Any(o => o.Equals(cultureCode,
                         StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            try
            {
                //new MultiLangRouteHandler();
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cultureCode);
            }
            catch (Exception)
            {

            }
        }
         //string langtype = filterContext.HttpContext.Session["CurrentUICulture"] != null ? filterContext.HttpContext.Session["CurrentUICulture"].ToString() : "";
         //   string lang = "zh-CN";
         //   switch (langtype)
         //   {
         //       case "1": lang = "zh-CN"; break;
         //       case "2": lang = "en-US"; break;
         //       default: lang = "zh-CN"; break;
         //   }

         //   System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
        /// <summary>
        /// 获取浏览器的语言设置
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        private string GetBrowserCulture(ActionExecutingContext filterContext)
        {

            var langtype = OperateContext.Current.CurrentUICultureId;
            var lang = "en-US";
            switch (langtype)
            {
                case 1: lang = "zh-CN"; break;
                case 2: lang = "en-US"; break;
                default: lang = "zh-CN"; break;
            }
            return lang;
            //var browerCulture = filterContext.HttpContext.Request.UserLanguages;
            //if (browerCulture == null)
            //{
            //    return null;
            //}
            //foreach (var item in browerCulture)
            //{
            //    if (AvailableCultures.Any(o => o.Equals(item,
            //          StringComparison.OrdinalIgnoreCase)))
            //    {
            //        return item;
            //    }
            //}
           
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }

}