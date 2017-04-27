using MODEL;
using MODEL.DataTableModel;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface IFW_MODULE_MANAGER : IBaseBLLService<FW_MODULE>
    {


        DataTableGrid GetMenusForGrid(MODEL.DataTableModel.DataTableRequest request);

    }
}
