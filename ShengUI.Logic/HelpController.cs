using System;
using System.Web.Mvc;
using IBLLService;
using ShengUI.Helper;
using Common;

namespace ShengUI.Logic
{
    [HandleError]
    public class HelpController : BaseController
    {
        ITokenConfig_MANAGER token = OperateContext.Current.BLLSession.ITokenConfig_MANAGER;
        IYX_sysConfigs_MANAGER sysConfigs = OperateContext.Current.BLLSession.IYX_sysConfigs_MANAGER;
        public string JssdkSignature = "";
        public string noncestr = "";
        public string shareInfo = "";
        public string timestamp = "";

        public string openid = "";
        public string userid = "";

        //
        public string isok = "NO";
        public ActionResult Index()
        {

            ViewBag.isok = "OK";
            ViewBag.Appid = sysConfigs.GetKeyValue("appid");
            ViewBag.Uri = sysConfigs.GetKeyValue("shareurl");

            noncestr = CommonMethod.GetCode(16);
         
            string jsapi_ticket = Js_sdk_Signature.IsExistjsapi_ticket(token.IsExistAccess_Token());
            timestamp = DateTime.Now.Ticks.ToString().Substring(0, 10); ;
            string url = Request.Url.ToString().Replace("#", "");
            JssdkSignature = Js_sdk_Signature.GetjsSDK_Signature(noncestr, jsapi_ticket, timestamp, url);
            ViewBag.noncestr = noncestr;
            ViewBag.jsapi_ticket = jsapi_ticket;
            ViewBag.timestamp = timestamp;
            userid = Request.QueryString["userid"];
            ViewBag.userid = userid;
            ViewBag.openid = openid;
            //根据授权 获取openid //根据授权  获取用户的openid
            string code = Request.QueryString["code"];//获取授权code
            LogHelper.WriteLog("//////////////////////////////////////////////////////////////////////////////////");
            LogHelper.WriteLog("code：" + code);
            if (!string.IsNullOrEmpty(code))
            {
                string openIdUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + sysConfigs.GetKeyValue("appid") + "&secret=" + sysConfigs.GetKeyValue("appsecret") + "&code=" + code + "&grant_type=authorization_code";
                // LogHelper.WriteLog("openIdUrl：" + openIdUrl);
                string content = Tools.GetPage(openIdUrl, "");
                LogHelper.WriteLog("content：" + content);
                openid = Tools.GetJsonValue(content, "openid");//根据授权  获取当前人的openid
                Senparc.Weixin.MP.AdvancedAPIs.User.UserInfoJson dic = Senparc.Weixin.MP.AdvancedAPIs.UserApi.Info(token.IsExistAccess_Token(), openid);
                LogHelper.WriteLog("XXXXXXXXXXX：" + openid);
                if (dic != null)
                {
                    ViewBag.nickname = dic.nickname;
                    ViewBag.headimgurl = dic.headimgurl;
                }
            }
            else
            {
                string codeurl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx5affe01247a2482c&redirect_uri=http://qxw2062640039.my3w.com/help/index/&response_type=code&scope=snsapi_userinfo&state=STATE&connect_redirect=1#wechat_redirect";
                Response.Redirect(codeurl);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.PageFlag = "About";
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

    }

}
