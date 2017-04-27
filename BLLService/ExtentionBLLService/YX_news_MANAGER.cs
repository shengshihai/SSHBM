using Common;
using IBLLService;
using MODEL;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
    public partial class YX_news_MANAGER : BaseBLLService<YX_news>, IYX_news_MANAGER
    {

        public VIEW_YX_news GetClickMenusNews(int eventId, string EventCate = "menu")
        {
            return VIEW_YX_news.ToViewModel(base.Get(t => t.EventId == eventId && t.EventCate == EventCate));
        }
    }
}
