using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class VIEW_YX_weiUser
    {
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
