using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections;
using System.Security.Cryptography;

namespace ShengUI.Helper.payCls
{
    /**
  * 
  * 作用：微信支付公用参数，微信支付版本V3.3.7
  * 作者：shihai
  * 编写日期：2015-4-1
  * 备注：请正确填写相关参数
  * 
  * */
    public class PayConfig
    {
        /// <summary>
        /// 人民币
        /// </summary>
        public static string Tenpay = "1";

        /// <summary>
        /// mchid ， 微信支付商户号
        /// </summary>
        public static string MchId = WeChatConfig.GetKeyValue("mchid");

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
        public static string NotifyUrl = WeChatConfig.GetKeyValue("shareurl") + "AoShaCar/Notify";//参与签名

       

        #region 获取微信支付数据包
        /// <summary>
        /// 微信JSAPI支付数据包 含有非必须参数  
        /// </summary>
        /// <param name="attach">附加数据，原样返回</param>
        /// <param name="body">商品描述</param>
        /// <param name="device_info">微信支付分配的终端设备号  不是必备参数</param>
        /// <param name="nonce_str">随机字符串，不长于 32 位</param>
        /// <param name="out_trade_no">户系统内部的订单号 ,32个字符内、可包含字母, 确保唯一</param>
        /// <param name="spbill_create_ip">订单生成的机器 IP</param>
        /// <param name="total_fee">总金额</param>
        /// <param name="sign">签名</param>
        /// <param name="openid">用户在公众平台下的唯一标识</param>
        /// <param name="trade_type">支付类型：JSAPI、 NATIVE、 APP</param>
        /// <returns></returns>
        public static string GetPayData(string attach, string body, string device_info, string nonce_str, string out_trade_no, string spbill_create_ip, int total_fee, string sign, string openid, string trade_type = "JSAPI")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<xml>");
            sb.Append(@"<appid>" + AppId + "</appid>");
            sb.Append(@"<attach><![CDATA[" + attach + "]]></attach>");//附加数据，原样返回
            sb.Append(@"<body><![CDATA[" + body + "]]></body>");//商品描述
            sb.Append(@"<device_info>" + device_info + "</device_info>");//微信支付分配的终端设备号  不是必备参数
            sb.Append(@"<mch_id>" + MchId + "</mch_id>");//微信支付分配的商户号
            sb.Append(@"<nonce_str>" + nonce_str + "</nonce_str>");//随机字符串，不长于 32 位
            sb.Append(@"<notify_url>" + NotifyUrl.ToString().Replace("#", "") + "</notify_url>");//接收微信支付成功通知
            sb.Append(@"<out_trade_no>" + out_trade_no + "</out_trade_no>");//商户系统内部的订单号 ,32个字符内、可包含字母, 确保唯一
            sb.Append(@"<spbill_create_ip>" + spbill_create_ip + "</spbill_create_ip>");//订单生成的机器 IP
            sb.Append(@"<total_fee>" + total_fee + "</total_fee>");//总金额
            sb.Append(@"<trade_type>" + trade_type + "</trade_type>");//JSAPI、 NATIVE、 APP
            sb.Append(@"<openid>" + openid + "</openid>");//openId  JSAPI支付模式，参数必备
            sb.Append(@"<sign><![CDATA[" + sign + "]]></sign>");//签名
            sb.Append(@"</xml>");

            return sb.ToString();
        }

        /// <summary>
        /// 微信JSAPI支付数据包 仅仅包含必备参数 JSAPI
        /// </summary>
        /// <param name="attach">附加数据，原样返回</param>
        /// <param name="body">商品描述</param>
        /// <param name="device_info">微信支付分配的终端设备号  不是必备参数</param>
        /// <param name="nonce_str">随机字符串，不长于 32 位</param>
        /// <param name="out_trade_no">户系统内部的订单号 ,32个字符内、可包含字母, 确保唯一</param>
        /// <param name="spbill_create_ip">订单生成的机器 IP</param>
        /// <param name="total_fee">总金额</param>
        /// <param name="sign">签名</param>
        /// <param name="openid">用户在公众平台下的唯一标识</param>
        /// <param name="trade_type">支付类型：JSAPI、 NATIVE、 APP</param>
        /// <returns></returns>
        public static string GetPayData(string attach, string body, string nonce_str, string out_trade_no, string spbill_create_ip, int total_fee, string sign, string openid, string trade_type = "JSAPI")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<xml>");
            sb.Append(@"<appid>" + AppId + "</appid>");
            sb.Append(@"<attach><![CDATA[" + attach + "]]></attach>");//附加数据，原样返回
            sb.Append(@"<body><![CDATA[" + body + "]]></body>");//商品描述
            sb.Append(@"<mch_id>" + MchId + "</mch_id>");//微信支付分配的商户号
            sb.Append(@"<nonce_str>" + nonce_str + "</nonce_str>");//随机字符串，不长于 32 位
            sb.Append(@"<notify_url>" + NotifyUrl.ToString().Replace("#", "") + "</notify_url>");//接收微信支付成功通知
            sb.Append(@"<out_trade_no>" + out_trade_no + "</out_trade_no>");//商户系统内部的订单号 ,32个字符内、可包含字母, 确保唯一
            sb.Append(@"<spbill_create_ip>" + spbill_create_ip + "</spbill_create_ip>");//订单生成的机器 IP
            sb.Append(@"<total_fee>" + total_fee + "</total_fee>");//总金额
            sb.Append(@"<trade_type>" + trade_type + "</trade_type>");//JSAPI、 NATIVE、 APP
            sb.Append(@"<openid>" + openid + "</openid>");//openId  JSAPI支付模式，参数必备
            sb.Append(@"<sign><![CDATA[" + sign + "]]></sign>");//签名
            sb.Append(@"</xml>");

            return sb.ToString();
        }
        #endregion



    }
}