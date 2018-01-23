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
using MODEL;

using Common.EfSearchModel.Model;
using MODEL.DataTableModel;
using MODEL.ViewPage;


namespace ShengUI.Logic.Admin
{
    [AjaxRequestAttribute]
    [Description("产品管理")]
    public class ProductController : Controller
    {
        IMST_PRD_MANAGER prdB = OperateContext.Current.BLLSession.IMST_PRD_MANAGER;
        IMST_CATEGORY_MANAGER categroyB = OperateContext.Current.BLLSession.IMST_CATEGORY_MANAGER;
        [DefaultPage]
        [ActionParent]
        [ActionDesc("产品管理首页")]
        [Description("[产品管理]产品管理首页列表信息")]
        public ActionResult ProductIndex()
        {
            return View();
        }

        [ActionDesc("产品详细信息")]
        [Description("[产品管理]产品详细信息(add,Update,Detail必备)")]
        public ActionResult ProductDetail(string id)
        {
            ViewBag.TYPE = "Add";
            ViewBag.CATE_IDS = DataSelect.ToListViewModel(VIEW_MST_CATEGORY.ToListViewModel(categroyB.GetListBy(m => m.ISSHOW == true && m.ACTIVE == true)));
            var model = prdB.Get(m => m.PRD_CD == id);
            if (model == null)
            {
                return View(new VIEW_MST_PRD() { PRD_CD = "PRD"+Common.Tools.Get8Digits() });
            }
            ViewBag.TYPE = "Update";
            return View(VIEW_MST_PRD.ToViewModel(model));
        }

        [ActionDesc("产品管理获取产品信息列表")]
        [Description("[产品管理]获取产品信息(主页必须)")]
        public ActionResult GetProductForGrid(QueryModel model)
        {

            DataTableRequest request = new DataTableRequest(HttpContext,model);
            return this.JsonFormat(prdB.GetProductsForGrid(request));
        }


        public ActionResult UploadProductImg()
        {

            bool status = false;
            var fileurl = UploadRequestImg.OneImageSave(HttpContext);
            status = true;
            return this.JsonFormat(fileurl, status, "上传成功!");
        }
       
        
       
        [ValidateInput(false)]
        [ActionDesc("添加", "Y")]
        [Description("[产品管理]添加动作")]
        public ActionResult Add(VIEW_MST_PRD model)
        {
            
            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, status, "ERROR");
            var prd = VIEW_MST_PRD.ToEntity(model);
            try
            {
                prd.ISCHECK = true;
                prd.CREATE_BY = OperateContext.Current.UsrId;
                prd.CREATE_DT = DateTime.Now;
                prdB.Add(prd);
                status = true;
            }
            catch (Exception e)
            {

                return this.JsonFormat(status, status, SysOperate.Add);
            }
            return this.JsonFormat("/Admin/Product/ProductIndex", status, SysOperate.Add.ToMessage(status), status);
        }


        [ValidateInput(false)]
        [ActionDesc("修改", "Y")]
        [Description("[产品管理]修改动作")]
        public ActionResult Update(VIEW_MST_PRD model)
        {
            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, status, "ERROR");
            var prd = VIEW_MST_PRD.ToEntity(model);
            try
            {
                prd.MODIFY_DT = DateTime.Now;
                prdB.Modify(prd, "PRD_NAME", "CATE_ID", "PRD_SHORT_DESC", "PRD_DESC", "ISHOT", "STATUS", "PRICE", "ARKETPRICE", "FRONTPRICE", "REMARK1", "SEQ_NO", "MODIFY_DT");
                status = true;
            }
            catch (Exception ex)
            {
                return this.JsonFormat(status, !status, ex.Message + ex.StackTrace);
            }
            return this.JsonFormat("/Admin/Product/ProductIndex", status, SysOperate.Update.ToMessage(status), status);
        }

        [ActionDesc("删除", "Y")]
        [Description("[产品管理]软删除动作")]
        public ActionResult Delete()
        {
            var ids = HttpContext.Request["Ids"].Split(',').ToList();
            var data = false;
            try
            {
                MODEL.MST_PRD prd = new MODEL.MST_PRD() {ISCHECK=false, SYNCOPERATION = "D" };
                if (prdB.ModifyBy(prd, p => ids.Contains(p.PRD_CD), "ISCHECK", "SYNCOPERATION") > 0)
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
        [ActionDesc("永久删除", "Y")]
        [Description("[产品管理]永久删除动作")]
        public ActionResult RealDelete()
        {
            bool status = false;
            try
            {
                status = true;
            }
            catch (Exception e)
            {

                return this.JsonFormat(status, status, SysOperate.Delete);
            }

            return this.JsonFormat(status, status, SysOperate.Delete);
        }
       
      
        //[Description("[产品详细信息]获取产品分类信息（语言）")]
        //public ActionResult GetProductCategoryByLanguage()
        //{
         
        //    return this.JsonFormat("");
        //}
        [ActionDesc("永久删除图片")]
        [Description("[产品管理]永久删除图片")]
        public ActionResult DeleteImg()
        {

            string url = @" " + HttpContext.Request["ImageUrl"];
            url = Server.MapPath("~");
            try
            {
                FileOperate.FileDel(HttpContext.Server.MapPath(url));
                FileOperate.FileDel(HttpContext.Server.MapPath(url + "_150x150.jpg"));
                FileOperate.FileDel(HttpContext.Server.MapPath(url + "_359x359.jpg"));
                FileOperate.FileDel(HttpContext.Server.MapPath(url + "_680x680.jpg"));
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Content("no" + ex.Message);
            }
        }
    }
}
