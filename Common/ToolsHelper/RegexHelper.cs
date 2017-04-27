using System.Text.RegularExpressions;

namespace Common
{
    /// <summary>
    /// 操作正则表达式的公共类
    /// </summary>    
    public class RegexHelper
    {
        #region 验证输入字符串是否与模式字符串匹配
        /// <summary>
        /// 验证输入字符串是否与模式字符串匹配，匹配返回true
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>        
        public static bool IsMatch(string input, string pattern)
        {
            return IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 验证输入字符串是否与模式字符串匹配，匹配返回true
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="options">筛选条件</param>
        public static bool IsMatch(string input, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(input, pattern, options);
        }
        #endregion


        public static string GetProductUrl(string productname,int pid)
        {
            string newurl="";
            string pattern = "\\s+";
            string replacement = " ";
            string oldurl = Regex.Replace(productname.Trim(), @"[^A-Za-z0-9]", replacement);
            oldurl = Regex.Replace(oldurl, pattern, replacement);
            oldurl = oldurl.Trim();
            string[] urls = oldurl.Split(' ');
            if (urls.Length > 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    newurl = newurl + urls[i] + "-";
                }
            }
            else 
            {
                foreach (var item in urls)
                {
                    newurl = newurl + item + "-";
                }
            }
            newurl = ConfigurationHelper.AppSetting("ReleaseProductUrl") + newurl.Substring(0, newurl.LastIndexOf('-')) + "_" + pid + ".html";
            return newurl;
        }
        public static string  GetSupplierUrl(string name, int id)
        {
            string newurl = "";
            string pattern = "\\s+";
            string replacement = " ";
            string oldurl = Regex.Replace(name.Trim(), @"[^A-Za-z0-9]", replacement);
            oldurl = Regex.Replace(oldurl, pattern, replacement);
            oldurl = oldurl.Trim();
            string[] urls = oldurl.Split(' ');
            if (urls.Length > 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    newurl = newurl + urls[i] + "-";
                }
            }
            else
            {
                foreach (var item in urls)
                {
                    newurl = newurl + item + "-";
                }
            }
            newurl = ConfigurationHelper.AppSetting("ReleaseSupplierUrl") + newurl.Substring(0, newurl.LastIndexOf('-')) + "_" + id + "/index.html";
            return newurl;
        }
        public static string GetNewsUrl(string newsname, int newsid)
        {
            string newurl = "";
            string pattern = "\\s+";
            string replacement = " ";
            string oldurl = Regex.Replace(newsname.Trim(), @"[^A-Za-z0-9]", replacement);
            oldurl = Regex.Replace(oldurl, pattern, replacement);
            oldurl = oldurl.Trim();
            string[] urls = oldurl.Split(' ');
            if (urls.Length > 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    newurl = newurl + urls[i] + "-";
                }
            }
            else
            {
                foreach (var item in urls)
                {
                    newurl = newurl + item + "-";
                }
            }
            newurl = ConfigurationHelper.AppSetting("ReleaseNewsUrl") + newurl.Substring(0, newurl.LastIndexOf('-')) + "_" + newsid + ".html";
            return newurl;
        }
    }
}
