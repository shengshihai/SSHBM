using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Security.Cryptography;
using IBLLService;


namespace ShengUI.Helper.payCls
{
    public class WxPayHelper//此类用于微信Native支付CallBack页面的调用！
    {

        public const string unifiedorderURL = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        public WxPayHelper()
        {
            this.parameters = new Dictionary<string, string>();
            this.returnParameter = new Dictionary<string, string>();
            this.appid = NativePayConfig.AppId;//appid na
            this.mch_id = NativePayConfig.MchId;      //微信支付商户号         
            this.PartnerKey = NativePayConfig.AppKey;//这里是商户的partnerkey  
        }

        #region 私有属性
        private string appid;
        private string mch_id; //商户号      
        private string PartnerKey;//商户密钥
        private Dictionary<string, string> parameters;
        private Dictionary<string, string> returnParameter;

        public string GetAppId
        {
            get { return appid; }
        }

        public string GetMch_Id
        {
            get { return mch_id; }
        }

        public string GetPartnerKey
        {
            get { return PartnerKey; }
        }

        #endregion

        /// 动态设置参数
        /// <summary>
        /// 动态设置参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value_ren"></param>
        public void SetParameter(string key, string value_ren)
        {
            parameters.Add(key, value_ren);
        }

        public void SetReturnParameter(string key, string value)
        {
            this.returnParameter.Add(key, value);
        }

        public Dictionary<string, string> GetParameter()
        {
            if (this.parameters != null)
            {
                return this.parameters;
            }
            return null;
        }

        public string GetReturnXml()
        {
            this.returnParameter.Add("sign", GetSign(this.returnParameter));
            return CommonUtil.ArrayToXml(this.returnParameter);
        }



        /// 获得签名
        /// <summary>
        /// 获得签名
        /// </summary>
        /// <param name="paraDic"></param>
        /// <returns></returns>
        public string GetSign(Dictionary<string, string> paraDic)
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
            string strSginTemp = string.Format("{0}&key={1}", str, this.PartnerKey);//商户支付密钥 
            string sign = MD5(strSginTemp).ToUpper();//转换成大写         
            return sign;
        }

        public string MakePostXml()
        {
            return CommonUtil.ArrayToXml(this.parameters);

        }

        /// 保存POST来的数据
        /// <summary>
        /// 保存POST来的数据
        /// </summary>
        /// <param name="xmlData"></param>
        public void ReceivePostXmlData(string xmlData)
        {
            Dictionary<string, string> dic = CommonUtil.ReceivePostXmlData(xmlData);
            foreach (KeyValuePair<string, string> item in dic)
            {
                this.SetParameter(item.Key, item.Value);
            }
        }

        /// 验证签名
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <returns></returns>
        public bool CheckSign()
        {
            Dictionary<string, string> dic = this.parameters;
            if (dic.Count > 0)
            {
                string t = string.Empty;
                foreach (KeyValuePair<string, string> item in dic)
                {
                    t += item.Key + "=" + item.Value + "; ";
                }
                
            }
            string postSign = string.Empty;
            if (dic.Keys.Contains("sign"))
            {
                postSign = dic["sign"];
                dic.Remove("sign");
            }
            string sign = GetSign(dic);
          
            return postSign == sign;
        }

        /// 获取产品id
        /// <summary>
        /// 获取产品id
        /// </summary>
        /// <returns></returns>
        public string GetProductId()
        {
            if (this.parameters != null && this.parameters.Keys.Contains("product_id"))
            {
                return this.parameters["product_id"];
            }
            return null;
        }

        /// 获取预payid
        /// <summary>
        /// 获取预payid
        /// </summary>
        /// <returns></returns>
        public string GetPrepayId()
        {
            this.parameters.Add("sign", GetSign(this.parameters));
            string xml = MakePostXml();

            string content = Common.Tools.GetPage(unifiedorderURL, xml);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(content);
            return WeChatConfig.GetXMLstrByKey("prepay_id", xmldoc);
        }



        #region 辅助方法

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

        #endregion

    }
}