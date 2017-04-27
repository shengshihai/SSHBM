using MODEL.DataTableModel;
using MODEL.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface ITG_order_MANAGER : IBaseBLLService<MODEL.TG_order>
    {

        DataTableGrid GetOrderForGrid(MODEL.DataTableModel.DataTableRequest request);
        bool DownOrder(MODEL.ViewModel.VIEW_TG_order order);
    }
}
