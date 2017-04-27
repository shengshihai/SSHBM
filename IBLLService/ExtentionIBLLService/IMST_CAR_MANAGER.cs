using MODEL.DataTableModel;
using MODEL.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface IMST_CAR_MANAGER : IBaseBLLService<MODEL.MST_CAR>
    {

        DataTableGrid GetCarForGrid(MODEL.DataTableModel.DataTableRequest request);

    }
}
