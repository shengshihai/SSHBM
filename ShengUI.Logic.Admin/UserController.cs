/*  作者：       盛世海
*  创建时间：   2012/7/19 10:36:31
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using MODEL.ViewModel;
using Common;
using Common.Attributes;
using IBLLService;
using ShengUI.Helper;
using MODEL.DataTableModel;
using MODEL.ViewPage;
using Common.EfSearchModel.Model;


namespace ShengUI.Logic.Admin
{

    [Description("用户管理")]
    public class UserController : Controller
    {
        IFW_USER_MANAGER UserInfoManager = OperateContext.Current.BLLSession.IFW_USER_MANAGER;
        IFW_ROLE_MANAGER RoleManager = OperateContext.Current.BLLSession.IFW_ROLE_MANAGER;



        [DefaultPage]
        [ActionParent]
        [ActionDesc("用户管理首页")]
        [Description("[用户管理]用户管理首页")]
        public ActionResult UserInfo()
        {
            // UserOperateLog.WriteOperateLog("[用户管理]浏览用户详细信息" + SysOperate.Load.ToMessage(true));
            return View();
        }
        [ActionDesc("获取用户列表信息")]
        [Description("[用户管理]获取用户信息(主页必须)")]
        public ActionResult GetUserForGrid(QueryModel model)
        {
            DataTableRequest requestGrid = new DataTableRequest(HttpContext, model);
            return this.JsonFormat(UserInfoManager.GetAllUsers(requestGrid));
        }
        [ViewPage]
        [ActionDesc("获取用户信息")]
        [Description("[用户管理]详细信息(add,Update,Detail必备)")]
        public ActionResult Detail(string id)
        {
            ViewDetailPage page = new ViewDetailPage(HttpContext);
            ViewBag.IsView = page.IsView;
            ViewBag.CurrentID = id;
            ViewBag.TYPE = "Update";
            ViewBag.ReturnUrl = Request["returnurl"];
            var model =UserInfoManager.Get(u => u.USER_ID == id);
            if (model == null)
            {
                ViewBag.TYPE = "Add";
                return View(new VIEW_FW_USER());
            }
            return View(VIEW_FW_USER.ToViewModel(model));

        }
        [ActionDesc("检查帐号名")]
        [Description("[用户管理]检查帐号名是否存在(add,Update必备)")]
        public ActionResult CheckUserNameExist(string username)
        {
            return Content((UserInfoManager.GetListBy(p => p.USER_ID == username).Count() == 0).ToString().ToLower());
        }
        [Description("[用户管理]添加用户")]
        [ActionDesc("添加", "Y")]
        public ActionResult Add(VIEW_FW_USER user)
        {

            var currUser = VIEW_FW_USER.ToEntity(user);

            bool status = false;
            try
            {
                currUser.CREATE_BY = OperateContext.Current.UsrId;
                currUser.CREATE_DT = DateTime.Now;
                UserInfoManager.Add(currUser);
                status = true;
            }
            catch (Exception e)
            {
                return this.JsonFormat(status, status, SysOperate.Add);

            }
            return this.JsonFormat(status, status, SysOperate.Add);
        }
        [Description("[用户管理]更新用户")]
        [ActionDesc("编辑", "Y")]
        public ActionResult Update(VIEW_FW_USER user)
        {
            var model = VIEW_FW_USER.ToEntity(user);
            bool status = false;
            try
            {
                model.LAST_UPDATED_DT = DateTime.Now;
                model.MODIFY_DT = DateTime.Now;
                model.MODIFY_BY = OperateContext.Current.UsrId;
                UserInfoManager.Modify(model, "USER_NAME", "EMAIL", "ENG_NAME", "PHONE", "LAST_UPDATED_DT", "MODIFY_BY", "MODIFY_DT");
                status = true;
            }
            catch (Exception e)
            {
                return this.JsonFormat(status, status, SysOperate.Update);

            }
            return this.JsonFormat("/Admin/User/UserInfo", status, SysOperate.Update.ToMessage(status), status);
        }

        [ActionDesc("删除", "Y")]
        [Description("[用户管理]软删除用户")]
        public ActionResult Delete()
        {
            ViewDetailPage page = new ViewDetailPage(HttpContext);
            var model = new MODEL.FW_USER();
            model.USER_ID = page.CurrentID;
            model.SYNCOPERATION = "D";
            bool status = false;
            try
            {
                UserInfoManager.Modify(model, "SYNCOPERATION");
                status = true;
            }
            catch (Exception e)
            {
                return this.JsonFormat(status, status, SysOperate.Delete);
            }
            return this.JsonFormat(status, status, SysOperate.Delete);
        }
        [ActionDesc("永久删除", "Y")]
        [Description("[用户管理]永久删除用户")]
        public ActionResult RealDelete()
        {
            ViewDetailPage page = new ViewDetailPage(HttpContext);
            var model = new MODEL.FW_USER();
            model.USER_ID = page.CurrentID;
            bool status = false;
            try
            {
                UserInfoManager.Del(model);
                status = true;
            }
            catch (Exception e)
            {
                return this.JsonFormat(status, status, SysOperate.Delete);
            }
            return this.JsonFormat(status, status, SysOperate.Delete);
        }
        //[Description("角色选择的下拉框用户详细")]
        //public ActionResult GetRolesForSelect()
        //{
        //    EasyUISelectRequest requestSelect = new EasyUISelectRequest(HttpContext);
        //    return this.JsonFormat(RoleManager.GetRolesForSelect(requestSelect));
        //}
    }
}
