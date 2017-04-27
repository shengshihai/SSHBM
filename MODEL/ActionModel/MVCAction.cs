 /*  作者：       盛世海
 *  创建时间：   2012/7/19 20:18:25
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.ActionModel
{
    /// <summary>
    /// 动作
    /// </summary>
   public class MVCAction
    {
        /// <summary>
        /// CD
        /// </summary>
        public string CD { get; set; }
        /// <summary>
        ///PCD
        /// </summary>
        public string PCD { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 动作
        /// </summary>
        public string ActionName { get; set; }
       /// <summary>
       /// 控制器
       /// </summary>
       public string ControllerName { get; set; }
       /// <summary>
       /// 描述
       /// </summary>
       public string Description { get; set; }
       /// <summary>
       /// 链接地址
       /// </summary>
       public string LinkUrl { get; set; }
       /// <summary>
       /// 是否Button
       /// </summary>
       public string IsButton { get; set; }
       /// <summary>
       /// 是否Link
       /// </summary>
       public string IsLink { get; set; }
       /// <summary>
       /// 是否Parent
       /// </summary>
       public bool IsParent { get; set; }

    }
}
