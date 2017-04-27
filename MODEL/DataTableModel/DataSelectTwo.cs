 /*  作者：       盛世海
 *  创建时间：   2012/7/21 9:19:53
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MODEL.DataTableModel
{
    public class DataSelectTwo
    {

       /// <summary>
       /// 返回的记录
       /// </summary>
       public object results { get; set; }
       /// <summary>
       /// 总个数
       /// </summary>
       public int total { get; set; }
       public override string ToString()
       {
           return JsonConvert.SerializeObject(this, Formatting.Indented,
 new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, });

       }
    }
}
