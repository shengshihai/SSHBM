using IBLLService;
using ShengUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Common;

namespace ShengUI.Logic.Admin
{
    public class AdminController : Controller
    {
       
        #region 获取登录视图
        /// <summary>
        /// 获取登录视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Common.Attributes.Skip]
        public ActionResult Logon()
        {
            
         
            if(!string.IsNullOrEmpty(OperateContext.Current.UsrId))
                return new RedirectResult("/admin/Manage/index");
            return View();
        }
         
        
        [HttpGet]
        
        public ActionResult Select()
        {
            
         

            return View();
        }
         
        #endregion
        #region 退出系统
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <returns></returns>
        [Common.Attributes.Skip]
        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("/admin/admin/logon");
        }
        
        #endregion

        #region 登录系统
        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Common.Attributes.Skip]
        public ActionResult Login(MODEL.ViewPage.LoginUser user)
        { //1.2服务器端验证，如果没有验证通过

            if (!ModelState.IsValid)
            {
                return this.JsonFormat(ModelState, !false, "ERROR");
               // return OperateContext.Current.RedirectAjax("err", "没有权限!", null, "");
            }
            if (OperateContext.Current.LoginAdmin(user))
            {
                //UserOperateLog.WriteOperateLog("[" + user.UserName + "成功登录]" + SysOperate.Operate.ToMessage(true));
               // return this.JsonFormat("", true, "/admin/Manage/index", true);
                return this.JsonFormat("", true, "/admin/Admin/Select", true);
            }
            else
            {
                return this.JsonFormat("", true, "用户名或密码错误");
            }
        }
        
        #endregion

        #region 验证码
        [Common.Attributes.Skip]
        public ActionResult ValidateCode()
        {
            var code = Common.ValidateCode.CreateValidateNumber(4);
            this.Session["ValidateCode"] = code;
            return File(Common.ValidateCode.CreateValidateGraphic(code), "image/jpeg");
        } 
        #endregion
      
       
    }
}
