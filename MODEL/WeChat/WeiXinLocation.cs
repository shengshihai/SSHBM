using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MODEL.WeChat
{
    public class WeiXinLocation
    {
        private string ToUserName;//开发者微信号 

        public string ToUserName1
        {
            get { return ToUserName; }
            set { ToUserName = value; }
        }
        private string FromUserName;//发送方帐号（一个OpenID） 

        public string FromUserName1
        {
            get { return FromUserName; }
            set { FromUserName = value; }
        }
        private int CreateTime;//消息创建时间 （整型） 

        public int CreateTime1
        {
            get { return CreateTime; }
            set { CreateTime = value; }
        }
        private string MsgType;//消息类型

        public string MsgType1
        {
            get { return MsgType; }
            set { MsgType = value; }
        }
        private string Event;//事件名称  上报地理位置

        public string Event1
        {
            get { return Event; }
            set { Event = value; }
        }

        private string Latitude;//经度

        public string Latitude1
        {
            get { return Latitude; }
            set { Latitude = value; }
        }

        private string Longitude;//纬度

        public string Longitude1
        {
            get { return Longitude; }
            set { Longitude = value; }
        }

        private string Precision;//精确度

        public string Precision1
        {
            get { return Precision; }
            set { Precision = value; }
        }
    }
}