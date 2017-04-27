using IBLLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Common;
using MODEL.ViewModel;
using System.ComponentModel;
using ShengUI.Helper;
using Common.Attributes;
using System.Web;
using System.IO;
using MODEL.DataTableModel;
using MODEL.ViewPage;
using Common.EfSearchModel.Model;


namespace ShengUI.Logic.Admin
{
    public class ArticleController : Controller
    {
        public IMST_ARTICLE_MANAGER ArticleManager = OperateContext.Current.BLLSession.IMST_ARTICLE_MANAGER;
        public IMST_ATTACHMENTS_MANAGER AttachmentsManager = OperateContext.Current.BLLSession.IMST_ATTACHMENTS_MANAGER;
        public IMST_CATALOG_MANAGER CatalogManager = OperateContext.Current.BLLSession.IMST_CATALOG_MANAGER;

        [DefaultPage]
        [ActionParent]
        [ActionDesc("企业门户")]
        [Description("[企业门户]企业门户新闻资讯")]
        public ActionResult ArticleInfo()
        {
            ViewBag.ModuleLeftMenus = MODEL.ViewModel.VIEW_MST_CATALOG.ToListViewModel(CatalogManager.GetListBy(m => m.SYNCOPERATION != "D"));
            //UserOperateLog.WriteOperateLog("[文章管理]浏览文章列表视图页:" + SysOperate.Load.ToMessage(true));
            return View();
        }
        [ActionDesc("企业门户分类")]
        [Description("[企业门户]企业门户分类")]
        public ActionResult ArticleLeftMenu()
        {
            ViewData["ArticleLeftMenu"] = CatalogManager.GetCatalogTree(null);
            return View();
        }
        [ActionDesc("获取企业门户Grid数据")]
        [Description("[企业门户]获取企业门户Grid数据")]
        public ActionResult GetArticleGrid(QueryModel model)
        {
            DataTableRequest request = new DataTableRequest(HttpContext, model);
            return this.JsonFormat(ArticleManager.GetArticleForGrid(request));

        }
        [ViewPage]
        [ActionDesc("查看")]
        [Description("[企业门户]企业门户详细信息(add,Update,Detail必备)")]
        public ActionResult Detail(int id)
        {
            ViewBag.CATALOG_CDS = DataSelect.ToListViewModel(VIEW_MST_CATALOG.ToListViewModel(CatalogManager.GetListBy(m => m.SYNCOPERATION != "D")));
            //执行状态
            var article = new MODEL.ViewModel.VIEW_MST_ARTICLE();
            var model = ArticleManager.Get(a => a.ARTICLE_ID == id);
            if (model != null)
            {//转化为视图UI层的实体对象
                ViewBag.ParentID = model.ARTICLE_ID;
                article = VIEW_MST_ARTICLE.ToViewModel(model);
                ViewBag.Images = JsonHelper.ToJson(VIEW_MST_ATTACHMENTS .ToListViewModel(AttachmentsManager.GetListBy(at => at.ITEM_ID == id && at.ISIMAGE == "Y")), true);
            }
            return View(article);

        }
        [ValidateInput(false)]
        [HttpPost]
        [ActionDesc("添加", "Y")]
        [Description("[企业门户]添加企业门户")]
        public ActionResult Add(VIEW_MST_ARTICLE articel )
        {
            this.ValidateRequest = false;
            var status = false;
            //1.2服务器端验证，如果没有验证通过
            if (!ModelState.IsValid)
            {
                return this.JsonFormat(ModelState, !false, "ERROR");
                // return OperateContext.Current.RedirectAjax("err", "没有权限!", null, "");
            }

            var model = VIEW_MST_ARTICLE.ToEntity(articel);
            try
            {
                int said = ArticleManager.Add(model);
                status = true;
            }
            catch (Exception e)
            {
                return this.JsonFormat(model, !status, e.Message);
            }
            return this.JsonFormat(model, status, SysOperate.Add);
        }
        [ValidateInput(false)]
        [HttpPost]
        [ActionDesc("编辑", "Y")]
        [Description("[企业门户]编辑企业门户")]
        public ActionResult Update(VIEW_MST_ARTICLE articel)
        {
            this.ValidateRequest = false;
            var status = false;
            var model = ArticleManager.Get(sa => sa.ARTICLE_ID == articel.ARTICLE_ID);

            try
            {
                //ArticleManager.ModifyAll(ViewModelArticle.ToArticle(articel, model));
                //List<MODEL.Sample_Attachments> modellist = ViewModelArticleAttachment.ToArticleAttachmentList(HttpContext);
                //AttachmentsManager.DelBy(at => at.itemid == model.said);
                //foreach (var item in modellist)
                //{
                //        AttachmentsManager.Add(item);
                //}
                //if(model.published==1)
                //CreateStaticPage.CreateStaticByWebClient("ArticleDetails", new List<int>() { articel.saId });
                status = true;
            }
            catch (Exception e)
            {
              //  UserOperateLog.WriteOperateLog("[文章管理]修改文章:" + model.title + SysOperate.Update.ToMessage(status),e.ToString());
                return this.JsonFormat(status, status, e.Message);
            }
            //UserOperateLog.WriteOperateLog("[文章管理]修改文章:" + model.title + SysOperate.Update.ToMessage(status));
            return this.JsonFormat(model, status, SysOperate.Update);
        }
        [HttpPost]
        [ActionDesc("删除", "Y")]
        [Description("[企业门户]软删除企业门户")]
        public ActionResult Delete()
        {
            var status = false;
            var ids = HttpContext.Request["Ids"].Split(',').Select(id => TypeParser.ToInt32(id)).ToList();
            var model = new MODEL.MST_ARTICLE();
            model.SYNCOPERATION = "D";
            try
            {
                ArticleManager.ModifyBy(model, a => ids.Contains(a.ARTICLE_ID), "SYNCOPERATION");
                status = true;
            }
            catch (Exception e)
            {
               // UserOperateLog.WriteOperateLog("[文章管理]软删除文章:"+model.said + SysOperate.Delete.ToMessage(status),e.ToString());
                return this.JsonFormat(status, status, e.Message);
            }
           // UserOperateLog.WriteOperateLog("[文章管理]软删除文章:" + model.said + SysOperate.Delete.ToMessage(status));
            return this.JsonFormat(status, status, SysOperate.Delete);
        }
        [HttpPost]
        [ActionDesc("永久删除", "Y")]
        [Description("[企业门户]永久删除企业门户")]
        public ActionResult RealDelete()
        {
            var status = false;
            var model = new MODEL.MST_ARTICLE();
            model.ARTICLE_ID = TypeParser.ToInt32(HttpContext.Request["saId"]);
            try
            {
                ArticleManager.Del(model);
                status = true;
            }
            catch (Exception e)
            {
                //UserOperateLog.WriteOperateLog("[文章管理]真删除文章:" + model.said + SysOperate.Delete.ToMessage(status), e.ToString());
                return this.JsonFormat(status, status, e.Message);
            }
           // UserOperateLog.WriteOperateLog("[文章管理]真删除文章:" + model.said + SysOperate.Delete.ToMessage(status));
            return this.JsonFormat(status, status, SysOperate.Delete);
        }

