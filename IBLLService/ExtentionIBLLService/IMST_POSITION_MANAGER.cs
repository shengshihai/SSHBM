using MODEL;
using MODEL.DataTableModel;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface IMST_POSITION_MANAGER : IBaseBLLService<MST_POSITION>
    {


        DataTableGrid GetPositionGrid(MODEL.DataTableModel.DataTableRequest request);

    }
}
