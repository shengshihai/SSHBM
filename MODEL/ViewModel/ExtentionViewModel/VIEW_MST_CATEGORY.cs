using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class VIEW_MST_CATEGORY
    {
        public List<VIEW_MST_CATEGORY> children { get; set; }

        [Required]
        public new string CATE_CD { get; set; }
        [Required(ErrorMessage="分类名称不能为空")]
        public new string CATEGORY_NAME { get; set; }
    }
}
