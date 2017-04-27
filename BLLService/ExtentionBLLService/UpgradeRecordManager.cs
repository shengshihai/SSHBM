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

    public partial class UpgradeRecordManager : BaseBLLService<UpgradeRecord>, IUpgradeRecordManager
    {
        public MODEL.ViewModel.EasyUIGrid GetUpgradeRecordGrid(MODEL.ViewModel.DataTableRequest request)
        {
            try
            {

                var predicate = PredicateBuilder.True<UpgradeRecord>();
             
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
                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName);
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
            var upgradecodes = new List<string>();
            foreach (var model in productList)
            {
                if (model.status != 1)
                {
                    upgradecodes.Add(model.upgradecode);
                    var account = IDBSession.IAccountRepository.GetModelWithOutTrace(a => a.objectid == model.getcode);
                    if (account == null)
                    {
                        account = new account();
                        account.objectid = model.getcode;
                        account.objecttype = 1;
                        account.bank = "";
                        account.card = "";
                        account.funds = model.price;
                        account.paypal = "";
                        account.allfunds = model.price;
                        account.frozenfunds = 0;
                        OperateContext.Current.BLLSession.IAccountManager.Add(account);
                    }
                    var accountRecord = new MODEL.accountRecord();
                    accountRecord.aid = account.aid;
                    accountRecord.membercode = model.getcode;
                    accountRecord.membername = model.getname;
                    accountRecord.money = model.price;
                    accountRecord.typefund = 1;
                    accountRecord.status = 1;
                    accountRecord.createdate = DateTime.Now;
                    accountRecord.finishdate = DateTime.Now;
                    IDBSession.IAccountRecordRepository.Add(accountRecord);
                    account.funds = account.funds +model.price;
                    account.allfunds = account.allfunds + model.price;
                    IDBSession.IAccountRepository.Modify(account, "funds", "allfunds");
                }
                model.status = (int)SupplierEnum.SupplierCheckedEnum.Checked;
                model.finishdate = DateTime.Now;
                idal.Modify(model, "status", "finishdate");
                
            }
            var memberlist = IDBSession.IMemberRepository.GetListasNoTrackingBy(m => upgradecodes.Contains(m.code));
            foreach (var item in memberlist)
            {
                var upgradelevel = item.levelid + 1;
                if (upgradelevel <= 0)
                    upgradelevel = 1;
                else if (upgradelevel > 8)
                    upgradelevel = 8;
                item.isusable = 1;
                item.levelid = upgradelevel;
                item.activedate = DateTime.Now;
                IDBSession.IMemberRepository.Modify(item, "isusable", "levelid", "activedate");
             
            }
            return IDBSession.SaveChanges();
        }


      

       
    }
}
