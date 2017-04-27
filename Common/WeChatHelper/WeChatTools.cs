using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    /// <summary>
    /// 共用工具类
    /// </summary>
    public static class WeChatTools
    {
        #region 获取access_token

        //public static string IsExistAccess_Token2()
        //{
        //    string AccessToken = "";
        //    object Access_Token = CacheHelper.GetCache("Access_Token");//设置主菜单缓存  防止多次访问数据库V1003_TODAY_MUSIC
        //    if (Access_Token != null)
        //    {
        //        DateTime Tim = DateTime.Now;
        //        string getsql = "select count(1) from TokenConfig where Id=1 and '" + Tim + "'>Tim";
        //        object o = imp.GetSqlOne(CommandType.Text, getsql);
        //        if (o.ToString().Trim() == "0")
        //        {
        //            AccessToken = Access_Token.ToString();
        //        }
        //        else
        //        {
        //            AccessToken = FirstAccess_Token(GetKeyValue("appid"), GetKeyValue("appsecret"));//重新获取Access_Token
        //            CacheHelper.SetCache("Access_Token", AccessToken, TimeSpan.FromMinutes(120));
        //            string sql = "update TokenConfig set Tim='" + DateTime.Now.AddMinutes(3) + "'";
        //            imp.GetSqlCount(CommandType.Text, sql);
        //        }
        //    }
        //    else
        //    {
        //        AccessToken = FirstAccess_Token(GetKeyValue("appid"), GetKeyValue("appsecret"));//重新获取Access_Token
        //        CacheHelper.SetCache("Access_Token", AccessToken, TimeSpan.FromMinutes(120));
        //        string sql = "update TokenConfig set Tim='" + DateTime.Now.AddMinutes(45) + "'";
        //        imp.GetSqlCount(CommandType.Text, sql);
        //    }
        //    LogHelper.WriteLog("最新的TOKEN：" + AccessToken);
        //    return AccessToken;
        //}
        /// <summary>
        /// 获取access_tokenaccess_token有效期目前为2个小时，需要定时去刷新，当调用微信公众平台的其他接口时，如果返回数值是：40001，即：获取access_token时AppSecret错误，或者access_token无效时，从新生成access_token
        /// </summary>
        /// <param name="Url"></param>
        public static string FirstAccess_Token(string appid, string Appsecret)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + Appsecret + "");
            req.Method = "GET";
            using (WebResponse wr = req.GetResponse())
            {
                HttpWebResponse myResponse = (HttpWebResponse)req.GetResponse();

                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);

                string Access_TokenJson = reader.ReadToEnd();  //获取的Json数据
                JObject obj = JObject.Parse(Access_TokenJson);
                string accessToken = obj["access_token"].ToString();
                return accessToken;
            }
        }
        #endregion
    }
}
