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
using MODEL.DataTableModel;

namespace ShengUI.Logic.Admin
{
    public class CatalogController : Controller
    {
        public IMST_CATALOG_MANAGER CatalogManager = OperateContext.Current.BLLSession.IMST_CATALOG_MANAGER;
          

        [DefaultPage]
        [ActionParent]
        [ActionDesc("企业分类")]
        [Description("[企业分类]企业分类管理")]
        public ActionResult CatalogInfo()
        {

            //UserOperateLog.WriteOperateLog("[文章分类管理]浏览文章分类视图"  + SysOperate.Load.ToMessage(true));
            return View();
        }

        /// <summary>
        /// 请求文章分类列表信息
        /// </summary>
        /// <returns></returns>        
        [ActionDesc("获取企业分类Grid数据")]
        [Description("[企业分类]获取企业分类列表信息(返回Grid)(主页必须)")]
        public ActionResult GetCatalogForGrid()
        {

            DataTableRequest request = new DataTableRequest(HttpContext);
            return this.JsonFormat(CatalogManager.GetCatalogGridTree(request));
        }

        /// <summary>
        /// 请求文章分类列表信息
        /// </summary>
        /// <returns></returns>

        [ActionDesc("获取企业分类TreeGrid数据")]
        [Description("[企业分类]获取企业分类列表信息(返回TreeGrid)(主页必须)")]
        public ActionResult GetCatalogTree()
        {
            DataTreeRequest request = new DataTreeRequest(HttpContext);
            return this.JsonFormat(CatalogManager.GetCatalogTree(request));
        }
        [ActionDesc("企业分类信息")]
        [Description("[企业分类]企业分类信息")]
        public ActionResult CatalogDetail(string id)
        {
            ViewBag.TYPE = "Add";
            var model = CatalogManager.Get(m => m.CATALOG_CD == id);
            if (model == null)
            {
                return View(new VIEW_MST_CATALOG());
            }
            ViewBag.TYPE = "Update";
            return View(VIEW_MST_CATALOG.ToViewModel(model));
        }
        //添加文章分类]
        [ActionDesc("添加", "Y")]
        [Description("[企业分类]添加企业分类")]
        public ActionResult Add(VIEW_MST_CATALOG model)
        {
            var status = false;
            //1.2服务器端验证，如果没有验证通过
            if (!ModelState.IsValid)
            {
                return this.JsonFormat(ModelState, false, "ERROR");
                // return OperateContext.Current.RedirectAjax("err", "没有权限!", null, "");
            }
            //获取请求信息
            try
            {
                model.CATALOG_PCD = "";
                CatalogManager.Add(VIEW_MST_CATALOG.ToEntity(model));
                status = true;
            }
            catch (Exception e)
            {
               // UserOperateLog.WriteOperateLog("[文章分类管理]添加文章分类:" + model .title+ SysOperate.Add.ToMessage(status), e.ToString());
                return this.JsonFormat(status, status,SysOperate.Add);
            }
           // UserOperateLog.WriteOperateLog("[文章分类管理]添加文章分类:"+ model .title + SysOperate.Add.ToMessage(status));
            return this.JsonFormat("/Admin/Catalog/CatalogInfo", status, SysOperate.Add.ToMessage(status), status);
        }
        //更新文章分类信息
        [ActionDesc("编辑", "Y")]
        [Description("[企业分类]编辑企业分类")]
        public ActionResult Update(VIEW_MST_CATALOG model)
        {
            var status = false;
            //1.2服务器端验证，如果没有验证通过
            if (!ModelState.IsValid)
            {
                return this.JsonFormat(ModelState, false, "ERROR");
                // return OperateContext.Current.RedirectAjax("err", "没有权限!", null, "");
            }
            try
            {
                CatalogManager.Modify(VIEW_MST_CATALOG.ToEntity(model), "NAME", "PREVIEW", "REMARK");
                status = true;
            }
            catch (Exception e)
            {
                return this.JsonFormat(status, status, SysOperate.Update);
            }
            return this.JsonFormat("/Admin/Catalog/CatalogInfo", status, SysOperate.Update.ToMessage(status), status);
        }
        

    }
}
