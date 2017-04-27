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
    public partial class YX_text_MANAGER : BaseBLLService<YX_text>, IYX_text_MANAGER
    {

        public VIEW_YX_text GetClickMenusText(int eventId, string EventCate = "menu")
        {
           return VIEW_YX_text.ToViewModel( base.Get(t => t.EventId == eventId && t.EventCate == EventCate));
        }
    }
}
