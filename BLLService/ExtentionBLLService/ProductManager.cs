using Common;
using IBLLService;
using IDALRepository;
using MODEL;
using MODEL.ViewModel;
using SampleUI.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLLService
{
   
    public partial class ProductManager : BaseBLLService<product>, IProductManager
    {
        public MODEL.ViewModel.EasyUIGrid GetProductGrid(MODEL.ViewModel.DataTableRequest request)
        {
            try
            {

                var predicate = PredicateBuilder.True<product>();
             
                DateTime time = TypeParser.ToDateTime("1975-1-1");
               
                int total = 0;
                predicate = predicate.And(p => p.isdelete !=1);
                //if (!string.IsNullOrEmpty(request.Where) && request.Where.Contains("published"))
                //{
                //    var i=TypeParser.ToInt32(FilterHelper.GetParaValue("published",request.Where,"&*&"));
                //    predicate = predicate.And(p1 => p1.ispublish == i);
                //}
                //if (!string.IsNullOrEmpty(request.Where) && request.Where.Contains("check"))
                //{
                //    var i = TypeParser.ToInt32(FilterHelper.GetParaValue("check", request.Where, "&*&"));
                //    predicate = predicate.And(p2 => p2.ischeck == i);
                //}
                //if (!string.IsNullOrEmpty(request.Where) && request.Where.Contains("searchmsg"))
                //{
                //    var i = FilterHelper.GetParaValue("searchmsg", request.Where, "&*&");
                //    predicate = predicate.And(p1 => p1.productname.Contains(i) || p1.keyword.Contains(i) || p1.supplier.suppliername.Contains(i) || p1.product_category.categoryname.Contains(i));
                //}
                //else if (!string.IsNullOrEmpty(request.Search))
                //{
                //    var i = request.Search;
                //    predicate = predicate.Or(p1 => p1.productname.Contains(i)|| p1.keyword.Contains(i) || p1.supplier.suppliername.Contains(i) || p1.product_category.categoryname.Contains(i));
                //}
                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate,request.Model, p => true, request.SortOrder,request.SortName).Select(p => new ViewModelProduct()
                {
                    Pid = p.pid,
                    PcId = p.pcid,
                    SupplierId = p.supplierid.Value,
                    ProductName = p.productname,
                    IsPublish = p.ispublish.Value,
                    PublishDate = p.publishdate == null ? time : p.publishdate.Value,
                    IsHot = p.ishot.Value,
                    CreateDate = p.createdate == null ? time : p.createdate,
                    IsCheck = p.ischeck == null ? 0 : p.ischeck.Value,
                    Special = p.isspecial == null ? 0 : p.isspecial.Value,
                    SupplierName = p.supplier.suppliername
                });
                //var list = ViewModelProduct.ToListViewModel(data);
                return new MODEL.ViewModel.EasyUIGrid()
                {
                    draw=request.Draw,
                    rows = data,
                    total = total
                };
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public override int ModifyAll(product model)
        {
            IDBSession.IProduct_parameterRepository.DelBy(p => p.pid == model.pid);
            IDBSession.IProduct_imageRepository.DelBy(p => p.pid == model.pid);
            idal.ModifyAll(model);
            return IDBSession.SaveChanges();
        }


        /// <summary>
        /// 审核通过的
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int ApprovedMoreProduct(List<int> ids)
        {
           
            var productList = idal.GetListasNoTrackingBy(p => ids.Contains(p.pid)).ToList();
            foreach (var model in productList)
            {
                model.ischeck = (int)SupplierEnum.SupplierCheckedEnum.Checked;
                model.url = RegexHelper.GetProductUrl(model.productname, model.pid);
                model.reason = "";
                idal.Modify(model, "ischeck", "reason", "url");
            }
            return IDBSession.SaveChanges();
        }


      

       
    }
}
