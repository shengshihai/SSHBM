using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using IBLLService;
using MODEL.ViewModel;
using Common;
using MODEL;
using ShengUI.Helper;
using System.Threading;
using System.Globalization;
using Common.EfSearchModel.Model;
using MODEL.ViewPage;
using Senparc.Weixin.MP.CommonAPIs;
using System.Web.Security;

namespace ShengUI.Logic
{
    public class CommonController : BaseController
    {
        IYX_sysConfigs_MANAGER sysConfigs = OperateContext.Current.BLLSession.IYX_sysConfigs_MANAGER;
        public static string AppId = "wx7c026ba8378daee7"; //微信公众号 appId
        public static string Appsecret = "1866df8e105a25ff33f23d2c22d701ed";  //微信公众号密钥
        public static string baiduAk = "O5R6ObuaqtaC1K9FUysGTbNx";//百度开发者：baiduAk
        public static string apisecret = "3F7F3259DB69447487E9C4BBC123C025";//微信支付秘钥
        public static string URLToken = "sohovan";//自己填写的Token  和开启开发者模式时填写的一样。

        public static string certPath = "";//HttpContext.Current.Server.MapPath("/fenxiao/userHome/hb/zhengshu/apiclient_cert.p12");//微信商户平台证书路径
        public static string certPwd = "";//GetKeyValue("mchid");//证书密码  及   商户平台商户号  初始密码  可以修改
        public ActionResult WeChat()
        {
            
           HttpContext.Response.ContentType = "text/plain";
            Appsecret = sysConfigs.GetKeyValue("appsecret");
            AppId = sysConfigs.GetKeyValue("appid");
            apisecret = sysConfigs.GetKeyValue("apisecret");
            URLToken = sysConfigs.GetKeyValue("token");
            try
            {
                if (HttpContext.Request.HttpMethod.ToUpper() == "GET")
                {
                    if (!AccessTokenContainer.CheckRegistered(AppId))
                    {
                        AccessTokenContainer.Register(AppId, Appsecret);
                    }

                    Auth(); //微信接入的测试  成为开发者第一步
                }
                if (HttpContext.Request.HttpMethod.ToUpper() == "POST")
                {
                    if (!AccessTokenContainer.CheckRegistered(AppId))
                    {
                        AccessTokenContainer.Register(AppId, Appsecret);
                    }



                    //responseMsg();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("一般处理程序入口错误：", ex);
            }

            return Content("");
        }
        public ActionResult UploadPhoto()
        {
            bool status = false;
            var fileurl= UploadRequestImg.OneImageSave(HttpContext);
            status = true;
            return this.JsonFormat(fileurl, !status,"上传成功!");
        }
        #region 成为开发者
        /// <summary>
        /// 验证微信签名
        /// </summary>
        public bool CheckSignature(string token, string signature, string timestamp, string nonce)
        {
            string[] ArrTmp = { token, timestamp, nonce };

            Array.Sort(ArrTmp);
            string tmpStr = string.Join("", ArrTmp);

            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();

            if (tmpStr == signature)
            {

                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 成为开发者的第一步，验证并相应服务器的数据
        /// </summary>
        private void Auth()
        {
            string token = URLToken;//自己填写的Token  和开启开发者模式时填写的一样。
            if (string.IsNullOrEmpty(token))
            {
                //LogTextHelper.Error(string.Format("WeixinToken 配置项没有配置！"));
            }

            string echoString = HttpContext.Request.QueryString["echostr"];
            string signature = HttpContext.Request.QueryString["signature"];
            string timestamp = HttpContext.Request.QueryString["timestamp"];
            string nonce = HttpContext.Request.QueryString["nonce"];

            if (CheckSignature(token, signature, timestamp, nonce))
            {
                if (!string.IsNullOrEmpty(echoString))
                {
                   Response.Write(echoString);
                    // HttpContext.Current.Response.End();
                }
            }
        }
        #endregion
    }
}
