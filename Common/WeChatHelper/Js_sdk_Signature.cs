using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml;
using System.Web.Security;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization.Json;

namespace Common
{
    //Js SDK数字签名算法  生成签名 用户JS分享等其他功能
    public class Js_sdk_Signature
    {
        #region 获取Js_SDK接口凭据Ticket
        /// <summary>
        /// 获取Js_SDK接口凭据{
            //"errcode":0,
            //"errmsg":"ok",
            //"ticket":"bxLdikRXVbTPdHSM05e5u5sUoXNKd8-41ZO3MhKoyN5OfkWITDGgnr2fwJ0m9E8NYzWKVZvdVtaUgWvsdshFKA",
            //"expires_in":7200
            //}
        /// </summary>
        /// <returns></returns>
        public static string Getjsapi_ticket(string AccessTocken)
        {
            string CommUrl = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + AccessTocken + "&type=jsapi";
            string content = Tools.GetPage(CommUrl, "");
            string ticket = Tools.GetJsonValue(content, "ticket");
            string errmsg = Tools.GetJsonValue(content, "errmsg");
            string errcode = Tools.GetJsonValue(content, "errcode");
            //LogHelper.WriteLog("errcode：" + errcode);
            //LogHelper.WriteLog("errmsg：" + errmsg);
            return ticket;
        }

        public static string IsExistjsapi_ticket(string Access_Token)
        {
            
            string Ticket = "";
            object JSAPI_Ticket = CacheHelper.GetCache("JSAPI_Ticket");//设置主菜单缓存  防止多次访问数据库V1003_TODAY_MUSIC
            if (JSAPI_Ticket != null)
            {
                Ticket = JSAPI_Ticket.ToString();
            }
            else
            {
                Ticket = Getjsapi_ticket(Access_Token);//重新获取Access_Token
                CacheHelper.SetCache("JSAPI_Ticket", Ticket, TimeSpan.FromMinutes(120));
            }
            return Ticket;
        }
        #endregion

        #region 获取Js_SDK接口签名
        /// <summary>
        /// 获取Js_SDK接口签名
        /// </summary>
        /// <param name="noncestr">随机字符串 16位</param>
        /// <param name="jsapi_ticket">凭据Ticket</param>
        /// <param name="timestamp">时间戳1429677330我的QQ号  嘻嘻</param>
        /// <param name="url">页面的URL地址：http://www.XXXXXX.com/index.aspx</param>
        /// <returns>以下为相关参数取值</returns>
        //noncestr = CommonMethod.GetCode(16);
        //string jsapi_ticket = qiaojiaren.CommonCS.Js_sdk_Signature.IsExistjsapi_ticket();
        //timestamp = DateTime.Now.Ticks.ToString().Substring(0, 10);;
        //string url = Request.Url.ToString().Replace("#", "");

        public static string GetjsSDK_Signature(string noncestr, string jsapi_ticket, string timestamp, string url)
        {
            string tmpStr = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", jsapi_ticket, noncestr, timestamp, url);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            return tmpStr;
        }


        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>double</returns>  
        public int ConvertDateTimeInt(System.DateTime time)
        {
            int intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = Convert.ToInt32((time - startTime).TotalSeconds);
            return intResult;
        }
        #endregion

        #region 序列化反序列化
        /// <summary>  
        /// 反序列化 字符串到对象  
        /// </summary>  
        /// <param name="obj">泛型对象</param>  
        /// <param name="str">要转换为对象的字符串</param>  
        /// <returns>反序列化出来的对象</returns>  
        public static T Desrialize<T>(T obj, string str)
        {
            try
            {
                var mStream = new MemoryStream(Encoding.Default.GetBytes(str));
                var serializer = new DataContractJsonSerializer(typeof(T));
                T readT = (T)serializer.ReadObject(mStream);


                return readT;
            }
            catch (Exception ex)
            {
                return default(T);
                throw new Exception("反序列化失败,原因:" + ex.Message);
            }

        }


        /// <summary>  
        /// 序列化 对象到字符串  
        /// </summary>  
        /// <param name="obj">泛型对象</param>  
        /// <returns>序列化后的字符串</returns>  
        public static string Serialize<T>(T obj)
        {
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                var stream = new MemoryStream();
                serializer.WriteObject(stream, obj);


                byte[] dataBytes = new byte[stream.Length];


                stream.Position = 0;


                stream.Read(dataBytes, 0, (int)stream.Length);


                string dataString = Encoding.UTF8.GetString(dataBytes);
                return dataString;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("序列化失败,原因:" + ex.Message);
            }
        }

        /// <summary>  
        /// StreamWriter写入文件方法  
        /// </summary>  
        private void StreamWriterMetod(string str, string patch)
        {
            try
            {
                FileStream fsFile = new FileStream(patch, FileMode.OpenOrCreate);
                StreamWriter swWriter = new StreamWriter(fsFile);
                //寫入數據  
                swWriter.WriteLine(str);
                swWriter.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //SHA1哈希加密算法  
        public string SHA1_Hash(string str_sha1_in)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = System.Text.UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "").ToLower();
            return str_sha1_out;
        }

        #region 获取时间戳
        /// <summary>
        /// 时间戳
        /// </summary>
        /// <returns></returns>
        public static string getTimestamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public static string getTimeStamp()
        {
            return DateTime.Now.Ticks.ToString().Substring(0, 10); ;
        }
        #endregion
        #endregion

        #region 获取卡券Js_SDK接口凭据tickct
        /// <summary>
        /// 获取卡券Js_SDK接口凭据tickct
        /// </summary>
        /// <returns></returns>
        public static string GetCardjsapi_ticket(string AccessTocken)
        {
            string CommUrl = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + AccessTocken + "&type=wx_card";
            string content = Tools.GetPage(CommUrl, "");
            string ticket = Tools.GetJsonValue(content, "ticket");
            return ticket;
        }

        public static string IsExistCardticket(string Access_Token)
        {

            string Ticket = "";
            object Card_Ticket = CacheHelper.GetCache("Card_Ticket");//设置主菜单缓存  防止多次访问数据库V1003_TODAY_MUSIC
            if (Card_Ticket != null)
            {
                Ticket = Card_Ticket.ToString();
            }
            else
            {
                Ticket = Getjsapi_ticket(Access_Token);//重新获取Access_Token
                CacheHelper.SetCache("Card_Ticket", Ticket, TimeSpan.FromMinutes(120));
            }
            return Ticket;

        }
        #endregion

        #region 获取卡券领取接口签名
        /// <summary>
        /// 获取卡券领取接口签名
        /// </summary>
        /// <param name="api_ticket">卡券Js_SDK接口凭据tickct 参考：GetCardjsapi_ticket()</param>
        /// <param name="card_id">卡券Id</param>
        /// <param name="timestamp">时间戳  从1970年算起</param>
        /// <returns></returns>
        public static string GetCardSignature(string api_ticket, string card_id,string timestamp)
        {
            string tmpStr = timestamp + api_ticket + card_id;
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            return tmpStr.ToLower();
        }
        #endregion
    }
}