using System;
using System.Web.Mvc;
using IBLLService;
using ShengUI.Helper;
using Common;
using System.Text;
using MODEL;
using MODEL.ViewModel;

namespace ShengUI.Logic
{
    [HandleError]
    public class KeYanBaoController : BaseController
    {
        ITokenConfig_MANAGER token = OperateContext.Current.BLLSession.ITokenConfig_MANAGER;
        IYX_sysConfigs_MANAGER sysConfigs = OperateContext.Current.BLLSession.IYX_sysConfigs_MANAGER;
        ITG_product_MANAGER productManager = OperateContext.Current.BLLSession.ITG_product_MANAGER;
        ITG_review_MANAGER proreviewManager = OperateContext.Current.BLLSession.ITG_review_MANAGER;
        IYX_weiUser_MANAGER weiUserM = OperateContext.Current.BLLSession.IYX_weiUser_MANAGER;
        ITG_pic_MANAGER picM = OperateContext.Current.BLLSession.ITG_pic_MANAGER;
        public string JssdkSignature = "";
        public string noncestr = "";
        public string shareInfo = "";
        public string timestamp = "";

        public string openid = "";
        public string userid = "";

        //
        public string isok = "NO";
        public ActionResult UserMain()
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
            //if (!string.IsNullOrEmpty(code))
            //{
            //    string openIdUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + sysConfigs.GetKeyValue("appid") + "&secret=" + sysConfigs.GetKeyValue("appsecret") + "&code=" + code + "&grant_type=authorization_code";
            //    // LogHelper.WriteLog("openIdUrl：" + openIdUrl);
            //    string content = Tools.GetPage(openIdUrl, "");
            //    //LogHelper.WriteLog("content：" + content);
            //    openid = Tools.GetJsonValue(content, "openid");//根据授权  获取当前人的openid
            //    Senparc.Weixin.MP.AdvancedAPIs.User.UserInfoJson dic = Senparc.Weixin.MP.AdvancedAPIs.UserApi.Info(token.IsExistAccess_Token(), openid);
            //    //LogHelper.WriteLog("XXXXXXXXXXX：" + openid);
            //    if (dic != null)
            //    {
            //        ViewBag.nickname = dic.nickname;
            //        ViewBag.headimgurl = dic.headimgurl;
            //    }
            //}
            //else
            //{
            //    string codeurl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx5affe01247a2482c&redirect_uri=http://www.chc1845.com/KeYanBao/UserMain/?&response_type=code&scope=snsapi_userinfo&state=STATE&connect_redirect=1#wechat_redirect";
            //    Response.Redirect(codeurl);
            //}
            return View();
        }

        public ActionResult About()
        {
            ViewBag.PageFlag = "About";
            return View();
        }
        public ActionResult ProductDetail(int pid)
        {
            //很据条件 加载商品详情
            var product = productManager.Get(p => p.Id == pid);
            VIEW_TG_product model = new VIEW_TG_product();
            StringBuilder sb = new StringBuilder(); sb.Append("");
            if (product != null)
            {
                model = VIEW_TG_product.ToViewModel(product);
               var proview= proreviewManager.GetListBy(pv => pv.productId == pid);
               if (proview.Count> 0)
                   {
                       foreach (var item in proview)
                       {
                            int Uid = Convert.ToInt32(item.userId);
                            var usermodel = weiUserM.Get(u => u.Id == Uid);
                            sb.Append("<li><div class=\"clear-both\"><img src=\"" + usermodel.headimgurl + "\" style=\"background-image: url('imgs/photo.jpg');\" /><div>" + CommonMethod.CutString(usermodel.nickname, 20) + "</div><div>" + Convert.ToDateTime(item.reviewTime).ToString("yyyy-MM-dd") + "</div></div><div class=\"clear-both\"><span>" + item.reviewContent+ "</span></div></li>");
                       }
                   }
               
            }
            var piclist=picM.GetListBy(c=>c.PicNum==product.PicNum);
            StringBuilder sbp = new StringBuilder(); sbp.Append("");
            StringBuilder sbp2 = new StringBuilder(); sbp2.Append("");
            int count = piclist.Count;
            if (piclist.Count>0)
            {
                foreach (var item in piclist)
                {
                     sbp.Append(@" <img src='" + item.shopingPic + "' />");
                     sbp2.Append(@"<li> <img src='" + item.shopingPic + "' /></li>");
                }
            }
            ViewBag.DescriblePicNum = sbp.ToString();
            ViewBag.ImgList = sbp2.ToString();
           ViewBag.revInfo = sb.ToString();
           return View(model);
        }

    }

}
