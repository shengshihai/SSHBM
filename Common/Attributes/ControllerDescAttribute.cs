 /*  作者：       盛世海
 *  创建时间：   2013/8/5 19:04:21
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Attributes
{
    /// <summary>
    /// UI异常返回
    /// </summary>
      [AttributeUsage(AttributeTargets.Method)]
    public class ControllerDescAttribute : Attribute
    {
         public string Name;
        public bool isMenu;
        public bool isLink;
        public ControllerDescAttribute(string Name, bool isMenu = true, bool isLink = false)
        {
            this.Name = Name;
            this.isMenu = isMenu;
            this.isLink = isLink;
        }
    }
}
