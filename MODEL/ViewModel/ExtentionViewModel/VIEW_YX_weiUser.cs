using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class VIEW_YX_weiUser
    {
        [Required(ErrorMessage="请选择一个门店")]
        public new string TREE_NODE_ID { get; set; }
        [Required(ErrorMessage = "请填写真实姓名")]
        public new string userRelname { get; set; }
        public bool IsReCharge { get; set; }
        public int? ReChargeMoney { get; set; }
        public string btnChargeMoney { get; set; }
        public VIEW_YX_weiUser()
        {
            userNum = Common.Tools.Get8Digits();
            userYongJin = 0;
            userMoney = 0;
        }

        public static YX_weiUser ToEntity(VIEW_VIEW_WeChatUser model)
        {
            YX_weiUser item = new YX_weiUser();
            item.Id = model.Id;
            item.subscribe = model.subscribe;
            item.openid = model.openid;
            item.nickname = model.nickname;
            item.sex = model.sex;
            item.city = model.city;
            item.province = model.province;
            item.country = model.country;
            item.U_language = model.U_language;
            item.headimgurl = model.headimgurl;
            item.subscribe_time = model.subscribe_time;
            item.lastAddTime = model.lastAddTime;
            item.subscribe_value = model.subscribe_value;
            item.userNum = model.userNum;
            item.subscribeState = model.subscribeState;
            item.userTel = model.userTel;
            item.RelName = model.RelName;
            item.userWXnum = model.userWXnum;
            item.F_id = model.F_id;
            item.F_idList = model.F_idList;
            item.AddTime = model.AddTime;
            item.isfenxiao = model.isfenxiao;
            item.jifen = model.jifen;
            item.userMoney = model.userMoney;
            item.userYongJin = model.userYongJin;
            item.StoreName = model.StoreName;
            item.StoreDescription = model.StoreDescription;
            item.LogoUrl = model.LogoUrl;
            item.userQQ = model.userQQ;
            item.userRelname = model.userRelname;
            item.userSex = model.userSex;
            item.userEmail = model.userEmail;
            item.remark1 = model.remark1;
            item.remark2 = model.remark2;
            item.remark3 = model.remark3;
            item.flat1 = model.flat1;
            item.flat2 = model.flat2;
            item.remark4 = model.remark4;
            item.remark5 = model.remark5;
            item.remark6 = model.remark6;
            item.flat7 = model.flat7;
            item.flat8 = model.flat8;
            item.RegTim1 = model.RegTim1;
            item.RegTim2 = model.RegTim2;
            item.TREE_NODE_ID = model.TREE_NODE_ID;
            return item;
        }
    }
}
