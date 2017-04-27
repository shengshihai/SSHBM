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

namespace MODEL.ViewModel
{
 
    /// <summary>
    /// 按钮数据类
    /// </summary>
    public class MyButton
    {
        /// <summary>
        /// 按钮ID
        /// </summary>
        public string BtnNo { get; set; }
        /// <summary>
        /// 按钮功能名称
        /// </summary>
        public string BtnName { get; set; }
        /// <summary>
        /// 按钮图标地址
        /// </summary>
        public string BtnIcon { get; set; }
        /// <summary>
        /// 点击事件(暂时停用)
        /// </summary>
        public string BtnClick { get; set; }
        /// <summary>
        /// 菜单标识
        /// </summary>
        public string MenuNo { get; set; }
     
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented,
  new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, });

        }
        /// <summary>
        /// 转化为按钮实体
        /// </summary>
        /// <param name="menu"></param>
        public static MyButton ToEntity(FW_PERMISSION menu)
        {
            MyButton item = new MyButton();

            item.BtnNo = menu.ACTIONNAME;
            item.BtnName = menu.NAME;
            item.BtnIcon = menu.ICON;
            item.BtnClick = menu.SCRIPT;
            return item;
        }
        
    }
}
