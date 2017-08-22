using Common;
using IBLLService;
using MODEL.WeChat;
using Newtonsoft.Json.Linq;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities.Menu;
using ShengUI.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Xml;

namespace ShengUI
{
    /// <summary>
    /// WeChat 的摘要说明
    /// </summary>
    public class WeChat : IHttpHandler
    {
        
        IYX_weiXinMenus_MANAGER wechatMenus = OperateContext.Current.BLLSession.IYX_weiXinMenus_MANAGER;
        IYX_weiUser_MANAGER weiuserB = OperateContext.Current.BLLSession.IYX_weiUser_MANAGER;
        IYX_text_MANAGER textM = OperateContext.Current.BLLSession.IYX_text_MANAGER;
        IYX_news_MANAGER newsM = OperateContext.Current.BLLSession.IYX_news_MANAGER;
        IYX_sysConfigs_MANAGER sysConfigs = OperateContext.Current.BLLSession.IYX_sysConfigs_MANAGER;
        IWeChat_MANAGER wechat = OperateContext.Current.BLLSession.IWeChat_MANAGER;
        ITokenConfig_MANAGER token = OperateContext.Current.BLLSession.ITokenConfig_MANAGER;
        public static string AppId = "wx5affe01247a2482c"; //微信公众号 appId
        public static string Appsecret = "7b8920b4accebc8cb7e9cbab14798e60";  //微信公众号密钥
        public static string baiduAk = "O5R6ObuaqtaC1K9FUysGTbNx";//百度开发者：baiduAk
        public static string apisecret = "3F7F3259DB69447487E9C4BBC123C025";//微信支付秘钥
        public static string URLToken = "sohovan";//自己填写的Token  和开启开发者模式时填写的一样。

        public static string certPath = "";//HttpContext.Current.Server.MapPath("/fenxiao/userHome/hb/zhengshu/apiclient_cert.p12");//微信商户平台证书路径
        public static string certPwd = "";//GetKeyValue("mchid");//证书密码  及   商户平台商户号  初始密码  可以修改
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Appsecret = WeChatConfig.GetKeyValue("appsecret");
            AppId = WeChatConfig.GetKeyValue("appid");
            apisecret = WeChatConfig.GetKeyValue("apisecret");
            URLToken = WeChatConfig.GetKeyValue("token"); 
            try
            {
                if (HttpContext.Current.Request.HttpMethod.ToUpper() == "GET")
                {
                    if (!AccessTokenContainer.CheckRegistered(AppId))
                    {
                        AccessTokenContainer.Register(AppId, Appsecret);
                    }

                    Auth(); //微信接入的测试  成为开发者第一步
                }
                if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
                {
                    if (!AccessTokenContainer.CheckRegistered(AppId))
                    {
                        AccessTokenContainer.Register(AppId, Appsecret);
                    }



               responseMsg();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("一般处理程序入口错误：", ex);
            }
           // context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
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

            string echoString = HttpContext.Current.Request.QueryString["echostr"];
            string signature = HttpContext.Current.Request.QueryString["signature"];
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = HttpContext.Current.Request.QueryString["nonce"];

            if (CheckSignature(token, signature, timestamp, nonce))
            {
                if (!string.IsNullOrEmpty(echoString))
                {
                    HttpContext.Current.Response.Write(echoString);
                    // HttpContext.Current.Response.End();
                }
            }
        }
        #endregion

