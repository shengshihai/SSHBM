using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class VIEW_FW_USER
    {

          [Required]
        public new string USER_NAME { get; set; }
        [Required]
        public new string EMAIL { get; set; }

    }
}
