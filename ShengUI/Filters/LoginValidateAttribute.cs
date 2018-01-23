using Common;
using ShengUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ShengUI.Filters
{
    /// <summary>
    /// 管理员 身份验证 过滤器
    /// </summary>
    public class LoginValidateAttribute:System.Web.Mvc.AuthorizeAttribute
    {
        #region 1.0 验证方法 - 在 ActionExcuting过滤器之前执行
        /// <summary>
        /// 验证方法 - 在 ActionExcuting过滤器之前执行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            SetCultureInfo(filterContext);
            //获取区域名
            string strArea = filterContext.RouteData.DataTokens.Keys.Contains("area") ? filterContext.RouteData.DataTokens["area"].ToString().ToLower() : "";
            string strContrllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            //要验证的区域名 集合
            List<string> listAreaLimite = new List<string>() { "admin", "workflow" };
            List<string> listControllerLimite = new List<string>() { "home", "product", "message", "accounts", "customer", "buying", "enterprise", "productcategory", "information" };
            //1.如果请求的 Admin 区域里的 控制器类和方法，那么就要验证权限
            if (!string.IsNullOrEmpty(strArea) && listAreaLimite.Contains(strArea))//监测区域名 是否为 admin
            {

                //2.检查 被请求的 方法 和 控制器是否有 Skip 标签，如果有，则不验证；如果没有，则验证
                //if (!filterContext.ActionDescriptor.IsDefined(typeof(Common.Attributes.SkipAttribute), false) &&
                //    !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(Common.Attributes.SkipAttribute), false))
                //{
                //0.验证是否要 跳过 登陆 和 权限验证，如果不要，则继续判断
                if (!DoesSkip<Common.Attributes.SkipAttribute>(filterContext))
                {
                    bool isLogin = false;
                    //1.是否要跳过 验证登陆
                    if (!DoesSkip<Common.Attributes.SkipLoginAttribute>(filterContext))
                    {
                        #region 1.验证用户是否登陆(Session && Cookie)
                        //1.验证用户是否登陆(Session && Cookie)
                        string msg = "";
                        isLogin = OperateContext.Current.IsLogin(out msg);
                       
                        if (!isLogin)
                        {
                            filterContext.Result = OperateContext.Current.Redirect("/admin/admin/logon", filterContext.ActionDescriptor,msg);
                        }
                        #endregion
                    }
                    if (OperateContext.Current.UserRole==null||!OperateContext.Current.UserRole.Contains(1))
                    {
                        //2.如果已经登陆，则判断 是否要跳过 权限验证；如果没有登陆，则不需要验证了
                        //if (isLogin && !DoesSkip<Common.Attributes.SkipPemissionAttribute>(filterContext))
                        //{
                        //    #region //2.验证登陆用户 是否有访问该页面的权限
                        //    //2.获取 登陆用户权限
                        //    string strAreaName = filterContext.RouteData.DataTokens["area"].ToString().ToLower();
                        //    string strContrllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
                        //    string strActionName = filterContext.ActionDescriptor.ActionName.ToLower();
                        //    string strHttpMethod = filterContext.HttpContext.Request.HttpMethod;

                        //    if (!OperateContext.Current.HasPemission(strAreaName, strContrllerName, strActionName, strHttpMethod))
                        //    {
                        //        filterContext.Result = new FormatJsonResult() { IsError = true, Data = null, Message = "您没有权限执行此操作！" };//功能权限弹出提示框
                        //    }
                        //    #endregion
                        //}
                    }
                }
            }
            else if (!string.IsNullOrEmpty(strContrllerName) && listControllerLimite.Contains(strContrllerName))//监测区域名 是否为 admin
            {
                if (!DoesSkip<Common.Attributes.SkipAttribute>(filterContext))
                {
                    var code = (filterContext.HttpContext.Session["code"]);
                    //if (code == null || code.ToString().Trim() == "")
                     //   filterContext.Result = OperateContext.Current.Redirect("/home/index.html", filterContext.ActionDescriptor);
                }
                //    int suid = TypeParser.ToInt32(filterContext.HttpContext.Session["supplieruser"]);
                //    if (sid <= 0 && suid <= 0)
                //    {

                //        filterContext.Result = OperateContext.Current.Redirect("/home/login?returnurl=" + filterContext.HttpContext.Request.Url.ToString(), filterContext.ActionDescriptor);
                //    }
                //if (!DoesSkip<Common.Attributes.SkipAttribute>(filterContext))
                //{
                //    int sid = TypeParser.ToInt32(filterContext.HttpContext.Session["supplier"]);
                //    int suid = TypeParser.ToInt32(filterContext.HttpContext.Session["supplieruser"]);
                //    if (sid <= 0 && suid <= 0)
                //    {

                //        filterContext.Result = OperateContext.Current.Redirect("/home/login?returnurl=" + filterContext.HttpContext.Request.Url.ToString(), filterContext.ActionDescriptor);
                //    }
                //}
                
            }
            else
            { }
        }
        #endregion
        void SetCultureInfo(System.Web.Mvc.AuthorizationContext filterContext)
        {
            var langtype = filterContext.HttpContext.Session["CurrentUICulture"] != null ? filterContext.HttpContext.Session["CurrentUICulture"].ToString() : "";
            var lang = "zh-CN";
            switch (langtype)
            {
                case "1": lang = "zh-CN"; break;
                case "2": lang = "en-US"; break;
                default: lang = "zh-CN"; break;
            }
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
        }
        /// <summary>
        /// 是否跳过验证
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        bool DoesSkip<T>(System.Web.Mvc.AuthorizationContext filterContext) where T:Attribute
        {
            if (!filterContext.ActionDescriptor.IsDefined(typeof(T), false) &&
                    !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(T), false))
            {
                return false;
            }
            return true;
        }
    }
}
