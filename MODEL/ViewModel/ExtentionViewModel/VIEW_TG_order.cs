using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class VIEW_TG_order
    {
        [Required]
        public new string orderNum { get; set; }
        [Required(ErrorMessage = "请选择支付类型")]
        public new string trade_type { get; set; }
        [Required(ErrorMessage = "请选择该订单的客户")]
        public new string UserId { get; set; }
        [Required(ErrorMessage = "请选择门店")]
        public new string remark3 { get; set; }
        [Required(ErrorMessage = "总金额不能为0")]
        public new decimal total_fee { get; set; }
        [Required(ErrorMessage = "订单时间不能为空")]
        public new System.DateTime orderTime { get; set; }
        [Required]
        public new int ssh_status { get; set; }
        [Required(ErrorMessage = "请选择消费项目")]
        public  string prd_cds { get; set; }
        [Required(ErrorMessage = "请选择消费项目数量")]
        public  string qtys { get; set; }
          [Required(ErrorMessage = "请选择消费项目")]
        public string[] productID { get; set; }
        public string[] productName { get; set; }
          [Required(ErrorMessage = "请选择消费项目数量")]
        public string[] productCount { get; set; }
          public bool IsNotice { get; set; }
        public decimal[] productPrice { get; set; }
        public decimal[] productMoney { get; set; }
        public List<VIEW_TG_Thing> Thinglist { get; set; }
    }
}
