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
    }
}
