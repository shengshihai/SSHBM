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

    [Description("微信用户管理")]
    public class WeChatUserController : Controller
    {
        IFW_USER_MANAGER UserInfoManager = OperateContext.Current.BLLSession.IFW_USER_MANAGER;
        IFW_ROLE_MANAGER RoleManager = OperateContext.Current.BLLSession.IFW_ROLE_MANAGER;
        IYX_weiUser_MANAGER wechatUserB = OperateContext.Current.BLLSession.IYX_weiUser_MANAGER;
        ITG_transactionLog_MANAGER transactionlogB = OperateContext.Current.BLLSession.ITG_transactionLog_MANAGER;

        [DefaultPage]
        [ActionParent]
        [ActionDesc("微信用户管理首页")]
        [Description("[微信用户管理]微信用户管理首页")]
        public ActionResult WeChatUserInfo() 
        {
            // UserOperateLog.WriteOperateLog("[用户管理]浏览用户详细信息" + SysOperate.Load.ToMessage(true));
            return View();
        }
        [ActionDesc("获取用户列表信息")]
        [Description("[用户管理]获取用户信息(主页必须)")]
        public ActionResult GetWeChatUserForGrid(QueryModel model)
        {
            DataTableRequest requestGrid = new DataTableRequest(HttpContext, model);
            return this.JsonFormat(wechatUserB.GetWeChatUserForGrid(requestGrid));
        }
        [ViewPage]
        [ActionDesc("获取微信用户信息")]
        [Description("[微信用户管理]详细信息(add,Update,Detail必备)")]
        public ActionResult WeChatDetail(string userNum)
        {
            ViewBag.UserType = DataSelect.ToListViewModel(ConfigSettings.GetSysConfigList("USERTYPE")); 
            ViewBag.ReturnUrl = Request["returnurl"];
            ViewDetailPage page = new ViewDetailPage(HttpContext);
            ViewBag.IsView = page.IsView;
            //ViewBag.CurrentID = id;
            ViewBag.TYPE = "Update";
            var model = wechatUserB.Get(u => u.userNum == userNum);
            if (model == null)
            {
                ViewBag.TYPE = "Add";
                return View(new VIEW_YX_weiUser() { });
            }
            return View(VIEW_YX_weiUser.ToViewModel(model));

        }
        [Description("[微信用户管理]新建非微信用户")]
        [ActionDesc("新建", "Y")]
        public ActionResult Add(VIEW_YX_weiUser user)
        {

            var currUser = VIEW_YX_weiUser.ToEntity(user);

            bool status = false;
            try
            {
                currUser.openid = currUser.userNum;
                currUser.subscribe_time = DateTime.Now;
                wechatUserB.Add(currUser);
                status = true;
            }
            catch (Exception e)
            {
                return this.JsonFormat(status, status, SysOperate.Add);

            }
            return this.JsonFormat("/Admin/WeChatUser/WeChatUserInfo", status, SysOperate.Add.ToMessage(status), status);
        }
        [Description("[微信用户管理]更新微信用户")]
        [ActionDesc("编辑", "Y")]
        public ActionResult Update(VIEW_YX_weiUser user)
        {
          
            bool status = false;
            try
            {
                user.RegTim1 = DateTime.Now;
                if (!string.IsNullOrEmpty(user.btnChargeMoney))
                {
                   
                    var model = wechatUserB.GetModelWithOutTrace(u => u.userNum == user.userNum);
                    if (model != null && user.ReChargeMoney > 0)
                    {
                        MODEL.TG_transactionLog log = new MODEL.TG_transactionLog();
                        log.userId = model.userNum;
                        log.openid = model.openid;
                        log.tranCate = 1;
                        log.remark4 = "1000";
                        log.CateName = "会员充值";
                        log.tranMoney = user.ReChargeMoney;
                        log.tranContent = "会员充值(会员充值金额：" + user.ReChargeMoney + ";充值前金额为：" + model.userYongJin + ";充值后金额为：" + (model.userYongJin + user.ReChargeMoney) + ")";
                        log.orderNum = "UserReCharge";
                        log.AddTime = DateTime.Now; model.userMoney = model.userMoney + user.ReChargeMoney;
                         model.userYongJin = model.userYongJin + user.ReChargeMoney;
                    
                        wechatUserB.ChargeMoney(log,model, "userMoney", "userYongJin", "RegTim1");
                    }
                    else
                    {
                        ModelState.AddModelError("ReChargeMoney_Msg", "金额必须大于0元");
                        return this.JsonFormat(ModelState, status, "ERROR");
                    }
                
                   // wechatUserB.Modify(model, "userRelname", "userTel", "userWXnum", "userQQ", "remark1", "isfenxiao", "userMoney", "RegTim1");
                }
                else
                {
                    wechatUserB.Modify(VIEW_YX_weiUser.ToEntity(user), "userRelname", "userTel", "userWXnum", "userQQ", "remark1","remark2", "RegTim1", "isfenxiao");

                }
                status = true;
            }
            catch (Exception e)
            {
                return this.JsonFormat(status, status, SysOperate.Update);

            }
            return this.JsonFormat("/Admin/WeChatUser/WeChatUserInfo", status, SysOperate.Update.ToMessage(status), status);
        }
         
        [ActionDesc("删除", "Y")]
        [Description("[微信用户管理]软删除用户")]
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
        //[ActionDesc("永久删除", "Y")]
        //[Description("[微信用户管理]永久删除用户")]
        //public ActionResult RealDelete()
        //{
        //    ViewDetailPage page = new ViewDetailPage(HttpContext);
        //    var model = new MODEL.FW_USER();
        //    model.USER_ID = page.CurrentID;
        //    bool status = false;
        //    try
        //    {
        //        UserInfoManager.Del(model);
        //        status = true;
        //    }
        //    catch (Exception e)
        //    {
        //        return this.JsonFormat(status, status, SysOperate.Delete);
        //    }
        //    return this.JsonFormat(status, status, SysOperate.Delete);
        //}
        //[Description("角色选择的下拉框用户详细")]
        //public ActionResult GetRolesForSelect()
        //{
        //    EasyUISelectRequest requestSelect = new EasyUISelectRequest(HttpContext);
        //    return this.JsonFormat(RoleManager.GetRolesForSelect(requestSelect));
        //}
        [Description("[微信用户管理]设置用户车辆")]
        [ActionDesc("会员车辆", "Y")]
        public ActionResult UserCar(VIEW_FW_USER user)
        {

            var currUser = VIEW_FW_USER.ToEntity(user);

            bool status = false;
            try
            {
                //UserInfoManager.Add(currUser);
                status = true;
            }
            catch (Exception e)
            {
                return this.JsonFormat(status, status, SysOperate.Add);

            }
            return this.JsonFormat(status, status, SysOperate.Add);
        }
    }
}
