 /*  作者：       盛世海
 *  创建时间：   2012/7/20 17:08:04
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using Newtonsoft.Json;
using System.Web;
using MODEL.ViewModel;

namespace MODEL.WeChat
{
    public partial class WeChatMenus : VIEW_YX_weiXinMenus_P
    {

        public static WeChatMenus ToViewModel(YX_weiXinMenus model)
        {
            WeChatMenus item = new WeChatMenus();
            item.Id = model.Id;
            item.WX_menuName = model.WX_menuName;
            item.WX_MenuType = model.WX_MenuType;
            item.WX_MenusKey_URL = model.WX_MenusKey_URL;
            item.WX_Fid = model.WX_Fid;
            item.WX_AddTime = model.WX_AddTime;
            item.remark1 = model.remark1;
            item.remark2 = model.remark2;
            item.remark3 = model.remark3;
            item.flat1 = model.flat1;
            item.flat2 = model.flat2;
            item.remark4 = model.remark4;
            item.remark5 = model.remark5;
            item.remark6 = model.remark6;
            item.flat7 = model.flat7;
            item.flat8 = model.flat8;
            item.RegTim1 = model.RegTim1;
            item.RegTim2 = model.RegTim2;
            return item;
        }

        public static IEnumerable<WeChatMenus> ToListViewModel(IEnumerable<YX_weiXinMenus> list)
        {
            var listModel = new List<WeChatMenus>();
            foreach (YX_weiXinMenus item in list)
            {
                listModel.Add(WeChatMenus.ToViewModel(item));
            }
            return listModel;
        }


    }
}
