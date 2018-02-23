using MODEL;
using MODEL.DataTableModel;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface IMST_PRD_MANAGER : IBaseBLLService<MST_PRD>
    {


        DataTableGrid GetProductsForGrid(MODEL.DataTableModel.DataTableRequest request);
        DataTableGrid GetProductsForHot();

    }
}
