using MODEL.DataTableModel;
using MODEL.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface IYX_text_MANAGER : IBaseBLLService<MODEL.YX_text>
    {


        MODEL.ViewModel.VIEW_YX_text GetClickMenusText(int eventId, string EventCate = "menu");

    }
}
