 /*  作者：       盛世海
 *  创建时间：   2012/7/27 10:22:21
 *
 */
 /*  作者：       盛世海
 *  创建时间：   2012/7/21 10:28:04
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MODEL.ViewPage
{
    /// <summary>
    /// 查看明细的具体视图
    /// </summary>
   public class ViewDetailPage
    {
       /// <summary>
        /// 当前ID
       /// </summary>
       public string CurrentID { get; private set; }
       /// <summary>
       /// 当前ID
       /// </summary>
       public string ParentID { get; private set; }
       /// <summary>
       /// 是否查看
       /// </summary>
       public int IsView { get; private set; }
       public ViewDetailPage(HttpContextBase context)
       {
           ParentID = context.Request["ParentID"];
           CurrentID = context.Request["ID"];
           IsView = (context.Request["IsView"] == "1") ? 1 : 0;
       }
    }
}