        [ActionDesc("上传图片")]
        [Description("[企业门户]编辑器上传图片(Add,Update必须)")]
        public ActionResult UploadImg()
        {
            return Content(UploadRequestImg.CkSave(HttpContext));
        }
        [ActionDesc("上传附件")]
        [Description("[企业门户]附加上传图片(Add,Update必须)")]
        public ActionResult UploadImgAttachment()
        {
            return Content(UploadRequestImg.OneImageSave(HttpContext));
        }
        [ActionDesc("审核", "Y")]
        [Description("[企业门户]审核企业门户")]
        public ActionResult ApprovedMore()
        {
            var ids = HttpContext.Request["Ids"].Split(',').Select(id => TypeParser.ToInt32(id)).ToList();
            var model = new MODEL.MST_ARTICLE();
            model.ACTIVE = "Y";
            model.MODIFY_DT =model.SYNCVERSION= DateTime.Now;
            bool status = false;
            try
            {
                ArticleManager.ApprovedMoreArticle(ids);
                status = true;
               // CreateStaticPage.CreateStaticByWebClient("ArticleDetails", ids);
            }
            catch (Exception e)
            {
                //UserOperateLog.WriteOperateLog("[文章管理]批量审核文章" + SysOperate.Operate.ToMessage(status),e.ToString());
                return this.JsonFormat(status, status, SysOperate.Operate);
            }
            //UserOperateLog.WriteOperateLog("[文章管理]批量审核文章" + SysOperate.Operate.ToMessage(status));
            return this.JsonFormat(status, status, SysOperate.Operate);
        }
    }
}
