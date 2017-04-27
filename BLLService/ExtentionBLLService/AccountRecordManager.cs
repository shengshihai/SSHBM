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

    public partial class AccountRecordManager : BaseBLLService<accountRecord>, IAccountRecordManager
    {
        public MODEL.ViewModel.EasyUIGrid GetaccountRecordGrid(MODEL.ViewModel.DataTableRequest request)
        {
            try
            {

                var predicate = PredicateBuilder.True<accountRecord>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");

                int total = 0;
                predicate = predicate.And(p => p.typefund == 2);
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
                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName).Select(p => new ViewModelAccountRecord()
                {
                    id = p.id,
                    aid = p.aid,
                    typefund = p.typefund,
                    money = p.money,
                    membername = p.membername,
                    status = p.status,
                    createdate = p.createdate,
                    finishdate = p.finishdate,
                    membercode = p.membercode,
                    payaddress=p.Member.payaddress,
                    paycode = p.Member.paycode,
                    payname = p.Member.payname,
                    paybank = p.Member.paybank,
                   // paybao = p.Member.paybao
                });
                //var list = ViewModelProduct.ToListViewModel(data);
                return new MODEL.ViewModel.EasyUIGrid()
                {
                    draw = request.Draw,
                    rows = data,
                    total = total
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public override int ModifyAll(product model)
        //{
        //   // IDBSession.IProduct_parameterRepository.DelBy(p => p.pid == model.pid);
        //   // IDBSession.IProduct_imageRepository.DelBy(p => p.pid == model.pid);
        //    //idal.ModifyAll(model);
        //    return IDBSession.SaveChanges();
        //}


        /// <summary>
        /// 审核通过的
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int ApprovedMoreProduct(List<int> ids)
        {

            var productList = idal.GetListasNoTrackingBy(p => ids.Contains(p.id)).ToList();
            foreach (var model in productList)
            {
                model.status = (int)SupplierEnum.SupplierCheckedEnum.Checked;
                model.finishdate = DateTime.Now;
                idal.Modify(model, "status", "finishdate");
            }
            return IDBSession.SaveChanges();
        }





    }
}
