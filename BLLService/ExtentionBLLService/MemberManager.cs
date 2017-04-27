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
    public partial class MemberManager : IMemberManager
    {


        public EasyUIGrid GetAllSuppliers(MODEL.ViewModel.DataTableRequest request)
        {
            int total = 0;
            return new EasyUIGrid()
            {
                rows = GetAllSuppliers(request, ref total),
                total = total
            };
        }
        public IEnumerable<Member> GetAllSuppliers(DataTableRequest request, ref int Count)
        {
            var predicate = PredicateBuilder.True<Member>();

            DateTime time = TypeParser.ToDateTime("1975-1-1");

        
            predicate = predicate.And(p => p.isdelete == 0);

            var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref Count, predicate, request.Model, p => p.isdelete == 0, request.SortOrder, request.SortName);
            //var list = ViewModelProduct.ToListViewModel(data);
            return data;
        }


        public int ApprovedMoreSupplier(List<int> ids)
        {
           
            return 1;
        }
    }
}
