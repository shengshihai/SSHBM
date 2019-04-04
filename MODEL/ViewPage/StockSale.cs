using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MODEL.ViewPage
{
    /// <summary>
    /// 按钮图标 模型
    /// </summary>
    public class StockSale
    {
        //^\d+(\.([1-9]|\d[1-9]))?$
        [Required(ErrorMessage = "起始价格不能为空")]
        [RegularExpression(@"^\d+(\.([1-9]))?$", ErrorMessage = "起始价格格式不正确(小数点后一位eg:6.1)")]
        public decimal startPrice { get; set; }
         [Required(ErrorMessage = "结束价格不能为空")]
        
         [RegularExpression(@"^\d+(\.([1-9]))?$", ErrorMessage = "起始价格格式不正确(小数点后一位eg:6.1)")]
        public decimal endPrice { get; set; }
         [Required(ErrorMessage = "股数不能为空")]
        [RegularExpression(@"[0-9]+",  ErrorMessage = "股票数量不正确")]
         public int Count { get; set; }
    }

}
