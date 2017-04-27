using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ShengUI.Helper.payCls
{
    public class NativePayConfig
    {
        /// <summary>
        /// 人民币
        /// </summary>
        public static string Tenpay = "1";

        /// <summary>
        /// mchid ， 微信支付商户号
        /// </summary>
        public static string MchId =WeChatConfig.GetKeyValue("mchid");

        /// <summary>
        /// appid，应用ID， 在微信公众平台中 “开发者中心”栏目可以查看到
        /// </summary>
        public static string AppId = WeChatConfig.GetKeyValue("appid");

        /// <summary>
        /// appsecret ，应用密钥， 在微信公众平台中 “开发者中心”栏目可以查看到
        /// </summary>
        public static string AppSecret = WeChatConfig.GetKeyValue("appsecret");

        /// <summary>
        /// paysignkey，API密钥，在微信商户平台中“账户设置”--“账户安全”--“设置API密钥”，只能修改不能查看
        /// </summary>
        public static string AppKey = WeChatConfig.GetKeyValue("apisecret");


        /// <summary>
        /// 支付页面，请注意测试阶段设置授权目录，在微信公众平台中“微信支付”---“开发配置”--修改测试目录   
        /// 注意目录的层次，比如我的：
        /// </summary>
        public static string PayUrl = WeChatConfig.GetKeyValue("shareurl") + "AoShaCar/PayOrder";

        /// <summary>
        ///  支付通知页面，请注意测试阶段设置授权目录，在微信公众平台中“微信支付”---“开发配置”--修改测试目录   
        /// 支付完成后的回调处理页面,替换成notify_url.asp所在路径
        /// </summary>
        public static string NotifyUrl = WeChatConfig.GetKeyValue("shareurl") + "AoShaCar/Notify.aspx";//参与签名


    }
}