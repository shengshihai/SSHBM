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
using MODEL.ViewPage;

namespace ShengUI.Logic
{
    public class ResumeController : BaseController
    {
        IMST_RESUME_MANAGER resumeManager = OperateContext.Current.BLLSession.IMST_RESUME_MANAGER;
        IMST_RESUME_DTL_MANAGER resume_dtlManager = OperateContext.Current.BLLSession.IMST_RESUME_DTL_MANAGER;
        public ActionResult ResumeIndex()
        {
            ViewBag.PageFlag = "JianLi";
            var member_cd = SessionHelper.Get("MEMBER_CD");
            VIEW_MST_RESUME model = VIEW_MST_RESUME.ToViewModel(resumeManager.Get(r => r.MEMBER_CD == member_cd));
            List<VIEW_MST_RESUME_DTL> modellist = VIEW_MST_RESUME_DTL.ToListViewModel(resume_dtlManager.GetListBy(r => r.MEMBER_CD == member_cd && r.RESUME_CD == model.RESUME_CD)).ToList();
            ViewBag.ResumeDtlList = modellist;
            return View(model);
        }
        public ActionResult ReNameResume(ReNameResume model)
        {
            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, !status, "ERROR");
            MST_RESUME resume = new MST_RESUME();
            resume.RESUME_CD = model.RESUME_CD;
            resume.RESUME_NAME = model.RESUME_NAME;
            resume.VERSION = model.VERSION + 1;
            resume.SYNCVERSION =DateTime.Now;
            resume.SYNCOPERATION = "U";
            resumeManager.Modify(resume, "RESUME_NAME", "VERSION", "SYNCVERSION", "SYNCOPERATION");
            status = true;
            return this.JsonFormat(resume, !status, "保存成功");
        }
        public ActionResult SaveBaseInfo(ResumeBaseInfo model)
        {
            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, !status, "ERROR");

            MST_RESUME resume = new MST_RESUME();
            resume.RESUME_CD = model.RESUME_CD;
            resume.NAME = model.NAME;
            resume.EMAIL = model.EMAIL;
            resume.EDUCATION = model.EDUCATION;
            resume.EXPERIENCE = model.EXPERIENCE;
            resume.SEX = model.SEX;
            resume.PHONE = model.PHONE;
            resume.CURRENT_STATE = model.CURRENT_STATE;
            resume.PORTRAIT = model.PORTRAIT;
            resumeManager.Modify(resume, "NAME", "EMAIL", "EDUCATION", "EXPERIENCE", "SEX", "PHONE", "CURRENT_STATE", "PORTRAIT");
            status = true;
            return this.JsonFormat(resume, !status, "保存成功");
        }
        public ActionResult SaveZWPJ(ResumeZWPJ model)
        {
            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, !status, "ERROR");
            var member_cd = SessionHelper.Get("MEMBER_CD");
            MST_RESUME_DTL dtl = new MST_RESUME_DTL();
            dtl.ID = model.ResumeZWPJID;
            dtl.RESUME_CD = model.RESUME_CD;
            dtl.MEMBER_CD = member_cd;
            dtl.RESUME_DTL1 = model.selfDesc;
            resume_dtlManager.Modify(dtl, "RESUME_DTL1");
            status = true;
            return this.JsonFormat(dtl, !status, "保存成功");
        }
        public ActionResult SaveWorkForm(ResumeWork model)
        {
            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, !status, "ERROR");
            var member_cd = SessionHelper.Get("MEMBER_CD");
            MST_RESUME_DTL dtl = new MST_RESUME_DTL();
            dtl.RESUME_CD = model.RESUME_CD;
            dtl.MEMBER_CD = member_cd;
            dtl.RESUME_DTL1 = model.workLink;
            dtl.RESUME_DTL2 = model.workDesc;
            resume_dtlManager.Add(dtl);
            status = true;
            return this.JsonFormat(dtl, !status, "保存成功");
        }
    }
}
