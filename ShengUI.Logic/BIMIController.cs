using System;
using System.Web.Mvc;
using IBLLService;
using ShengUI.Helper;
using Common;
using System.Text;
using MODEL;
using MODEL.ViewModel;
using Senparc.Weixin.MP.TenPayLib;
using System.Xml;
using ShengUI.Helper.payCls;
using System.Collections.Generic;
using MODEL.ViewPage;

namespace ShengUI.Logic
{
    [HandleError]
    public class BIMIController : BaseController
    {
        ITokenConfig_MANAGER token = OperateContext.Current.BLLSession.ITokenConfig_MANAGER;
        IYX_sysConfigs_MANAGER sysConfigs = OperateContext.Current.BLLSession.IYX_sysConfigs_MANAGER;
        ITG_review_MANAGER proreviewManager = OperateContext.Current.BLLSession.ITG_review_MANAGER;
        IYX_weiUser_MANAGER weiUserM = OperateContext.Current.BLLSession.IYX_weiUser_MANAGER;
        IVIEW_WeChatUser_MANAGER weiUserA = OperateContext.Current.BLLSession.IVIEW_WeChatUser_MANAGER;
        IMST_SUPPLIER_MANAGER supplierB = OperateContext.Current.BLLSession.IMST_SUPPLIER_MANAGER;
        IMST_CATEGORY_MANAGER categoryB = OperateContext.Current.BLLSession.IMST_CATEGORY_MANAGER;
        IMST_PRD_MANAGER prdB = OperateContext.Current.BLLSession.IMST_PRD_MANAGER;
        IMST_PRD_IMG_MANAGER prdimgB = OperateContext.Current.BLLSession.IMST_PRD_IMG_MANAGER;
        ISYS_REF_MANAGER sysrefB = OperateContext.Current.BLLSession.ISYS_REF_MANAGER;
        ITG_order_MANAGER orderB = OperateContext.Current.BLLSession.ITG_order_MANAGER;
        ITG_transactionLog_MANAGER transactionlogB = OperateContext.Current.BLLSession.ITG_transactionLog_MANAGER;
        ITG_Thing_MANAGER thingB = OperateContext.Current.BLLSession.ITG_Thing_MANAGER;
        ITG_TXmoney_MANAGER txmoneyB = OperateContext.Current.BLLSession.ITG_TXmoney_MANAGER;
        public string JssdkSignature = "";
        public string noncestr = "";
        public string shareInfo = "";
        public string timestamp = "";

        public string openid = "";
        public string userid = "";

        //支付参数
        public string sj = "";//随机串
        public string PaySign = "";//签名
        public string Package = "";
        public string payTimeSamp = "";//生成签名的时间戳
        public string isok = "NO";
        public ActionResult UserMain()
        {
            
            ViewBag.PageFlag = "UserMain";
            ViewBag.isok = "OK";
            ViewBag.Appid = WeChatConfig.GetKeyValue("appid");
            ViewBag.Uri = WeChatConfig.GetKeyValue("shareurl");

            var userid = SessionHelper.Get("usernum");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid))
            {
                return Redirect("/BIMI/Login");

            }
        

           ViewBag.Price= StockApi.getStockPrice("BIMI");
           var model = weiUserA.GetModelWithOutTrace(u => u.userNum == userid);
            if (model != null)
            {
                CommonMethod.delCookie("openid");
                CommonMethod.delCookie("userid");
                CommonMethod.setCookie("openid", openid, 1);
                CommonMethod.setCookie("userid", model.userNum, 1);
                ViewBag.nickname = model.nickname;
                ViewBag.headimgurl = model.headimgurl;
            }
           
