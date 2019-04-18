using MODEL.DataTableModel;
using MODEL.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface ITG_TXmoney_MANAGER : IBaseBLLService<MODEL.TG_TXmoney>
    {

        DataTableGrid GetCashForGrid(MODEL.DataTableModel.DataTableRequest request);
    }
}
