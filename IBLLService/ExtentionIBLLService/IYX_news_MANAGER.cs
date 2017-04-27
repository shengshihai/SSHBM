using MODEL.DataTableModel;
using MODEL.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface IYX_news_MANAGER : IBaseBLLService<MODEL.YX_news>
    {


        MODEL.ViewModel.VIEW_YX_news GetClickMenusNews(int eventId, string EventCate = "menu");

    }
}
