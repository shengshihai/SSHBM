using MODEL.DataTableModel;
using MODEL.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface IYX_weiUser_MANAGER : IBaseBLLService<MODEL.YX_weiUser>
    {

        DataTableGrid GetWeChatUserForGrid(MODEL.DataTableModel.DataTableRequest request);

        int ChargeMoney( MODEL.TG_transactionLog log, MODEL.YX_weiUser model, params string[] proNames);

    }
}