        #region responseMsg 事件消息回复
        /// <summary>
        /// 事件消息回复
        /// </summary>
        public void responseMsg()
        {
            string content = "";//发送的内容
            CreateMenu();//创建菜单

            XmlDocument EventOrNews_XML = GetMsgXML();
            string EventName = (object)EventOrNews_XML.SelectSingleNode("xml").SelectSingleNode("Event") == null ? "" : EventOrNews_XML.SelectSingleNode("xml").SelectSingleNode("Event").InnerText;//事件类型
            string EventKey = (object)EventOrNews_XML.SelectSingleNode("xml").SelectSingleNode("EventKey") == null ? "" : EventOrNews_XML.SelectSingleNode("xml").SelectSingleNode("EventKey").InnerText;//事件KEY值，与自定义菜单接口中KEY值对应 
            string MsgType = (object)EventOrNews_XML.SelectSingleNode("xml").SelectSingleNode("MsgType") == null ? "" : EventOrNews_XML.SelectSingleNode("xml").SelectSingleNode("MsgType").InnerText;//消息类型  语音为voice  文本为 text
            string UserOpenId = EventOrNews_XML.SelectSingleNode("xml").SelectSingleNode("FromUserName").InnerText;
            LogHelper.WriteLog(UserOpenId);
            #region 关注
            if (!string.IsNullOrEmpty(EventName) && EventName.Trim().ToLower() == "subscribe")//关注 - 事件类型
            {
                //发送图文
                string newsTitle2 = "欢迎加入傲鲨汽车生活馆";
                string newsDescription2 = "“欢迎加入傲鲨汽车生活馆“ ";
                string newsPicUrl2 = "http://mmbiz.qpic.cn/mmbiz_jpg/x2FJcrdnw52ibeuGbIOJpiadG3ZjERJZDVewfKaklpxlnMOeM8gdcIKzvtWQXdiaDMibxfibkLWmvBJeicgRdhuwaPOw/640?wx_fmt=jpeg&tp=webp&wxfrom=5&wx_lazy=1";
                string newsUrl2 = "http://mp.weixin.qq.com/s/LbQOK2MbaY3pM6eUQfW_sQ";
                Senparc.Weixin.MP.Entities.Article arc2 = new Senparc.Weixin.MP.Entities.Article();
                arc2.Title = newsTitle2;
                arc2.Description = newsDescription2;
                arc2.PicUrl = newsPicUrl2;
                arc2.Url = newsUrl2;
                List<Senparc.Weixin.MP.Entities.Article> list2 = new List<Senparc.Weixin.MP.Entities.Article>();
                list2.Add(arc2);
                CustomApi.SendNews(WeChatConfig.IsExistAccess_Token2(), UserOpenId, list2);
                //发送图文结束
                LogHelper.WriteLog("subscribe");

                int isfenxiao = 0;
                //
                int FId = 0;
                if (EventKey.Contains("qrscene_"))//、用户通过带有场景值的二维码进行的关注事件   添加分享表   上下级关系
                {
                    isfenxiao = 1;
                    string[] Uids = EventKey.Split('_');//获取情景值
                    LogHelper.WriteLog("进去了" + EventKey + "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"+Uids.Length.ToString());
                    try
                    {
                        FId = Convert.ToInt32(Uids[1]);
                    }
                    catch
                    {
                        FId = 0;
                    }
                }

                Senparc.Weixin.MP.AdvancedAPIs.User.UserInfoJson dic = UserApi.Info(WeChatConfig.IsExistAccess_Token2(), UserOpenId);
     
                if (weiuserB.GetListasNoTrackingBy(w => w.openid == dic.openid).Count <= 0)
                {
                    var wechatuser = new MODEL.YX_weiUser();
                    wechatuser.subscribe = dic.subscribe;
                    wechatuser.openid = dic.openid;
                    wechatuser.nickname = dic.nickname;
                    wechatuser.sex = dic.sex;
                    wechatuser.U_language = dic.language;
                    wechatuser.city = dic.city;
                    wechatuser.province = dic.province;
                    wechatuser.country = dic.country;
                    wechatuser.headimgurl = dic.headimgurl;
                    wechatuser.subscribe_time = DateTime.Now;
                    wechatuser.userSex = dic.sex == 2 ? "女" : "男";
                    wechatuser.userNum = Common.Tools.Get8Digits();
                    wechatuser.F_id = 0;
                    wechatuser.isfenxiao = 0;
                    wechatuser.userMoney = 0;
                    wechatuser.userYongJin = 0;
                    wechatuser.TREE_NODE_ID = "144e42158f676695";
                    weiuserB.Add(wechatuser);
                }
            }
             #endregion
            #region 其他


            if (!string.IsNullOrEmpty(EventName) && EventName.Trim().ToLower() == "unsubscribe")//取消订阅。
            {
               // UserBll.upState(UserOpenId, 1, 0);//修改当前状态

            }
            if (!string.IsNullOrEmpty(MsgType) && MsgType.Trim().ToLower() == "voice")
            {

            }
            if (!string.IsNullOrEmpty(MsgType) && MsgType.Trim().ToLower() == "image")
            {
                string touser = UserOpenId;
                string fromuser = EventOrNews_XML.SelectSingleNode("xml").SelectSingleNode("ToUserName").InnerText;
                string CreateTime = EventOrNews_XML.SelectSingleNode("xml").SelectSingleNode("CreateTime ").InnerText;
                HttpContext.Current.Response.Write(GetKeFuXML(touser, fromuser, CreateTime));
            }
            #region CliCK
            if (!string.IsNullOrEmpty(EventName) && EventName.Trim().ToLower() == "click")//菜单单击事件
            {
                LogHelper.WriteLog("click");

                List<WeChatMenus> ClickMenus = new List<WeChatMenus>();
                object ClickMenusList = CacheHelper.GetCache("ClickMenusList");//设置单击菜单缓存  防止多次访问数据库
                if (ClickMenusList != null)
                {
                    ClickMenus = (List<WeChatMenus>)ClickMenusList;
                }
                else
                {
                    ClickMenus = wechatMenus.GetClickMenus();
                    if (ClickMenus != null)
                    {
                        CacheHelper.SetCache("ClickMenusList", ClickMenus, TimeSpan.FromMinutes(60));
                    }
                }


                foreach (var item in ClickMenus)
                {
                    if (!string.IsNullOrEmpty(EventName) && EventKey.Trim().ToUpper() == item.WX_MenusKey_URL.ToUpper())
                    {
                        string flat1 = item.flat1.ToString();//用于匹配那张消息表：例如，YX_text  YX_news   YX_image等
                        int Id = item.Id;//
                        string tableName = "";//表名
                        switch (flat1)
                        {
                            case "1": tableName = "YX_text"; break;
                            case "2": tableName = "YX_news"; break;
                            case "3": tableName = "YX_image"; break;
                            case "4": tableName = "YX_voice"; break;
                            case "5": tableName = "YX_video"; break;
                            case "6": tableName = "YX_music"; break;
                        }
                        if (tableName == "YX_text")//发送文本消息
                        {
                            LogHelper.WriteLog(Id.ToString());
                            LogHelper.WriteLog("YX_text-" + EventKey);
                            MODEL.ViewModel.VIEW_YX_text textdt = new MODEL.ViewModel.VIEW_YX_text();
                            object text_dt = CacheHelper.GetCache(EventKey);//设置主菜单缓存  防止多次访问数据库V1003_TODAY_MUSIC
                            if (text_dt != null)
                            {
                                textdt = (MODEL.ViewModel.VIEW_YX_text)text_dt;
                            }
                            else
                            {
                                textdt = textM.GetClickMenusText(Id);
                                if (textdt != null)
                                {
                                    CacheHelper.SetCache(EventKey, textdt, TimeSpan.FromMinutes(60));
                                }
                            }

                            if (textdt != null)
                            {
                                string msgContent = textdt.msgContent;
                              Common.Tools.GetPage("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + WeChatConfig.IsExistAccess_Token2(), GetSubcribePostData(UserOpenId, msgContent));
                            }
                        }
                        if (tableName == "YX_news")//发送图文消息
                        {
                            LogHelper.WriteLog("YX_news-" + EventKey);

                            MODEL.ViewModel.VIEW_YX_news newsdt = new MODEL.ViewModel.VIEW_YX_news();
                            object news_dt = CacheHelper.GetCache(EventKey);//设置主菜单缓存  防止多次访问数据库V1003_TODAY_MUSIC
                            if (news_dt != null)
                            {
                                newsdt = (MODEL.ViewModel.VIEW_YX_news)news_dt;
                            }
                            else
                            {
                                newsdt = newsM.GetClickMenusNews(Id);
                                if (newsdt != null)
                                {
                                    CacheHelper.SetCache(EventKey, newsdt, TimeSpan.FromMinutes(60));
                                }
                            }

                            if (newsdt != null)
                            {
                                string newsTitle = newsdt.newsTitle;
                                string newsDescription = newsdt.newsDescription;
                                string newsPicUrl = newsdt.newsPicUrl;
                                string newsUrl = newsdt.newsUrl;
                                Senparc.Weixin.MP.Entities.Article arc = new Senparc.Weixin.MP.Entities.Article();
                                arc.Title = newsTitle;
                                arc.Description = newsDescription;
                                arc.PicUrl = newsPicUrl;
                                arc.Url = newsUrl;
                                List<Senparc.Weixin.MP.Entities.Article> list = new List<Senparc.Weixin.MP.Entities.Article>();
                                list.Add(arc);
                                CustomApi.SendNews(WeChatConfig.IsExistAccess_Token2(), UserOpenId, list);
                            }
                        }
                        if (tableName == "YX_image")//发送图片消息
                        {
                            //DataTable imagedt = new DataTable();

                            //imagedt = wxdb.GetClickMenusMsg(tableName, Id);

                            //if (imagedt != null)
                            //{

                            //}
                        }
                        if (tableName == "YX_voice")//发送语音消息
                        {
                            //DataTable voicedt = new DataTable();

                            //voicedt = wxdb.GetClickMenusMsg(tableName, Id);
                        }
                        if (tableName == "YX_video")//发送视频消息
                        {
                            //DataTable videodt = new DataTable();
                            //videodt = wxdb.GetClickMenusMsg(tableName, Id);
                        }
                        if (tableName == "YX_music")//发送音乐消息
                        {
                            //DataTable musicdt = new DataTable();
                            //musicdt = wxdb.GetClickMenusMsg(tableName, Id);
                        }

                    }
                }

            }
            #endregion
            if (!string.IsNullOrEmpty(EventName) && EventName.Trim().ToLower() == "scancode_push")//菜单单击事件
            {
                LogHelper.WriteLog("scancode_push");
            }
            #endregion
        }
        #endregion

        #region 获取接收事件推送的XML结构
        /// <summary>
        /// 获取接收事件推送的XML结构
        /// </summary>
        /// <returns></returns>
        public static XmlDocument GetMsgXML()
        {
            Stream stream = HttpContext.Current.Request.InputStream;
            byte[] byteArray = new byte[stream.Length];
            stream.Read(byteArray, 0, (int)stream.Length);
            string postXmlStr = System.Text.Encoding.UTF8.GetString(byteArray);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(postXmlStr);
            return xmldoc;
        }
         #endregion

        #region 跳转多客服XML结构
        /// <summary>
        /// 跳转多客服数据
        /// </summary>
        /// <returns></returns>
        /// 
        //<xml><ToUserName><![CDATA[ofyKns-7TTnU1LiNSnasxdERHXdE]]></ToUserName><FromUserName><![CDATA[jiuyuantang007]]></FromUserName><CreateTime>1425111485</CreateTime><MsgType><![CDATA[transfer_customer_service]]></MsgType><TransInfo><KfAccount>![CDATA[chenwolong@jiuyuantang007]]</KfAccount></TransInfo></xml> 
        /// <summary>
        /// 跳转多客服 随机分配客服
        /// </summary>
        /// <param name="touser">接收方帐号（收到的OpenID） </param>
        /// <param name="fromuser">开发者微信号 </param>
        /// <param name="CreateTime"> 	消息创建时间 （整型） </param>
        /// <returns></returns>
        public static string GetKeFuXML(string touser, string fromuser, string CreateTime)
        {
            string s = "<xml><ToUserName><![CDATA[" + touser + "]]></ToUserName><FromUserName><![CDATA[" + fromuser + "]]></FromUserName><CreateTime>" + CreateTime + "</CreateTime><MsgType><![CDATA[transfer_customer_service]]></MsgType></xml>";

            return s;
        }
        #endregion



        #region 关注发送文本Postdata
        /// <summary>
        /// 关注发送文本Postdata
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public static string GetSubcribePostData(string openId, string con)
        {
            return "{\"touser\":\"" + openId + "\",\"msgtype\":\"text\",\"text\":{\"content\":\"" + con + "\"}}";
        }
        #endregion
        #region 创建菜单
        /// <summary>
        /// 创建菜单
        /// </summary>
        public void CreateMenu()
        {
            ButtonGroup bg = new ButtonGroup();
            List<WeChatMenus> list = new List<WeChatMenus>();
            object CreateMenudt = CacheHelper.GetCache("CreateMenudt");//设置主菜单缓存  防止多次访问数据库
            if (CreateMenudt != null)
            {
                list = (List<WeChatMenus>)CreateMenudt;
            }
            else
            {
                list = wechatMenus.GetMainMenus();
                if (list.Count>0)
                {
                    CacheHelper.SetCache("CreateMenudt", list, TimeSpan.FromMinutes(60));
                }
            }
            //
            List<WeChatMenus> childlist = new List<WeChatMenus>();
            object childl_ist = CacheHelper.GetCache("childlist");//设置子菜单缓存  防止多次访问数据库V1003_TODAY_MUSIC
            if (childlist.Count>0)
            {
                childlist = (List<WeChatMenus>)childl_ist;
            }
            else
            {
                childlist = wechatMenus.GetChildMenus();
                if (childlist.Count > 0)
                {
                    CacheHelper.SetCache("childlist", childlist, TimeSpan.FromMinutes(60));
                }
            }
            //
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    string menuType = item.WX_MenuType;
                    if (menuType != "0")//一级菜单类型不为0时，创建一级菜单 并赋予事件
                    {
                        if (menuType == "1")//click菜单
                        {
                            bg.button.Add(new SingleClickButton()
                            {
                                name = item.WX_menuName,
                                key =item.WX_MenusKey_URL,
                                type = ButtonType.click.ToString(),//默认已经设为此类型，这里只作为演示
                            });
                        }
                        else//view菜单
                        {
                            bg.button.Add(new SingleViewButton()
                            {
                                name =item.WX_menuName,
                                url = item.WX_MenusKey_URL,
                                type = ButtonType.view.ToString(),//默认已经设为此类型，这里只作为演示
                            });
                        }
                    }
                    else
                    {
                        var subButton = new SubButton()
                        {
                            name = item.WX_menuName
                        };

                        foreach (var childitem in childlist)
                       {
                           if (childitem.WX_Fid == item.Id)
                            {
                                if (childitem.WX_MenuType == "1")//click菜单
                                {
                                    subButton.sub_button.Add(new SingleClickButton()
                                    {
                                        key = childitem.WX_MenusKey_URL,
                                        name = childitem.WX_menuName
                                    });
                                }
                                else if (childitem.WX_MenuType== "2")////view菜单
                                {
                                    subButton.sub_button.Add(new SingleViewButton()
                                    {
                                        url = childitem.WX_MenusKey_URL,
                                        name = childitem.WX_menuName
                                    });
                                }
                                else
                                {
                                    subButton.sub_button.Add(new SingleClickButton()
                                    {
                                        key = childitem.WX_MenusKey_URL,
                                        name = childitem.WX_menuName
                                    });
                                }
                            }
                        }
                        bg.button.Add(subButton);
                    }

                }
                var result = CommonApi.CreateMenu(WeChatConfig.IsExistAccess_Token2(), bg);
               // var result = CommonApi.CreateMenu(FirstAccess_Token(AppId, Appsecret), bg);
            }



        }
        #endregion
    }
}