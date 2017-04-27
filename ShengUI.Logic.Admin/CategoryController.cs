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
using System.Threading;
using MODEL.DataTableModel;

namespace ShengUI.Logic.Admin
{
       [Description("产品分类管理")]
    public class CategoryController : Controller
    {


           public IMST_CATEGORY_MANAGER CategoryB = OperateContext.Current.BLLSession.IMST_CATEGORY_MANAGER;
        [DefaultPage]
        [ActionParent]
        [ActionDesc("产品分类")]
        [Description("[产品分类]产品分类")]
        public ActionResult PrdCateIndex()
        {
            return View();
        }


        [ActionDesc("产品分类详细")]
        [Description("[产品分类]产品分类详细")]
        public ActionResult PrdCateDetail(string cd)
        {
            ViewBag.TYPE = "Add";
            var model = CategoryB.Get(m => m.CATE_CD == cd);
            if (model == null)
            {
                return View(new VIEW_MST_CATEGORY());
            }
            ViewBag.TYPE = "Update";
            model.VERSION = model.VERSION + 1;
            return View(VIEW_MST_CATEGORY.ToViewModel(model));
        }


        /// <summary>
        /// 请求权限功能列表信息
        /// </summary>
        /// <returns></returns>
        ///       
        [ActionDesc("产品分类列表信息")]
        [Description("[产品分类Ajax请求]产品分类列表信息(返回Grid)(主页必须)")]
        public ActionResult GetProductCategoryForGrid()
        {
            DataTableRequest request = new DataTableRequest(HttpContext);
            return this.JsonFormat(CategoryB.GetCategoryGridTree(request));
        }
        [ActionDesc("添加","Y")]
        [Description("[产品分类]添加产品分类")]
        public ActionResult Add(VIEW_MST_CATEGORY model)
        {
             bool status = false;
             if (!ModelState.IsValid)
                 return this.JsonFormat(ModelState, status, "ERROR");
             try
             {
                 model.PARENT_CD = "MAIN";
                 model.CREATE_DT = DateTime.Now;
                 model.VERSION = 1;
                 model.MODIFY_DT = DateTime.Now;
                 model.SYNCVERSION = DateTime.Now;
                 model.SYNCOPERATION = "A";
                 CategoryB.Add(VIEW_MST_CATEGORY.ToEntity(model));
                 status = true;
             }
             catch (Exception e)
             {
                   
                   return this.JsonFormat(status, status, SysOperate.Add);
             }
             return this.JsonFormat("/admin/category/PrdCateIndex", status, SysOperate.Add.ToMessage(status), status);

        }
        [ActionDesc("修改", "Y")]
        [Description("[产品分类]修改产品分类")]
        public ActionResult Update(VIEW_MST_CATEGORY model)
        {

            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, status, "ERROR");
            try
            {
                model.MODIFY_DT = DateTime.Now;
                model.SYNCVERSION = DateTime.Now;
                model.SYNCOPERATION = "U";
                if(CategoryB.Modify(VIEW_MST_CATEGORY.ToEntity(model), "CATEGORY_NAME", "ISSHOW", "ACTIVE", "ISLEAVES", "ISHOT", "VERSION", "MODIFY_DT", "SYNCVERSION", "SYNCOPERATION", "REMARK1")>=1)
                status = true;
            }
            catch (Exception e)
            {

                return this.JsonFormat(status, status, SysOperate.Update);
            }

            return this.JsonFormat("/admin/category/PrdCateIndex", status, SysOperate.Update.ToMessage(status), status);

        }
         [ActionDesc("删除", "Y")]
        [Description("[产品分类]软删除产品分类")]
        public ActionResult Delete()
        {
            
         
            bool status = false ;
            try
            {
                status = true;
            }
            catch (Exception e)
            {

                return this.JsonFormat(status, status, SysOperate.Update);
            }
            return this.JsonFormat(status, status, SysOperate.Delete);

        }

         [ActionDesc("永久删除", "Y")]
        [Description("[产品分类]永久删除产品分类")]
        public ActionResult RealDelete()
        {

            bool status = false;
            try
            {
                status = true;
            }
            catch (Exception e)
            {
              
                return this.JsonFormat(status, status, SysOperate.Update);
            }
            return this.JsonFormat(status, status, SysOperate.Delete);
        }


    }
}
