using MODEL.DataTableModel;
using MODEL.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface IYX_weiXinMenus_MANAGER : IBaseBLLService<MODEL.YX_weiXinMenus>
    {

        DataTableGrid GetWeChatMenusForGrid(MODEL.DataTableModel.DataTableRequest request);

        List<WeChatMenus> GetMainMenus();

        List<WeChatMenus> GetChildMenus();

        List<WeChatMenus> GetClickMenus();

        DataTableGrid GetWeChatMsgSetForGrid(MODEL.DataTableModel.DataTableRequest request);
    }
}