           ViewBag.UserType= ConfigSettings.GetSysConfigValue("USERTYPE", model.isfenxiao.ToString());
           return View(VIEW_VIEW_WeChatUser.ToViewModel(model));
        }
        public ActionResult Login()
        {

            //ViewBag.Appid = WeChatConfig.GetKeyValue("appid");
            //ViewBag.Uri = WeChatConfig.GetKeyValue("shareurl");

            //noncestr = CommonMethod.GetCode(16);

            //string jsapi_ticket = Js_sdk_Signature.IsExistjsapi_ticket(token.IsExistAccess_Token());
            //timestamp = DateTime.Now.Ticks.ToString().Substring(0, 10); ;
            //string url = Request.Url.ToString().Replace("#", "");
            //JssdkSignature = Js_sdk_Signature.GetjsSDK_Signature(noncestr, jsapi_ticket, timestamp, url);
            //ViewBag.noncestr = noncestr;
            //ViewBag.jsapi_ticket = jsapi_ticket;
            //ViewBag.timestamp = timestamp;
            //openid = CommonMethod.getCookie("openid");
            //userid = CommonMethod.getCookie("userid");
            //if (string.IsNullOrEmpty(openid))
            //{

            //    //根据授权 获取openid //根据授权  获取用户的openid
            //    string code = Request.QueryString["code"];//获取授权code
            //    LogHelper.WriteLog("//////////////////////////////////////////////////////////////////////////////////");
            //    LogHelper.WriteLog("code：" + code);
            //    if (string.IsNullOrEmpty(code))
            //    {
            //        string codeurl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx242aa47391c159f6&redirect_uri=http://www.boqixinhuiwang.com/BIMI/Login&response_type=code&scope=snsapi_userinfo&state=STATE&connect_redirect=1#wechat_redirect";
            //        Response.Redirect(codeurl);
            //    }
            //    else
            //    {
            //        string openIdUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + WeChatConfig.GetKeyValue("appid") + "&secret=" + WeChatConfig.GetKeyValue("appsecret") + "&code=" + code + "&grant_type=authorization_code";
            //        string content = Tools.GetPage(openIdUrl, "");
            //        openid = Tools.GetJsonValue(content, "openid");//根据授权  获取当前人的openid
            //    }
            //}
            //var model = weiUserA.GetModelWithOutTrace(u => u.openid == openid);
            //if (model == null)
            //{
            //    Senparc.Weixin.MP.AdvancedAPIs.User.UserInfoJson dic = Senparc.Weixin.MP.AdvancedAPIs.UserApi.Info(token.IsExistAccess_Token(), openid);
            //    LogHelper.WriteLog("XXXXXXXXXXX：" + openid);
            //    //LogHelper.WriteLog("XXXXXXXXXXX：" + openid);
            //    if (dic != null)
            //    {
            //        ViewBag.nickname = dic.nickname;
            //        ViewBag.headimgurl = dic.headimgurl;
            //    }
            //    model = new MODEL.VIEW_WeChatUser();
            //    model.subscribe = dic.subscribe;
            //    model.openid = dic.openid;
            //    model.nickname = dic.nickname;
            //    model.sex = dic.sex;
            //    model.U_language = dic.language;
            //    model.city = dic.city;
            //    model.province = dic.province;
            //    model.country = dic.country;
            //    model.headimgurl = dic.headimgurl;
            //    model.subscribe_time = DateTime.Now;
            //    model.userSex = dic.sex == 2 ? "女" : "男";
            //    model.userNum = Common.Tools.Get8Digits();
            //    model.F_id = 0;
            //    model.isfenxiao = 0;
            //    model.userMoney = 0;
            //    model.userYongJin = 0;
            //    model.flat1 = 0;
            //    model.flat2 = 0;
            //    model.flat7 = 0;
            //    model.TREE_NODE_ID = "144e42158f676695";
            //    weiUserM.Add(VIEW_YX_weiUser.ToEntity(VIEW_VIEW_WeChatUser.ToViewModel(model)));

            //}
            return View();
        }
        public ActionResult Logon(MODEL.ViewPage.LoginUser user)
        {
            bool status = false;
            if (!ModelState.IsValid)
            {
                return this.JsonFormat(ModelState, !false, "ERROR");
                // return OperateContext.Current.RedirectAjax("err", "没有权限!", null, "");
            }
            var ISHOT = prdB.Get(p => p.PRD_CD == "PRD22440853").ISHOT;
            var model = weiUserA.GetModelWithOutTrace(u => u.userTel == user.UserName&&u.remark1==user.Password);
            if (model != null)
            {
                if (!ISHOT)
                {
                    return this.JsonFormat("SYSERROR", status, "美国节假日休息");
                }
                status = true;
                SessionHelper.Add("usernum", model.userNum);
              
                return this.JsonFormat("/BIMI/UserMain", status, SysOperate.Operate.ToMessage(status), status);
            }
            else
            {
                return this.JsonFormat("SYSERROR", status, "账户或密码错误");
            }
        }
        public ActionResult SubmitPwd(MODEL.ViewPage.ChangePassWord pwd)
        {
            var userid = SessionHelper.Get("usernum");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid))
            {
                return Redirect("/BIMI/Login");

            }
            var model = weiUserM.GetModelWithOutTrace(u => u.userNum == userid);
            bool status = false;
            if (!ModelState.IsValid)
            {
                return this.JsonFormat(ModelState, !false, "ERROR");
                // return OperateContext.Current.RedirectAjax("err", "没有权限!", null, "");
            }
      
            if (model.remark1 == pwd.OldPassword)
            {
                model.remark1 = pwd.NewPassword;
                weiUserM.Modify(model, "remark1");
               status = true;
                return this.JsonFormat("/BIMI/UserMain", status, "修改成功", status);
            }
            else
            {
                return this.JsonFormat("SYSERROR", status, "原密码错误，请重新输入");
            }
        }
        public ActionResult Cash(MODEL.ViewModel.VIEW_TG_TXmoney money)
        {
            var userid = SessionHelper.Get("usernum");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid))
            {
                return Redirect("/BIMI/Login");

            }
            var model = weiUserA.GetModelWithOutTrace(u => u.userNum == userid);
            bool status = false;
            if (!ModelState.IsValid)
            {
                return this.JsonFormat(ModelState, !false, "ERROR");
                // return OperateContext.Current.RedirectAjax("err", "没有权限!", null, "");
            }
            if ((model.flat2 + model.flat7) < model.flat1)
            {
                return this.JsonFormat("SYSERROR", status, "请卖出全部股票后才可提现");
            }
            if (model.userYongJin < money.TXmoney)
            {
                return this.JsonFormat("SYSERROR", status, "请输入正确的提现金额");
            }
            TG_TXmoney currmoney = new TG_TXmoney();
            currmoney.userId = userid;
            currmoney.openid = model.openid;
            currmoney.Utel = model.userTel;
            currmoney.Addtime = DateTime.Now;
            currmoney.bankInfo = money.bankInfo;
            currmoney.bankUserInfo = money.bankUserInfo;
            currmoney.remark1 = money.remark1;
            currmoney.TXmoney = money.TXmoney;
            currmoney.TXstate = 0;
            txmoneyB.Add(currmoney);
            status = true;
             return this.JsonFormat("/BIMI/CashList", status, "修改成功", status);
        }
        public ActionResult UpdatePwd()
        {

            var userid = SessionHelper.Get("usernum");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid))
            {
                return Redirect("/BIMI/Login");

            }
            var model = VIEW_VIEW_WeChatUser.ToViewModel(weiUserA.GetModelWithOutTrace(u => u.userNum == userid));
            ViewBag.userNum = userid;
            ViewBag.userRelname = model.userRelname;
            return View();
        }
    
        public ActionResult CashMoney()
        {

            var userid = SessionHelper.Get("usernum");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid))
            {
                return Redirect("/BIMI/Login");

            }
            var model = VIEW_VIEW_WeChatUser.ToViewModel(weiUserA.GetModelWithOutTrace(u => u.userNum == userid));
            ViewBag.userNum = userid;
            ViewBag.userRelname = model.userRelname;
            VIEW_TG_TXmoney money = new VIEW_TG_TXmoney();
            money.bankInfo = model.remark3;
            money.remark1 = model.remark4;
            money.bankUserInfo = model.remark5;
            money.TXmoney = model.userYongJin;
            return View(money);
        }
        public ActionResult Transaction_Sale()
        {
            ViewBag.PageFlag = "OrderList";
           // var status = false;
            var userid = SessionHelper.Get("usernum");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid))
            {
                return Redirect("/BIMI/Login");

            }
            var model = VIEW_VIEW_WeChatUser.ToViewModel(weiUserA.GetModelWithOutTrace(u => u.userNum == userid));
            ViewBag.userNum = userid;
            ViewBag.userRelname = model.userRelname;
            return View();
        }
        public ActionResult OrderList()
        {
            ViewBag.PageFlag = "OrderList";
            var status = false;
            var userid = SessionHelper.Get("usernum");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid) )
            {
                return Redirect("/BIMI/Login");

            }
            var model = VIEW_VIEW_WeChatUser.ToViewModel(weiUserA.GetModelWithOutTrace(u => u.userNum == userid));
            ViewBag.OrderList = VIEW_TG_order.ToListViewModel(orderB.GetListBy(s => s.UserId == userid && s.trade_type == "ONLINE"&&s.SYNCOPERATION!="D"&&s.ssh_status==3, o => o.orderTime, false));
            return View(model);
        }
        public ActionResult CashList()
        {
            ViewBag.PageFlag = "CashList";
            var status = false;
            var userid = SessionHelper.Get("usernum");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid))
            {
                return Redirect("/BIMI/Login");

            }
            var model = VIEW_VIEW_WeChatUser.ToViewModel(weiUserA.GetModelWithOutTrace(u => u.userNum == userid));
            ViewBag.CashList = VIEW_TG_TXmoney.ToListViewModel(txmoneyB.GetListBy(s => s.userId == userid, o => o.Addtime, false));
            return View(model);
        }
        public ActionResult DelegateList()
        {
            ViewBag.PageFlag = "DelegateList";
           // var status = false;
            var userid = SessionHelper.Get("usernum");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid))
            {
                return Redirect("/BIMI/Login");

            }
            var model = VIEW_VIEW_WeChatUser.ToViewModel(weiUserA.GetModelWithOutTrace(u => u.userNum == userid));
            ViewBag.OrderList = VIEW_TG_order.ToListViewModel(orderB.GetListBy(s => s.UserId == userid &&s.ssh_status==0 && s.trade_type == "ONLINE" && s.SYNCOPERATION != "D", o => o.orderTime, false));
            return View(model);
        }
        public ActionResult SubmitOrder(StockSale model)
        {
            bool status = false;
            var userid = SessionHelper.Get("usernum");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid))
            {
                return Redirect("/BIMI/Login");

            }
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, status, "ERROR");

            var currdate = DateTime.Now.Hour;
            var currMin = DateTime.Now.Minute;
            if ((currdate <11) || currdate > 18)
            {
               // return this.JsonFormat("/BIMI/DelegateList", status, SysOperate.Add.ToMessage(status), status);
               // return this.JsonFormat(status, status, SysOperate.Add);
                return this.JsonFormat("SYSERROR", status, "当前时间不可交易");
            }
            var orderCount=orderB.GetListBy(s => s.UserId == userid  && s.ssh_status == 0 && s.trade_type == "ONLINE" && s.SYNCOPERATION != "D", o => o.orderTime, false).Count;
            if (orderCount >0)
            {
                // return this.JsonFormat("/BIMI/DelegateList", status, SysOperate.Add.ToMessage(status), status);
                // return this.JsonFormat(status, status, SysOperate.Add);
                return this.JsonFormat("SYSERROR", status, "请先在当日委托撤单，再重新下单");
            }
            var user = weiUserA.GetModelWithOutTrace(u => u.userNum == userid);
            if (model.Count>user.flat7)
            {
               // return this.JsonFormat("/BIMI/DelegateList", status, SysOperate.Add.ToMessage(status), status);
               // return this.JsonFormat(status, status, SysOperate.Add);
                return this.JsonFormat("SYSERROR", status, "当前可用股票数量为："+user.flat7);
            }
            
            string orderNum = CommonMethod.GetOrderNum();//订单号
            string ThingNum =CommonMethod.GetCode(18);//流水号;
           // string thingName = Request.Form["thingName"];
            //string sid ="";
            //string suppliername = "";
            //string uname = Request.Form["uname"];
            //string mobile = Request.Form["mobile"];
            //string currentselectdate = Request.Form["selectdate"];
            //string currentselecttime = Request.Form["selecttime"];
            //string thingPrice = "0";//总金额
            //string thingFrontPrice = Request.Form["thingFrontPrice"];//预付
            //string supplieraddress = Request.Form["supplieraddress"];//地址Id
            string trade_type = "ONLINE";
            var order = new VIEW_TG_order();
            order.orderNum = orderNum;
            order.ThingNum = ThingNum;
            order.remark1 = model.startPrice.ToString();
            order.remark2 = model.endPrice.ToString();
            order.userOpenId = openid;
            order.UserId = userid;
            order.userName = user.userRelname;
            order.UserTel = user.userTel;
            order.UserAddress = "";
            order.total_fee = TypeParser.ToDecimal(0);
            order.yunPrice = TypeParser.ToDecimal(0);
            order.flat1 = model.Count;
            order.flat2 = model.Count;
            order.trade_type = trade_type;
            order.years = DateTime.Now.Year;
            order.months = DateTime.Now.Month;
            order.ispay = 0;
            order.ssh_status = 0;
            order.orderTime = DateTime.Now;
            order.SYNCFLAG = "N";
            order.SYNCOPERATION = "A";
            order.SYNCVERSION = DateTime.Now;
            order.VERSION = 1;
            orderB.Add(VIEW_TG_order.ToEntity(order));
            
            VIEW_TG_Thing item = new VIEW_TG_Thing();
            item.orderNum = orderNum;
            item.ispay = order.ispay;
            item.ThingNum = ThingNum;
            item.UserId = order.UserId;
            item.openId = order.userOpenId;
            item.productId = "PRD22440853";
            item.remark1 = "BIMI.US";
            item.productCount = model.Count;
            item.productPrice = model.startPrice;
            item.productMoney = model.endPrice;
            item.createTim = DateTime.Now;
            thingB.Add(VIEW_TG_Thing.ToEntity(item));

            status = true;

            return this.JsonFormat("/BIMI/DelegateList", status, SysOperate.Add.ToMessage(status), status);
        }
        public ActionResult CanceOrder()
        {
            bool status = false;
            var userid = SessionHelper.Get("usernum");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid))
            {
                return Redirect("/BIMI/Login");

            }
            var currdate = DateTime.Now.Hour;
            var currMin = DateTime.Now.Minute;
            if ((currdate < 11) || currdate > 18)
            {
                // return this.JsonFormat("/BIMI/DelegateList", status, SysOperate.Add.ToMessage(status), status);
                // return this.JsonFormat(status, status, SysOperate.Add);
                return this.JsonFormat("SYSERROR", status, "当前时间不可交易");
            }
            TG_order order=new TG_order();
            order.ssh_status=2;
            order.ispay = 2;
            order.SYNCVERSION=DateTime.Now;
            orderB.ModifyBy(order, s => s.UserId == userid  && s.ssh_status == 0 && s.trade_type == "ONLINE" && s.SYNCOPERATION != "D", "ssh_status", "ispay", "SYNCVERSION");
            return Redirect("/BIMI/DelegateList"); 
        }



    }

}
