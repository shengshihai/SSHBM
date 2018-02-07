using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class VIEW_MST_PRD
    {
        [Required]
        public new string PRD_CD { get; set; }
        [Required]
        public new string CATE_ID { get; set; }
       
        public new string REMARK1 { get; set; }

        [Required]
        public new bool ISHOT { get; set; }


        [Required]
        public new bool STATUS { get; set; }
        public  string CATEGORY_NAME { get; set; }
    }
}
