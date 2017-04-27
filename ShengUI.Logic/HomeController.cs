using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using IBLLService;
using MODEL.ViewModel;
using Common;
using MODEL;
using ShengUI.Helper;
using System.Threading;
using System.Globalization;
using Common.EfSearchModel.Model;

namespace ShengUI.Logic
{
    [HandleError]
    public class HomeController : BaseController
    {
        IMST_MEMBER_MANAGER memberManager = OperateContext.Current.BLLSession.IMST_MEMBER_MANAGER;
        IMST_CATEGORY_MANAGER categoryManager = OperateContext.Current.BLLSession.IMST_CATEGORY_MANAGER;
        IMST_POSITION_MANAGER positionManager = OperateContext.Current.BLLSession.IMST_POSITION_MANAGER;
        public ActionResult Index()
        {
            ViewBag.PageFlag = "Index";
            ViewBag.CategoryList = VIEW_MST_CATEGORY.ToListViewModel( categoryManager.GetListBy(c => c.ACTIVE == true));
            ViewBag.PositionHotList = positionManager.LoadListBy(p => p.STATUS == "Y" && p.ISHOT == "Y", p => p.PUBLISH_DT, false).Skip(0).Take(20).Select(p => new VIEW_MST_POSITION()
                {
                    POSITION_CD = p.POSITION_CD,
                    COMPANY_CD = p.COMPANY_CD,
                    NAME = p.NAME,
                    DEPARTMENTNAME = p.DEPARTMENTNAME,
                    WORKTYPE = p.WORKTYPE,
                    MONEY = p.MONEY,
                    WORKPLACE = p.WORKPLACE,
                    EXPERIENCE = p.EXPERIENCE,
                    EDUCATION = p.EDUCATION,
                    REMARK = p.REMARK,
                    ISNEW = p.ISNEW,
                    ISHOT = p.ISHOT,
                    STATUS = p.STATUS,
                    PUBLISH_DT = p.PUBLISH_DT,
                    COMPANY_NAME = p.MST_COMPANY.COMPANY_NAME,
                    COMPANY_SIZE = p.MST_COMPANY.COMPANY_SIZE,
                    INDUSTRY = p.MST_COMPANY.INDUSTRY,
                    DEVELOPMENT = p.MST_COMPANY.DEVELOPMENT

                }).ToList();
            ViewBag.PositionNewList = positionManager.LoadListBy(p => p.STATUS == "Y" && p.ISNEW == "Y", p => p.PUBLISH_DT, false).Skip(0).Take(20).Select(p => new VIEW_MST_POSITION()
                {
                    POSITION_CD = p.POSITION_CD,
                    COMPANY_CD = p.COMPANY_CD,
                    NAME = p.NAME,
                    DEPARTMENTNAME = p.DEPARTMENTNAME,
                    WORKTYPE = p.WORKTYPE,
                    MONEY = p.MONEY,
                    WORKPLACE = p.WORKPLACE,
                    EXPERIENCE = p.EXPERIENCE,
                    EDUCATION = p.EDUCATION,
                    REMARK = p.REMARK,
                    ISNEW = p.ISNEW,
                    ISHOT = p.ISHOT,
                    STATUS = p.STATUS,
                    PUBLISH_DT = p.PUBLISH_DT,
                    COMPANY_NAME = p.MST_COMPANY.COMPANY_NAME,
                    COMPANY_SIZE = p.MST_COMPANY.COMPANY_SIZE,
                    INDUSTRY = p.MST_COMPANY.INDUSTRY,
                    DEVELOPMENT = p.MST_COMPANY.DEVELOPMENT

                }).ToList();
          
            return View();
        }

        public ActionResult About()
        {
            ViewBag.PageFlag = "About";
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult LoginUser(MODEL.ViewPage.LoginUser model)
        {
            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, !status, "ERROR");

            MODEL.MST_MEMBER member = new MST_MEMBER();
            try
            {
                member=memberManager.Get(m => (m.EMAIL == model.UserName || m.PHONE == model.UserName) && m.PASSWORD == model.Password);
                if (member != null)
                {
                    status = true;
                    SessionHelper.Add("MEMBER_CD", member.MEMBER_CD);
                    return this.JsonFormat(model, status, "/Resume/ResumeIndex", status);
                }
                else
                {
                    ModelState.AddModelError("password", "用户名或密码错误！");
                    return this.JsonFormat(ModelState, status, "ERROR");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("password", "登录失败！");
                return this.JsonFormat(ModelState, !status, "ERROR");
                throw;
            }

        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult RegisterUser(MODEL.ViewPage.UserRegister model)
        {
            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, !status, "ERROR");

            MODEL.MST_MEMBER member = new MST_MEMBER();
            try
            {
                member.MEMBER_CD = Tools.Get8Digits();
                member.EMAIL = model.email;
                member.PASSWORD = model.password;
                memberManager.Add(member);
                status = true;
                SessionHelper.Add("MEMBER_CD", member.MEMBER_CD);
                return this.JsonFormat(model, !status, "/Resume/ResumeIndex", status);
            }
            catch (Exception)
            {
                 ModelState.AddModelError("password", "注册失败！");
                 return this.JsonFormat(ModelState, !false, "ERROR");
                throw;
            }
            
        }
   
        //#endregion
    }

}
