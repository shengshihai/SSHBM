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
    public partial class Supplier_userManager : ISupplier_userManager
    {
        public EasyUIGrid GetAllSupplierUsers(MODEL.ViewModel.EasyUIGridRequest request)
        {
            int total = 0;
            return new EasyUIGrid()
            {
                rows = ViewModelSupplierUser.ToListViewModel(GetAllSupplierUsers(request, ref total)),
                total = total
            };
        }
        public IEnumerable<supplier_user> GetAllSupplierUsers(EasyUIGridRequest request, ref int Count)
        {
           
            return base.GetPagedList(request.PageNumber, request.PageSize, ref Count, su => su.sid==request.ParentId,su=>su.createdate,false);
        }
    }
}
