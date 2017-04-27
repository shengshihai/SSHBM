using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Common
{
    public static class Controls
    {
        #region +获得功能页码条
        public static List<SelectListItem> GetIcons()
        {

            var cache = CacheHelper.GetCache("SystemIcons");
            if (cache != null)
            {
                return cache as List<SelectListItem>;
            }
            var rootPath = System.Web.HttpContext.Current.Server.MapPath("~/Content/back/css/");
            string dirPath = rootPath + "light-theme.css";

            var files = DirFile.GetLineValues(dirPath);
            var listFiles = new List<SelectListItem>();

            listFiles.Add(new SelectListItem() { Text = "请选择", Value = "", Selected=true });
            foreach (var file in files)
            {
                if (file.Contains(".icon-") && file.Contains(":before {"))
                {
                    var icon = file.Replace(".", "").Replace("{", "").Replace("}", "").Replace(":before ", "");
                    listFiles.Add(new SelectListItem() { Text = icon, Value = icon });
                }
            }
            //缓存一天吧
            CacheHelper.SetCache("SystemIcons", listFiles, new TimeSpan(24, 0, 0));
            return listFiles;
        }
 #endregion
        #region +获得功能页码条
        /// <summary>
        /// 获得功能页码条
        /// </summary>
        /// <param name="url">页码连接地址</param>
        /// <param name="searcheurl">搜索url</param>
        /// <param name="allrecord">全部记录条数</param>
        /// <param name="allpage">全部页面数</param>
        /// <param name="curpage">当前页码</param>
        /// <param name="groupsize">页码组大小</param>
        /// <param name="pagesize">页容量</param>
        public static  string GetPageTxt(string url, string searcheurl, int allrecord, int allpage, int curpage, int groupsize, int pagesize)
        {
            int curGroupPage = 0;
            StringBuilder test = new StringBuilder();
            StringBuilder test2 = new StringBuilder();
            StringBuilder pagetxt = new StringBuilder();
            if (curpage.Equals("") || curpage < 1) curpage = 1;
            if (allrecord.Equals("") || allrecord < 1) allrecord = 1;
            if (pagesize.Equals("") || pagesize < 1) pagesize = 1;
            if (allrecord == 0) { pagetxt.Append("页码：0/0 │ 共0条</TD> <td align='left'> 首页 << 上一页 | 1 Next | >> 尾页 &nbsp;&nbsp;</td></tr></table>"); }
            else
            {
                test2.Append(allpage.ToString());

                if (allpage.Equals("") || allpage < 1) allpage = 1;
                // pagetxt.Append("页码：" + curpage.ToString() + "/" + allpage.ToString() + " │ 共" + allrecord.ToString() + "条");
               // pagetxt.Append("<A href='" + url + "1' title='首页'>1</A>&nbsp;");
                curGroupPage = (((curpage - 1) / groupsize) * groupsize) + 1;

                if (curGroupPage <= 1) pagetxt.Append("<a href='" + url + curGroupPage + "" + searcheurl + "' title='回到首页'>&lt;&lt;</A>&nbsp;");
                else pagetxt.Append("<a href='" + url + (curGroupPage - 1) + "" + searcheurl + "' title='前 " + groupsize + " 页'>&lt;&lt;</A>&nbsp;");

                if (curpage <= 1) pagetxt.Append("<A href='" + url + curpage + "" + searcheurl + "' title='首页'>Prev</A>&nbsp;");
                else pagetxt.Append("<A href='" + url + (curpage - 1) + "" + searcheurl + "' title='前一页'>Prev</A>&nbsp;");

                int tempI = 0;
                tempI = curGroupPage;
                do
                {
                    if (tempI == curpage) pagetxt.Append("<span class='current'>" + tempI + "</span>&nbsp;");
                    else pagetxt.Append("<A href='" + url + tempI + "" + searcheurl + "'>" + tempI + "</A>&nbsp;");
                    tempI = tempI + 1;
                } while (tempI < curGroupPage + groupsize && tempI <= allpage);

                if (curpage < allpage) pagetxt.Append("<A href='" + url + (curpage + 1) + "" + searcheurl + "' title='后一页'>Next</A>&nbsp;");
                else pagetxt.Append("<A href='" + url + curpage + "" + searcheurl + "' title='后一页'>Next</A>&nbsp;");

                if (curGroupPage + groupsize > allpage) pagetxt.Append("<a href='" + url + allpage + "" + searcheurl + "' title='后 " + groupsize + " 页'>&gt;&gt;</A>&nbsp;");
                else pagetxt.Append("<a href='" + url + (curGroupPage + groupsize) + "" + searcheurl + "' title='后" + groupsize + "页'>&gt;&gt;</A>&nbsp;");

               // pagetxt.Append("<A href='" + url + allpage + "" + searcheurl + "' title='最后一页'>" + allpage + "</A>");
            }
            test.Append("allpage=" + allpage + ",allrecord=" + allrecord + ",pagesize=" + pagesize + ",groupsize=" + groupsize + ",curGroupPage=" + curGroupPage + ",curpage=" + curpage);
            return pagetxt.ToString();
        }
        #endregion

        public static string GetSrcByRegular(string str)
        {
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
           // Regex regImg = new Regex(@"<img.*?src=""(?<src>[^""]*)""[^>]*>", RegexOptions.IgnoreCase);
            // 搜索匹配的字符串 
            MatchCollection matches = regImg.Matches(str);

            StringBuilder strImage = new StringBuilder();

            // 取得匹配项列表 
            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    strImage.Append(m.Groups["imgUrl"].Value).Append(' ');

                }
            }

            return strImage.ToString();
        }
        public static string GetHrefByRegular(string str)
        {
            Regex regImg = new Regex(@"<a\b[^<>]*?\bhref[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<Href>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            // Regex regImg = new Regex(@"<img.*?src=""(?<src>[^""]*)""[^>]*>", RegexOptions.IgnoreCase);
            // 搜索匹配的字符串 
            MatchCollection matches = regImg.Matches(str);

            StringBuilder strImage = new StringBuilder();

            // 取得匹配项列表 
            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    strImage.Append(m.Groups["Href"].Value).Append(' ');

                }
            }

            return strImage.ToString();
        }
    }
}
