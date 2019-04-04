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
        public string JssdkSignature = "";
        public string noncestr = "";
        public string shareInfo = "";
        public string timestamp = "";

        public string openid = "oXZjm1LcHQuCl8eWWuwnnPI-QOtY";
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
            //        string codeurl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx242aa47391c159f6&redirect_uri=http://www.boqixinhuiwang.com/BIMI/userMain&response_type=code&scope=snsapi_userinfo&state=STATE&connect_redirect=1#wechat_redirect";
            //        Response.Redirect(codeurl);
            //    }
            //    else
            //    {
            //        string openIdUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + WeChatConfig.GetKeyValue("appid") + "&secret=" + WeChatConfig.GetKeyValue("appsecret") + "&code=" + code + "&grant_type=authorization_code";
            //        string content = Tools.GetPage(openIdUrl, "");
            //        openid = Tools.GetJsonValue(content, "openid");//根据授权  获取当前人的openid
            //    }
            //}
           // var model = VIEW_YX_weiUser.ToViewModel(weiUserM.GetModelWithOutTrace(u => u.openid == openid));
           ViewBag.Price= StockApi.getStockPrice("BIMI");
            var model = VIEW_VIEW_WeChatUser.ToViewModel(weiUserA.GetModelWithOutTrace(u => u.openid == openid));
            if (model != null)
            {
                CommonMethod.delCookie("openid");
                CommonMethod.delCookie("userid");
                CommonMethod.setCookie("openid", openid, 1);
                CommonMethod.setCookie("userid", model.userNum, 1);
                ViewBag.nickname = model.nickname;
                ViewBag.headimgurl = model.headimgurl;
                
            }
            else
            {
                Senparc.Weixin.MP.AdvancedAPIs.User.UserInfoJson dic = Senparc.Weixin.MP.AdvancedAPIs.UserApi.Info(token.IsExistAccess_Token(), openid);
                //LogHelper.WriteLog("XXXXXXXXXXX：" + openid);
                if (dic != null)
                {
                    ViewBag.nickname = dic.nickname;
                    ViewBag.headimgurl = dic.headimgurl;
                }
                model = new MODEL.ViewModel.VIEW_VIEW_WeChatUser();
                model.subscribe = dic.subscribe;
                model.openid = dic.openid;
                model.nickname = dic.nickname;
                model.sex = dic.sex;
                model.U_language = dic.language;
                model.city = dic.city;
                model.province = dic.province;
                model.country = dic.country;
                model.headimgurl = dic.headimgurl;
                model.subscribe_time = DateTime.Now;
                model.userSex = dic.sex == 2 ? "女" : "男";
                model.userNum = Common.Tools.Get8Digits();
                model.F_id = 0;
                model.isfenxiao = 0;
                model.userMoney = 0;
                model.userYongJin = 0;
                weiUserM.Add(VIEW_YX_weiUser.ToEntity(model));

            }
           ViewBag.UserType= ConfigSettings.GetSysConfigValue("USERTYPE", model.isfenxiao.ToString());
            return View(model);
        }
        public ActionResult Index()
        {

            ViewBag.PageFlag = "Index";
            if (string.IsNullOrEmpty(CommonMethod.getCookie("userid")) || string.IsNullOrEmpty(CommonMethod.getCookie("openid")))
            {
                //CommonMethod.delCookie("userid");
                //登陆
                string code = Request.QueryString["code"];//获取授权code
                if (!string.IsNullOrEmpty(code))
                {
                    string openIdUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + WeChatConfig.GetKeyValue("appid") + "&secret=" + WeChatConfig.GetKeyValue("appsecret") + "&code=" + code + "&grant_type=authorization_code";
                    string content = Tools.GetPage(openIdUrl, "");
                    openid = Tools.GetJsonValue(content, "openid");//根据授权  获取当前人的openid
                    var model = weiUserM.GetModelWithOutTrace(u => u.openid == openid);
                    if (model != null)
                    {
                        CommonMethod.delCookie("openid");
                        CommonMethod.delCookie("userid");
                        CommonMethod.setCookie("openid", openid, 1);
                        CommonMethod.setCookie("userid", model.userNum, 1);
                    }
                }
                else
                {
                    string codeurl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx242aa47391c159f6&redirect_uri=http://www.aoshacar.com/AoShaCar/Index&response_type=code&scope=snsapi_userinfo&state=STATE&connect_redirect=1#wechat_redirect";
                    Response.Redirect(codeurl);
                }
                //end
            }
            ViewBag.PageFlag = "Index";
            var sid = TypeParser.ToInt32(Request["sid"]);
            if (sid <= 0)
                sid = 2;
            ViewBag.SupplierID = sid;
            ViewBag.SupplierName = supplierB.Get(s => s.SUPPLIER_ID == sid).SUPPLIER_NAME;
            ViewBag.CategoryList = VIEW_MST_CATEGORY.ToListViewModel(categoryB.GetListBy(c => c.ACTIVE == true));
            ViewBag.ProductList = VIEW_MST_PRD.ToListViewModel(prdB.GetListBy(p => p.ISCHECK == true && p.STATUS == true && p.ISHOT == true, p => p.SEQ_NO));

            return View();
        }
        public ActionResult CompanyList()
        {
            
            ViewBag.PageFlag = "CompanyList";
            ViewBag.SupplierList = VIEW_MST_SUPPLIER.ToListViewModel(supplierB.GetListBy(s => s.SYNCOPERATION!="D"));
            return View();
        }
        public ActionResult Transaction_Sale()
        {
            ViewBag.PageFlag = "OrderList";
            var status = false;
            var userid = CommonMethod.getCookie("userid");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(openid))
            {
                return Content("对不起，请登陆系统！");

            }
            var model = VIEW_VIEW_WeChatUser.ToViewModel(weiUserA.GetModelWithOutTrace(u => u.openid == openid));
            ViewBag.PageFlag = "Transaction";
            ViewBag.SupplierList = VIEW_MST_SUPPLIER.ToListViewModel(supplierB.GetListBy(s => s.SYNCOPERATION != "D"));
            ViewBag.userNum = userid;
            return View();
        }
        public ActionResult OrderList()
        {
            ViewBag.PageFlag = "OrderList";
            var status = false;
            var userid = CommonMethod.getCookie("userid");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(openid))
            {
                return Content("对不起，请登陆系统！");

            }
            var model = VIEW_VIEW_WeChatUser.ToViewModel(weiUserA.GetModelWithOutTrace(u => u.openid == openid));
            ViewBag.OrderList = VIEW_TG_order.ToListViewModel(orderB.GetListBy(s => s.UserId == userid && s.userOpenId == openid && s.trade_type == "ONLINE"&&s.SYNCOPERATION!="D"&&s.ssh_status==3, o => o.orderTime, false));
            return View(model);
        }
        public ActionResult DelegateList()
        {
            ViewBag.PageFlag = "DelegateList";
            var status = false;
            var userid = CommonMethod.getCookie("userid");
            var openid = CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(openid))
            {
                return Content("对不起，请登陆系统！");

            }
            var model = VIEW_VIEW_WeChatUser.ToViewModel(weiUserA.GetModelWithOutTrace(u => u.openid == openid));
            ViewBag.OrderList = VIEW_TG_order.ToListViewModel(orderB.GetListBy(s => s.UserId == userid && s.userOpenId == openid &&s.ssh_status==0 && s.trade_type == "ONLINE" && s.SYNCOPERATION != "D", o => o.orderTime, false));
            return View(model);
        }
        public ActionResult Category(string id)
        {
            ViewBag.isok = "OK";
            ViewBag.Appid = WeChatConfig.GetKeyValue("appid");
            ViewBag.Uri = WeChatConfig.GetKeyValue("shareurl");

            noncestr = CommonMethod.GetCode(16);

            string jsapi_ticket = Js_sdk_Signature.IsExistjsapi_ticket(token.IsExistAccess_Token());
            timestamp = DateTime.Now.Ticks.ToString().Substring(0, 10); ;
            string url = Request.Url.ToString().Replace("#", "");
            JssdkSignature = Js_sdk_Signature.GetjsSDK_Signature(noncestr, jsapi_ticket, timestamp, url);
            ViewBag.noncestr = noncestr;
            ViewBag.jsapi_ticket = jsapi_ticket;
            ViewBag.timestamp = timestamp;
            ViewBag.JssdkSignature = JssdkSignature;
            ViewBag.PageFlag = id;

            var sid = TypeParser.ToInt32(Request["sid"]);
            if (sid <= 0)
                sid = 2;
            ViewBag.SupplierID = sid;
            ViewBag.SupplierName = supplierB.Get(s => s.SUPPLIER_ID == sid).SUPPLIER_NAME;
            ViewBag.ProductList = VIEW_MST_PRD.ToListViewModel(prdB.GetListBy(p => p.CATE_ID == id && p.STATUS == true && p.ISCHECK == true, p => p.SEQ_NO));
            var model = VIEW_MST_CATEGORY.ToViewModel(categoryB.Get(c => c.CATE_CD == id));
            return View(model);
        }
        public ActionResult CheckTime()
        {
            var pid = Request["pid"];
            var model = VIEW_MST_PRD.ToViewModel(prdB.Get(p => p.PRD_CD == pid));
            var sid = Request["pid"];
            var Time = sysrefB.GetListBy(s => s.REF_TYPE == model.CATE_ID, s => s.REF_SEQ);
            return this.JsonFormat(Time, true, SysOperate.Load);
        }
        public ActionResult ProductDetail(string id)
        {
            ViewBag.Appid = WeChatConfig.GetKeyValue("appid");
            ViewBag.Uri = WeChatConfig.GetKeyValue("shareurl");

            noncestr = CommonMethod.GetCode(16);

            string jsapi_ticket = Js_sdk_Signature.IsExistjsapi_ticket(token.IsExistAccess_Token());
            timestamp = DateTime.Now.Ticks.ToString().Substring(0, 10); ;
            string url = Request.Url.ToString().Replace("#", "");
            JssdkSignature = Js_sdk_Signature.GetjsSDK_Signature(noncestr, jsapi_ticket, timestamp, url);
            ViewBag.noncestr = noncestr;
            ViewBag.jsapi_ticket = jsapi_ticket;
            ViewBag.timestamp = timestamp;
            ViewBag.JssdkSignature = JssdkSignature;
            var userid = CommonMethod.getCookie("userid");
            var openid = CommonMethod.getCookie("openid");
            ViewBag.userName = "";
            ViewBag.userTel = "";
            if (!string.IsNullOrEmpty(userid) && !string.IsNullOrEmpty(openid))
            {
                var user = VIEW_YX_weiUser.ToViewModel(weiUserM.GetModelWithOutTrace(u => u.openid == openid));
                if (user != null)
                {
                    ViewBag.userName = user.userRelname;
                    ViewBag.userTel = user.userTel;
                }
            }
            var sid = TypeParser.ToInt32(Request["sid"]);
            if (sid <= 0)
                sid = 2;
            ViewBag.SupplierID = sid;
            var supplier = supplierB.Get(s => s.SUPPLIER_ID == sid);
            ViewBag.SupplierName = supplier.SUPPLIER_NAME;
            ViewBag.Address = supplier.ADDRESS;
            ViewBag.Tel = supplier.TEL;
            var model = VIEW_MST_PRD.ToViewModel(prdB.Get(p => p.PRD_CD == id));
            ViewBag.ImgList = VIEW_MST_PRD_IMG.ToListViewModel(prdimgB.GetListBy(pm => pm.PRD_CD == id));
            ViewBag.AM = sysrefB.GetListBy(s => s.REF_TYPE == model.CATE_ID && s.REF_PARAM.Contains("AM_"), s => s.REF_SEQ);
            ViewBag.PM = sysrefB.GetListBy(s => s.REF_TYPE == model.CATE_ID && s.REF_PARAM.Contains("PM_"), s => s.REF_SEQ);
            ViewBag.PageFlag = model.CATE_ID;


            return View(model);
        }
        public ActionResult SubmitOrder(StockSale model)
        {
            bool status = false;
            var   openid = CommonMethod.getCookie("openid");
           var  userid = CommonMethod.getCookie("userid");
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(openid))
            {
               
                return this.JsonFormat(status, status, "对不起，请登陆系统！");
            }
          
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, status, "ERROR");
            var user = weiUserA.GetModelWithOutTrace(u => u.openid == openid);
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
   
        public ActionResult OrderDetail(string orderid)
        {
            //-----
            noncestr = CommonMethod.GetCode(16);
            string jsapi_ticket = Js_sdk_Signature.IsExistjsapi_ticket(WeChatConfig.IsExistAccess_Token2());
            timestamp = DateTime.Now.Ticks.ToString().Substring(0, 10); ;
            string url = Request.Url.ToString().Replace("#", "");
            JssdkSignature = Js_sdk_Signature.GetjsSDK_Signature(noncestr, jsapi_ticket, timestamp, url);

            ViewBag.Appid = WeChatConfig.GetKeyValue("appid");
            ViewBag.Uri = WeChatConfig.GetKeyValue("shareurl");
            ViewBag.noncestr = noncestr;
            ViewBag.jsapi_ticket = jsapi_ticket;
            ViewBag.timestamp = timestamp;
            ViewBag.PageFlag = "PayOrder";
            if (string.IsNullOrEmpty(CommonMethod.getCookie("userid")) || string.IsNullOrEmpty(CommonMethod.getCookie("openid")))
            {

                return Content("对不起，请登陆系统！");
            }
            var order = orderB.Get(o => o.orderNum == orderid);
            if (order == null)
                return Content("对不起，这个订单是错误的！");
            return View(VIEW_TG_order.ToViewModel(order));
        }
        public ActionResult ROrderDetail(string orderid)
        {
            //-----
            noncestr = CommonMethod.GetCode(16);
            string jsapi_ticket = Js_sdk_Signature.IsExistjsapi_ticket(WeChatConfig.IsExistAccess_Token2());
            timestamp = DateTime.Now.Ticks.ToString().Substring(0, 10); ;
            string url = Request.Url.ToString().Replace("#", "");
            JssdkSignature = Js_sdk_Signature.GetjsSDK_Signature(noncestr, jsapi_ticket, timestamp, url);

            ViewBag.Appid = WeChatConfig.GetKeyValue("appid");
            ViewBag.Uri = WeChatConfig.GetKeyValue("shareurl");
            ViewBag.noncestr = noncestr;
            ViewBag.jsapi_ticket = jsapi_ticket;
            ViewBag.timestamp = timestamp;
            ViewBag.PageFlag = "PayOrder";
            if (string.IsNullOrEmpty(CommonMethod.getCookie("userid")) || string.IsNullOrEmpty(CommonMethod.getCookie("openid")))
            {

                 return Content("对不起，请登陆系统！");
            }
            var order = orderB.Get(o => o.orderNum == orderid);
            if (order == null)
                return Content("对不起，这个订单是错误的！");
            return View(VIEW_TG_order.ToViewModel(order));
        }

        public ActionResult PayOrder(string orderid)
        {
            ViewBag.PageFlag = "PayOrder";
            var openid = CommonMethod.getCookie("openid");
            var userid = CommonMethod.getCookie("userid");
            var user = weiUserM.GetModelWithOutTrace(u => u.userNum == userid && u.openid == openid);
            if (user==null)
            {
                return Content("对不起，请登陆系统！");
            }
            ViewBag.UserType = user.isfenxiao;
            ViewBag.userYongJin = user.userYongJin;
            ViewBag.Userid = userid;
            ViewBag.Openid = openid;
            var order = orderB.Get(o => o.orderNum == orderid);
            if (order == null)
                return Content("对不起，这个订单是错误的！");

            //-----
            noncestr = CommonMethod.GetCode(16);
            string jsapi_ticket = Js_sdk_Signature.IsExistjsapi_ticket(WeChatConfig.IsExistAccess_Token2());
            timestamp = DateTime.Now.Ticks.ToString().Substring(0, 10); ;
            string url = Request.Url.ToString().Replace("#", "");
            JssdkSignature = Js_sdk_Signature.GetjsSDK_Signature(noncestr, jsapi_ticket, timestamp, url);

            ViewBag.Appid = WeChatConfig.GetKeyValue("appid");
            ViewBag.Uri = WeChatConfig.GetKeyValue("shareurl");
            ViewBag.noncestr = noncestr;
            ViewBag.jsapi_ticket = jsapi_ticket;
            ViewBag.timestamp = timestamp;

            //微信支付代码
            //
            //httpContext
            
            var packageReqHandler = new RequestHandler(HttpContext);
            packageReqHandler.Init();

            //时间戳 
           payTimeSamp = Senparc.Weixin.MP.TenPayLibV3.TenPayV3Util.GetTimestamp();
            //随机字符串 
            sj = CommonMethod.GetCode(16) + "_" + userid;
            //设置参数
            packageReqHandler.SetParameter("body", "商城-购买支付"); //商品信息 127字符
            packageReqHandler.SetParameter("appid", PayConfig.AppId);
            packageReqHandler.SetParameter("mch_id", PayConfig.MchId);
            packageReqHandler.SetParameter("nonce_str", sj);
            packageReqHandler.SetParameter("notify_url", PayConfig.NotifyUrl);
            packageReqHandler.SetParameter("openid", openid);
            packageReqHandler.SetParameter("out_trade_no", orderid + "_" + CommonMethod.GetCode(4)); //商家订单号
            packageReqHandler.SetParameter("spbill_create_ip", Request.UserHostAddress); //用户的公网ip，不是商户服务器IP
            packageReqHandler.SetParameter("total_fee", (Convert.ToDouble(order.yunPrice) * 100).ToString()); //商品金额,以分为单位(money * 100).ToString()
            packageReqHandler.SetParameter("trade_type", "JSAPI");
            packageReqHandler.SetParameter("attach", CommonMethod.GetCode(28));//自定义参数 127字符
            string sign = packageReqHandler.CreateMd5Sign("key", PayConfig.AppKey);//第一次签名结果

            #region 获取package包======================
            packageReqHandler.SetParameter("sign", sign);

            string data = packageReqHandler.ParseXML();//支付发送的数据 XML格式


            string prepayXml = Senparc.Weixin.MP.AdvancedAPIs.TenPayV3.Unifiedorder(data);
            //string prepayXml = WeiXin.GetPage("https://api.mch.weixin.qq.com/pay/unifiedorder", data);
            var xdoc = new XmlDocument();
            xdoc.LoadXml(prepayXml);
            XmlNode xn = xdoc.SelectSingleNode("xml");
            LogHelper.WriteLog(prepayXml);
            try
            {
                string PrepayId = WeChatConfig.GetXMLstrByKey("prepay_id", xdoc);
                Package = string.Format("prepay_id={0}", PrepayId);
                LogHelper.WriteLog(Package);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
                Package = string.Format("prepay_id={0}", "");
            }
            #endregion


            #region 设置支付参数 输出页面  该部分参数请勿随意修改 ==============
            var paySignReqHandler = new RequestHandler(HttpContext);
            paySignReqHandler.SetParameter("appId", PayConfig.AppId);
            paySignReqHandler.SetParameter("timeStamp", payTimeSamp);
            paySignReqHandler.SetParameter("nonceStr", sj);
            paySignReqHandler.SetParameter("package", Package);
            paySignReqHandler.SetParameter("signType", "MD5");
            PaySign = paySignReqHandler.CreateMd5Sign("key", PayConfig.AppKey);
            #endregion

            //--------END

            ViewBag.payTimeSamp = payTimeSamp;
            ViewBag.sj = sj;
            ViewBag.Package = Package; 
            ViewBag.PaySign = PaySign;
            return View(VIEW_TG_order.ToViewModel(order));
        }

        public ActionResult successPay(string ordernum)
        {
            var status = false;    
            var   openid = CommonMethod.getCookie("openid");
           var  userid = CommonMethod.getCookie("userid");
           var type = Request["paytype"];
           var user = weiUserM.GetModelWithOutTrace(u => u.userNum == userid && u.openid == openid);
           if (user == null)
           {
               return Content("对不起，请登陆系统！");
           }

           var order = orderB.GetModelWithOutTrace(o => o.orderNum == ordernum);
            if (order == null)
                return Content("对不起，这个订单是错误的！");
            if (string.IsNullOrEmpty(type))
            {
                //添加交易记录
                TG_transactionLog transactionlog = new TG_transactionLog();
                transactionlog.userId = userid;
                transactionlog.openid = openid;
                transactionlog.tranCate = 0;
                transactionlog.CateName = "微信消费";
                transactionlog.tranMoney = order.yunPrice;
                transactionlog.tranContent = "微信消费(订单号:" + ordernum + ")消费:" + order.total_fee + " 元，预付：" + order.yunPrice + " 元";
                transactionlog.orderNum = ordernum;
                transactionlog.remark4 = "1001";
                transactionlog.AddTime = DateTime.Now;
                transactionlogB.Add(transactionlog);
                YX_sysNews sysnew = new YX_sysNews();
                sysnew.userid = userid;
                sysnew.orderId = ordernum;
                sysnew.newsCate = "订单提醒";
                sysnew.newsContent = "用户微信支付成功";
                sysnew.newsState = 0;
                sysnew.Addtime = DateTime.Now;
                OperateContext.Current.BLLSession.IYX_sysNews_MANAGER.Add(sysnew);
                Common.Tools.GetPage("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + WeChatConfig.IsExistAccess_Token2(), WeChatConfig.GetSubcribePostData(openid, transactionlog.tranContent));
            }
            else if (user.isfenxiao >= 1 && user.userYongJin > order.total_fee)
            {
                order.ssh_status = 3;
                order.ispay = 3;
                order.yunPrice = order.total_fee;
                order.payTime = DateTime.Now;
                orderB.Modify(order, "yunPrice", "payTime", "ispay", "ssh_status");
                //添加交易记录
                TG_transactionLog transactionlog = new TG_transactionLog();
                transactionlog.userId = userid;
                transactionlog.openid = openid;
                transactionlog.tranCate = 0;
                transactionlog.CateName = "微信消费";
                transactionlog.tranMoney = order.total_fee;
                transactionlog.tranContent = "会员微信消费(订单号:" + ordernum + ")消费:" + order.total_fee + " 元";
                transactionlog.orderNum = ordernum;
                transactionlog.remark4 = "1002";
                transactionlog.AddTime = DateTime.Now;
                transactionlogB.Add(transactionlog);
                user.userYongJin = user.userYongJin - order.total_fee;
                weiUserM.Modify(user, "userYongJin");
                YX_sysNews sysnew = new YX_sysNews();
                sysnew.userid = userid;
                sysnew.orderId = ordernum;
                sysnew.newsCate = "订单提醒";
                sysnew.newsContent = "用户微信支付成功";
                sysnew.newsState = 0;
                sysnew.Addtime = DateTime.Now;
                OperateContext.Current.BLLSession.IYX_sysNews_MANAGER.Add(sysnew);
                Common.Tools.GetPage("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + WeChatConfig.IsExistAccess_Token2(), WeChatConfig.GetSubcribePostData(openid, transactionlog.tranContent));
            }
            else
            {
 
            }
            List<string> openids = new List<string>() { "oJUBAv7TVJBowlpJs58qBvCNCrAc", "oJUBAv1jDW_8IQyyvYyTjW2Q6o3w", "oJUBAv9bmEB2mFMSZyLkZBaTK540", "oJUBAv3rjppIvGenkn3h1MIo4wts", "oJUBAv7XiorX2muQXNft5ChU1OCk", "oJUBAv2Omhudt9cyqG_f2A1xMhUA" };
            foreach (var item in openids)
            {
                Common.Tools.GetPage("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + WeChatConfig.IsExistAccess_Token2(), WeChatConfig.GetSubcribePostData(item, "用户： " + user.userRelname + "  已成功预约。\n预约订单号：" + order.orderNum + "\n预约时间："+order.remark4+"  "+order.remark5+"\n 联系电话：" + user.userTel));
            }
            
            return Redirect("/aoshacar/OrderDetail?orderid=" + ordernum);
        }
        public ActionResult Notify()
        {
            MODEL.TG_order order = new TG_order();
            LogHelper.WriteLog("XXXXXXXXXXXXXXXX");
            //创建ResponseHandler实例
            ShengUI.Helper.payCls.ResponseHandler resHandler = new ShengUI.Helper.payCls.ResponseHandler(HttpContext);
            resHandler.setKey(PayConfig.AppKey);

            //判断签名
            try
            {
                string error = "";
                if (resHandler.isWXsign(out error))
                {
                    #region 协议参数=====================================
                    //--------------协议参数--------------------------------------------------------
                    //SUCCESS/FAIL此字段是通信标识，非交易标识，交易是否成功需要查
                    string return_code = resHandler.getParameter("return_code");
                    //返回信息，如非空，为错误原因签名失败参数格式校验错误
                    string return_msg = resHandler.getParameter("return_msg");
                    //微信分配的公众账号 ID
                    string appid = resHandler.getParameter("appid");

                    //以下字段在 return_code 为 SUCCESS 的时候有返回--------------------------------
                    //微信支付分配的商户号
                    string mch_id = resHandler.getParameter("mch_id");
                    //微信支付分配的终端设备号
                    string device_info = resHandler.getParameter("device_info");
                    //微信分配的公众账号 ID
                    string nonce_str = resHandler.getParameter("nonce_str");
                    //业务结果 SUCCESS/FAIL
                    string result_code = resHandler.getParameter("result_code");
                    //错误代码 
                    string err_code = resHandler.getParameter("err_code");
                    //结果信息描述
                    string err_code_des = resHandler.getParameter("err_code_des");

                    //以下字段在 return_code 和 result_code 都为 SUCCESS 的时候有返回---------------
                    //-------------业务参数---------------------------------------------------------
                    //用户在商户 appid 下的唯一标识
                    string openid = resHandler.getParameter("openid");
                    //用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
                    string is_subscribe = resHandler.getParameter("is_subscribe");
                    //JSAPI、NATIVE、MICROPAY、APP
                    string trade_type = resHandler.getParameter("trade_type");
                    //银行类型，采用字符串类型的银行标识
                    string bank_type = resHandler.getParameter("bank_type");
                    //订单总金额，单位为分
                    string total_fee = resHandler.getParameter("total_fee");
                    //货币类型，符合 ISO 4217 标准的三位字母代码，默认人民币：CNY
                    string fee_type = resHandler.getParameter("fee_type");
                    //微信支付订单号
                    string transaction_id = resHandler.getParameter("transaction_id");
                    //商户系统的订单号，与请求一致。
                    string out_trade_no = resHandler.getParameter("out_trade_no");
                    //商家数据包，原样返回
                    string attach = resHandler.getParameter("attach");
                    //支 付 完 成 时 间 ， 格 式 为yyyyMMddhhmmss，如 2009 年12 月27日 9点 10分 10 秒表示为 20091227091010。时区为 GMT+8 beijing。该时间取自微信支付服务器
                    string time_end = resHandler.getParameter("time_end");

                    #endregion
                    //支付成功
                    if (!out_trade_no.Equals("") && return_code.Equals("SUCCESS") && result_code.Equals("SUCCESS"))
                    {


                        LogHelper.WriteLog("Notify 页面  支付成功，支付信息：商家订单号：" + out_trade_no + "、支付金额(分)：" + total_fee + "、自定义参数：" + attach);

                        /**
                         *  这里输入用户逻辑操作，比如更新订单的支付状态
                         * 
                         * **/
                        LogHelper.WriteLog("============ 单次支付结束 ===============");
                        var orderid = "";
                        if (out_trade_no.Contains("_"))
                        {
                             orderid = out_trade_no.Substring(0, out_trade_no.Length - 5);
                        }
                        else
                        {
                            orderid = out_trade_no;
                       
                        }
                        LogHelper.WriteLog("============ 获取订单:" + orderid + "===============");
                        order = orderB.GetModelWithOutTrace(o => o.orderNum == orderid);
                        if (order!=null)//代表
                        {
                          //  string sql = "update TG_order set ispay=1,transaction_id='" + transaction_id + "',payTime='" + DateTime.Now + "' where orderNum='" + out_trade_no + "'";//支付成功，更新订单状态
                       
                            LogHelper.WriteLog(out_trade_no.Substring(0, out_trade_no.Length - 5));
                            order.payTime = DateTime.Now;
                            order.transaction_id = transaction_id;
                            order.ispay = 3;
                            order.ssh_status = 3;
                            orderB.Modify(order, "ispay", "transaction_id", "payTime", "ssh_status");
                            LogHelper.WriteLog("============ 修改订单:" + orderid + "===============");
                        }
                        total_fee = (Convert.ToInt32(total_fee) / 100).ToString();
                    }
                    else
                    {
                        LogHelper.WriteLog("Notify 页面  支付失败，支付信息   total_fee= " + total_fee + "、err_code_des=" + err_code_des + "、result_code=" + result_code);
                    }
                }
                else
                {
                    LogHelper.WriteLog("Notify 页面  isWXsign= false ，错误信息：" + error);
                }


            }
            catch (Exception ee)
            {
                LogHelper.WriteLog("Notify 页面  发送异常错误：" + ee.Message);
            }

            return Content("Notify 页面 ");
        }


        public ActionResult Consumption()
        {
            ViewBag.PageFlag = "Consumption";
            var status = false;
            var userid = "36798177";// CommonMethod.getCookie("userid");
            var openid = "oJUBAv2Omhudt9cyqG_f2A1xMhUA";// CommonMethod.getCookie("openid");
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(openid))
            {
                return Content("对不起，请登陆系统！");

            }

            ViewBag.TransactionLogList = VIEW_TG_transactionLog.ToListViewModel(transactionlogB.GetListBy(s => s.userId == userid && s.openid == openid && s.tranCate == 0, o => o.AddTime, false));
            return View();
        }
    }

}
