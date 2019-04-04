using MODEL.DataTableModel;
using MODEL.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface IVIEW_WeChatUser_MANAGER : IBaseBLLService<MODEL.VIEW_WeChatUser>
    {

        DataTableGrid GetWeChatUserForGrid(MODEL.DataTableModel.DataTableRequest request);

       

    }
}
