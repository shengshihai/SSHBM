using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class VIEW_MST_CATALOG
    {
        public  List<VIEW_MST_CATALOG> children { get; set; }

        [Required]
        public new string CATALOG_CD { get; set; }

    }
}
