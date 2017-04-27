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
    public partial class ProductPropertySetupManager : IProductPropertySetupManager
    {

        public EasyUIGrid GetPropertyByCategoryIdForGrid(int categoryid, EasyUIGridRequest request)
        {
            int total = 0;
            return new EasyUIGrid()
            {
                rows = GetPropertyByCIdForGrid(request, categoryid, ref total),
                total = total
            };
        }
        public IEnumerable<ProductPropertySetup> GetPropertyByCIdForGrid(EasyUIGridRequest request, int categoryid, ref int Count)
        {
            return base.GetPagedList( request.PageNumber, request.PageSize,ref Count, r => r.forderId == categoryid, r => r.orderNum);
        }
    }
}
