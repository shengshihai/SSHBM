using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace ShengUI.Helper.payCls
{
    public class NativeCs
    {
        #region 获取二维码字符串
        /// <summary>
        /// 生成二维码字符串
        /// </summary>
        /// <param name="productid">商品ID</param>
        /// <param name="nonce_str">随机字符串</param>
        /// <param name="time_stamp">时间戳</param>
        /// <returns></returns>
        public static string CreateQRCodeUrl(string productid, string nonce_str,string time_stamp)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("appid", PayConfig.AppId);
            dic.Add("mch_id", PayConfig.MchId);
            dic.Add("nonce_str", nonce_str);
            dic.Add("product_id", productid);
            dic.Add("time_stamp", time_stamp);
            dic.Add("sign", GetSign(dic));

            string url = FormatBizQueryParaMap(dic, false);//这里不要url编码
            return "weixin://wxpay/bizpayurl?" + url;
        }
        #endregion

        #region 获取签名
        /// 获得签名
        /// <summary>
        /// 获得签名
        /// </summary>
        /// <param name="paraDic"></param>
        /// <returns></returns>
        public static string GetSign(Dictionary<string, string> paraDic)
        {
            Dictionary<string, string> bizParameters = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> item in paraDic)
            {
                if (item.Value != "")
                {
                    bizParameters.Add(item.Key.ToLower(), item.Value);
                }
            }
            bizParameters.OrderBy(m => m.Key);
            string str = FormatBizQueryParaMap(bizParameters, false);//不进行URL编码，官网文档没有写
            string strSginTemp = string.Format("{0}&key={1}", str, PayConfig.AppKey);//商户支付密钥 
            string sign = MD5(strSginTemp).ToUpper();//转换成大写         
            return sign;
        }

        /// 拼接成键值对
        /// <summary>
        /// 拼接成键值对
        /// </summary>
        /// <param name="paraMap"></param>
        /// <param name="urlencode"></param>
        /// <returns></returns>
        public static string FormatBizQueryParaMap(Dictionary<string, string> paraMap, bool urlencode)
        {
            string buff = "";
            try
            {
                var result = from pair in paraMap orderby pair.Key select pair;

                foreach (KeyValuePair<string, string> pair in result)
                {
                    if (pair.Key != "")
                    {

                        string key = pair.Key;
                        string val = pair.Value;
                        if (urlencode)
                        {
                            val = System.Web.HttpUtility.UrlEncode(val);
                        }
                        buff += key.ToLower() + "=" + val + "&";

                    }
                }

                if (buff.Length == 0 == false)
                {
                    buff = buff.Substring(0, (buff.Length - 1) - (0));
                }
            }
            catch (Exception e)
            {
                //throw new SDKRuntimeException(e.Message);
            }
            return buff;
        }

        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string MD5(string pwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(pwd);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            string str = "";
            for (int i = 0; i < md5data.Length; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');
            }
            return str;
        }
        #endregion
    }
}