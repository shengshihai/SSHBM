 /*  作者：       盛世海
 *  创建时间：   2012/7/27 10:22:41
 *
 */
 /*  作者：       盛世海
 *  创建时间：   2012/7/27 10:21:40
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MODEL.ViewPage
{
   public class ViewSelectParamPage
    {
       public string ControllerName { get; set; }
       public string MenuID { get; set; }
       public ViewSelectParamPage(HttpContextBase context)
       {
           ControllerName = context.Request["controllerName"];
           MenuID = context.Request["MenuID"];
       }
    }
}
