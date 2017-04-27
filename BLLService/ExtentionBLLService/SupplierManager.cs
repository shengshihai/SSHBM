using Common;
using IBLLService;
using MODEL;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
    public partial class SupplierManager : ISupplierManager
    {
        public override int Add(supplier model)
        {
            idal.Add(model);
            IDBSession.SaveChanges();
            return model.sid;
        }
        public override int ModifyAll(supplier model)
        {
            foreach (var item in model.demonstrate)
            {
                if (item.did > 0)
                {
                    IDBSession.IDemonstrate_imageRepository.DelBy(d => d.did == item.did);
                    
                }
            }
            IDBSession.IDemonstrateRepository.DelBy(d => d.itemid == model.sid);
            idal.ModifyAll(model);
            return IDBSession.SaveChanges(); 
        }

        public EasyUIGrid GetAllSuppliers(MODEL.ViewModel.EasyUIGridRequest request)
        {
            int total = 0;
            return new EasyUIGrid()
            {
                rows = ViewModelSupplier.ToListViewModel(GetAllSuppliers(request, ref total)),
                total = total
            };
        }
        public IEnumerable<supplier> GetAllSuppliers(EasyUIGridRequest request, ref int Count)
        {
            var predicate = PredicateBuilder.True<supplier>();
            DateTime time = TypeParser.ToDateTime("1975-1-1");
            if (!string.IsNullOrEmpty(request.Where) && request.Where.Contains("searchmsg"))
            {
                var i = FilterHelper.GetParaValue("searchmsg", request.Where, "&*&");
                predicate = predicate.And(s => s.suppliername.Contains(i) || s.supplier_user.Contains(s.supplier_user.Where(su => su.username.Contains(i)).FirstOrDefault()) || s.supplier_user.Contains(s.supplier_user.Where(su => su.email.Contains(i)).FirstOrDefault()));
            }
            else if (!string.IsNullOrEmpty(request.Search))
            {
                var i = request.Search;
                if (i.ToLower().Contains("#region#"))
                {
                    var regionids = new List<int>();
                    var region = SampleUI.Helper.OperateContext.Current.BLLSession.IRegionManager.Get(r => r.regionname == i.ToLower().Replace("#region#", "").Trim());
                    if (region != null && region.parentid == 0)
                        regionids = SampleUI.Helper.OperateContext.Current.BLLSession.IRegionManager.LoadListBy(r => r.parentid == region.regionid).Select(r => r.regionid).ToList();
                    else if (region != null && region.parentid != 0)
                        regionids.Add(region.regionid);

                    predicate = predicate.And(s => regionids.Contains(s.city));

                }
                else
                {
                    predicate = predicate.And(s => s.suppliername.Contains(i) || s.supplier_user.Contains(s.supplier_user.Where(su => su.username.Contains(i)).FirstOrDefault()) || s.supplier_user.Contains(s.supplier_user.Where(su => su.email.Contains(i)).FirstOrDefault()));
                }
            }

            if (!string.IsNullOrEmpty(request.Where) && request.Where.Contains("check"))
            {
                var i = TypeParser.ToInt32(FilterHelper.GetParaValue("check", request.Where, "&*&"));
                predicate = predicate.And(s => s.ischeck == i);
            }
            return base.GetPagedList(request.PageNumber, request.PageSize, ref Count, predicate, s => s.createdate, false);
        }


        public int ApprovedMoreSupplier(List<int> ids)
        {
            var supplierlist = idal.GetListasNoTrackingBy(s => ids.Contains(s.sid)).OrderBy(s => s.createdate).ToList();
            foreach (var model in supplierlist)
            {
                model.ischeck = (int)SupplierEnum.SupplierCheckedEnum.Checked;
                model.url = RegexHelper.GetSupplierUrl(model.suppliername, model.sid);
                model.createdate = DateTime.Now;
                idal.Modify(model, "ischeck", "url");
            }
            return IDBSession.SaveChanges();
        }
    }
}
