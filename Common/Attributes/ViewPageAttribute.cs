 /*  作者：       盛世
 *  创建时间：   2013/7/20 8:58:44
 *
 */
 /*  作者：       盛世海
 *  创建时间：   2013/7/19 22:15:05
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Attributes
{
    /// <summary>
    /// 表示当前Action请求为一个具体的功能页面
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ViewPageAttribute : Attribute
    {
    }
}