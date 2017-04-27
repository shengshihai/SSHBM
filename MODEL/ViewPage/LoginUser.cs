using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewPage
{
    /// <summary>
    /// 登陆用户 模型
    /// </summary>
    public class LoginUser
    {
        
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsAlways { get; set; }
    }
}
