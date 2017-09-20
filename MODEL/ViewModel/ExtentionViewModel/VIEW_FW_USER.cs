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
        [Required]
        public new string PASSWD { get; set; }
        [Required]
        [System.Web.Mvc.Compare("PASSWD", ErrorMessage = "密码和确认密码不匹配。")]
        public  string REPASSWD { get; set; }

    }
}
