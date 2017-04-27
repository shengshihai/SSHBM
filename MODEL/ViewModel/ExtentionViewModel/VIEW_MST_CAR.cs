using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class VIEW_MST_CAR
    {
     

        [Required(ErrorMessage = "车主不能为空")]
        public new string UserId { get; set; }
        [Required(ErrorMessage = "请填写汽车品牌")]
        public new string CAR_BRAND { get; set; }
        [Required(ErrorMessage = "请填写汽车型号")]
        public new string CAR_CATEGORY { get; set; }
        [Required(ErrorMessage = "请填写汽车颜色")]
        public new string CAR_COLOR { get; set; }
        public string USERNAME { get; set; }
        public int USERTYPE { get; set; }
        public string USERTYPENAME { get; set; }
        public string USERTEL { get; set; }
        public new System.DateTime AddTime{ get; set; }

        public  VIEW_MST_CAR()
        {
            AddTime = DateTime.Now;
            SYNCOPERATION = "A";
        }
    }
}
