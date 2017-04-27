/*  作者：       盛世海
*  创建时间：   2012/7/27 19:01:58
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Attributes
{
    /// <summary>
    /// 控制器默认的首页
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ActionDescAttribute : Attribute
    {
        public string Name;
        public string isButton;
        public string isLink;
        public ActionDescAttribute(string Name, string isButton = "N", string isLink = "N")
        {
            this.Name = Name;
            this.isButton = isButton;
            this.isLink = isLink;
        }
    }
}
