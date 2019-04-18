using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class VIEW_TG_TXmoney
    {


        [Required(ErrorMessage = "请输入提现金额")]
        [Display(Name = "提现金额")]
        public Nullable<decimal> TXmoney { get; set; }
        [Required(ErrorMessage = "请输入银行卡号")]
        public string bankInfo { get; set; }
        [Required(ErrorMessage = "请输入开户人姓名")]
        public string bankUserInfo { get; set; }

        [Required(ErrorMessage = "请输入开户行信息")]
        public string remark1 { get; set; }
    }
}
