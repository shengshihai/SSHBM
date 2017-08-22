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

    [Description("车辆管理")]
    public class CarController : Controller
    {
        IMST_CAR_MANAGER carB = OperateContext.Current.BLLSession.IMST_CAR_MANAGER;
        IYX_weiUser_MANAGER userB = OperateContext.Current.BLLSession.IYX_weiUser_MANAGER;
        ISYS_USERLOGIN_MANAGER sys_UsurLogin = OperateContext.Current.BLLSession.ISYS_USERLOGIN_MANAGER;


        [DefaultPage]
        [ActionParent]
        [ActionDesc("车辆管理首页")]
        [Description("[车辆管理]车辆管理首页")]
        public ActionResult CarInfo() 
        {
            ViewBag.Data = "";
            ViewBag.UserName = "";
            ViewBag.AddWhere = "";
            var usernum = Request.QueryString["userNum"];
            var username = Request.QueryString["userName"];
            if (!string.IsNullOrEmpty(usernum))
            {
                ViewBag.Data = @"'data': { '[Equal]UserId': '" + usernum + "'}";
                ViewBag.UserName = userB.Get(u=>u.userNum==usernum).userRelname;
                ViewBag.AddWhere = "?userNum="+usernum;
            }
            // UserOperateLog.WriteOperateLog("[用户管理]浏览用户详细信息" + SysOperate.Load.ToMessage(true));
            return View();
        }
        [ActionDesc("获取车辆列表信息")]
        [Description("[车辆管理]获取车辆信息(主页必须)")]
        public ActionResult GetCarForGrid(QueryModel model)
        {
            DataTableRequest requestGrid = new DataTableRequest(HttpContext, model);
            return this.JsonFormat(carB.GetCarForGrid(requestGrid));
        }
        [ViewPage]
        [ActionDesc("获取车辆信息")]
        [Description("[车辆管理]详细信息(add,Update,Detail必备)")]
        public ActionResult CarDetail(string car_cd)
        {
            VIEW_MST_CAR car = new VIEW_MST_CAR() { CAR_CD = "CAR" + Common.Tools.Get8Digits() ,AddTime=DateTime.Now};
            var usernum = Request.QueryString["userNum"];
            if (!string.IsNullOrEmpty(usernum))
            {
                car.UserId = usernum;
            }
            //var list = IDBSession.ISYS_USERLOGIN_REPOSITORY.LoadListBy(su => su.LOGIN_ID == OperateContext.Current.UsrId).Select(su => su.SLSORG_CD);
            ViewBag.MEMBERS = DataSelect.ToListViewModel(VIEW_YX_weiUser.ToListViewModel(userB.GetListBy(u=>true,u=>u.userRelname)));
            ViewBag.ReturnUrl = Request["returnurl"];
            ViewDetailPage page = new ViewDetailPage(HttpContext);
            ViewBag.IsView = page.IsView;
            //ViewBag.CurrentID = id;
            ViewBag.TYPE = "Update";
            var model = carB.Get(u => u.CAR_CD == car_cd);
            if (model == null)
            {
                ViewBag.TYPE = "Add";
                return View(car);
            }
            return View(VIEW_MST_CAR.ToViewModel(model));

        }
        [Description("[车辆管理]添加车辆信息")]
        [ActionDesc("添加车辆", "Y")]
        public ActionResult Add(VIEW_MST_CAR car)
        {
            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, status, "ERROR");
            var currCar = VIEW_MST_CAR.ToEntity(car);
            var ReturnUrl = Request["returnurl"];
            try
            {
                carB.Add(currCar);
                status = true;
            }
            catch (Exception e)
            {
                return this.JsonFormat(status, status, SysOperate.Add);

            }
            return this.JsonFormat(ReturnUrl, status, SysOperate.Update.ToMessage(status), status);
        }
        [Description("[车辆管理]更新车辆信息")]
        [ActionDesc("编辑", "Y")]
        public ActionResult Update(VIEW_MST_CAR car)
        {
            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, status, "ERROR");
            var currCar = VIEW_MST_CAR.ToEntity(car);
            try
            {
                carB.Modify(currCar, "UserId", "CAR_NUM", "CAR_BRAND", "CAR_CATEGORY", "CAR_COLOR", "CAR_REMARK");
                status = true;
            }
            catch (Exception e)
            {
                return this.JsonFormat(status, status, SysOperate.Update);

            }
            return this.JsonFormat("/Admin/Car/CarInfo", status, SysOperate.Update.ToMessage(status), status);
        }

        [ActionDesc("删除", "Y")]
        [Description("[车辆管理]软删除车辆")]
        public ActionResult Delete()
        {
            var ids = HttpContext.Request["Ids"].Split(',').ToList();
            var data = false;
            try
            {
                MODEL.MST_CAR car=new MODEL.MST_CAR(){SYNCOPERATION="D"};
                if (carB.ModifyBy(car, m => ids.Contains(m.CAR_CD), "SYNCOPERATION") > 0)
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
    }
}
