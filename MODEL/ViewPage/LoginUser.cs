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
        
        [Required(ErrorMessage="请输入用户名")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }
        public bool IsAlways { get; set; }
    }
}
