using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class VIEW_FW_MODULE
    {
         [Required]
        public new string MODULE_ID { get; set; }
         [Required]
        public new string MODULE_NAME { get; set; }
        public new string MODULE_LINK { get; set; }
         [Required]
        public new string ICON { get; set; }
         [Required]
        public new string MODULE_PID { get; set; }
        public new Nullable<int> SEQ_NO { get; set; }
        public new bool ISVISIBLE { get; set; }
        public new bool ISLEAF { get; set; }
        public new bool ISMENU { get; set; }
        public new string MODULE_CONTROLLER { get; set; }

    }
}
