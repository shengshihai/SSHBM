using MODEL.ActionModel;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShengUI.Helper
{
    public class ConfigSettings
    {
        /// <summary>
        /// 配置文件路径
        /// </summary>
        private static string ConfigPath = "~/configSettings/AllowPageSettings.xml";
        /// <summary>
        /// 获得超级管理员角色ID
        /// </summary>
        /// <returns></returns>
        //public static int GetAdminUserRoleID()
        //{
        //    int value = 0;
        //    if (HttpContext.Current.Application["AdminUserRoleID"] == null)
        //    {
        //        value = Convert.ToInt32(XMlHelper.Read(HttpContext.Current.Server.MapPath(ConfigPath), "/pages/Admin/AdminUserRoleID", "value"));

        //        HttpContext.Current.Application["AdminUserRoleID"] = value;
        //    }
        //    else
        //    {
        //        value = (int)HttpContext.Current.Application["AdminUserRoleID"];

        //    }
        //    return value;
        //}

        /// <summary>
        /// 获得超级管理员的用户ID
        /// </summary>
        /// <returns></returns>
        //public static int GetAdminUserID()
        //{
        //    int value = 0;
        //    if (HttpContext.Current.Application["AdminUserID"] == null)
        //    {
        //        value = Convert.ToInt32(XMlHelper.Read(HttpContext.Current.Server.MapPath(ConfigPath), "/pages/Admin/AdminUserID", "value"));

        //        HttpContext.Current.Application["AdminUserID"] = value;
        //    }
        //    else
        //    {
        //        value = (int)HttpContext.Current.Application["AdminUserID"];

        //    }
        //    return value;
        //}
        /// <summary>
        /// 应用程序加载所有的Action动作
        /// </summary>
        /// <returns></returns>
        public static IList<MVCAction> GetAllAction()
        {
            IList<MVCAction> items = new List<MVCAction>();
            IList<MVCController> controllers = new List<MVCController>();
            if (HttpContext.Current.Application["MVCAction"] == null)
            {
                items = SysAction.GetAllActionByAssembly(out controllers);
                HttpContext.Current.Application["MVCAction"] = items;
                HttpContext.Current.Application["MVCController"] = controllers;
            }
            else
            {
                items = (IList<MVCAction>)HttpContext.Current.Application["MVCAction"];

            }
            return items;
        }
        /// <summary>
        /// 应用程序加载所有的Action动作
        /// </summary>
        /// <returns></returns>
        public static string GetActionParent(string controller)
        {
            string action = "";
            IList<MVCAction> items = new List<MVCAction>();
            IList<MVCController> controllers = new List<MVCController>();
            if (HttpContext.Current.Application["MVCAction"] == null)
            {
                items = SysAction.GetAllActionByAssembly(out controllers);
                HttpContext.Current.Application["MVCAction"] = items;
                HttpContext.Current.Application["MVCController"] = controllers;
            }
            else
            {
                items = (IList<MVCAction>)HttpContext.Current.Application["MVCAction"];

            }
            action = items.Where(a => a.ControllerName == controller && a.IsParent == true).FirstOrDefault().ActionName;
            return action;
        }
        /// <summary>
        /// 应用程序加载所有的Controller
        /// </summary>
        /// <returns></returns>
        public static IList<MVCController> GetAllController()
        {

            IList<MVCController> items = new List<MVCController>();
            if (HttpContext.Current.Application["MVCController"] == null)
            {
                HttpContext.Current.Application["MVCAction"] = SysAction.GetAllActionByAssembly(out items);
                HttpContext.Current.Application["MVCController"] = items;
            }
            else
            {
                items = (IList<MVCController>)HttpContext.Current.Application["MVCController"];

            }
            return items;
        }
        /// <summary>
        /// 应用程序加载所有的Controller
        /// </summary>
        /// <returns></returns>
        public static string GetSysConfigValue(string type ,string name)
        {

            IList<VIEW_SYS_REF> items = new List<VIEW_SYS_REF>();
            if (HttpContext.Current.Application["SYSConfig"] == null)
            {
                HttpContext.Current.Application["SYSConfig"] = VIEW_SYS_REF.ToListViewModel(OperateContext.Current.BLLSession.ISYS_REF_MANAGER.GetListBy(r => true).ToList()); 
            }
            else
            {
                items = (IList<VIEW_SYS_REF>)HttpContext.Current.Application["SYSConfig"];

            }
            var model=items.Where(r => r.REF_TYPE == type && r.REF_PARAM == name).FirstOrDefault();
            if (model == null)
                return "";
            return model.REF_VALUE;
        }
        public static List<VIEW_SYS_REF> GetSysConfigList(string type)
        {

            IList<VIEW_SYS_REF> items = new List<VIEW_SYS_REF>();
            if (HttpContext.Current.Application["SYSConfig"] == null)
            {
                HttpContext.Current.Application["SYSConfig"] = VIEW_SYS_REF.ToListViewModel(OperateContext.Current.BLLSession.ISYS_REF_MANAGER.GetListBy(r => true).ToList());
            }
            else
            {
                items = (IList<VIEW_SYS_REF>)HttpContext.Current.Application["SYSConfig"];

            }
            var model = items.Where(r => r.REF_TYPE == type).OrderBy(r=>r.REF_SEQ).ToList();
            if (model == null)
                return items.ToList();
            return model;
        }
      
        /// <summary>
        /// 读取所有允许访问的路径(主要是针对登录等等不进行权限验证处理)
        /// </summary>
        /// <returns></returns>
        //public static IList<string> GetAllAllowPage()
        //{
        //    List<string> list = new List<string>();
        //    if (HttpContext.Current.Application["AllowPage"] == null)
        //    {
        //        //加载XML
        //        XDocument xDoc = XDocument.Load(HttpContext.Current.Server.MapPath(ConfigPath));

        //        IEnumerable<XElement> PageList = xDoc.Root.Descendants("page");

        //        foreach (XElement element in PageList)
        //        {

        //            list.Add(element.Value.ToString());
        //        }
        //        HttpContext.Current.Application["AllowPage"] = list;
        //    }
        //    else
        //    {
        //        list = (List<string>)HttpContext.Current.Application["AllowPage"];
        //    }
        //    return list;

        //}
    }
}
