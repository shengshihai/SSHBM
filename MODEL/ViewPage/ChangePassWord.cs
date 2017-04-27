using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MODEL.ViewPage
{
    /// <summary>
    /// 登陆用户 模型
    /// </summary>
    public class ChangePassWord
    {
        [Required(ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "accounts_password_required")]
        [StringLength(30, MinimumLength = 6, ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "string_length")]
        public string OldPassword { get; set; }
        [Required(ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "accounts_password_required")]
        [StringLength(30, MinimumLength = 6, ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "string_length")]
        public string Password { get; set; }
        [Required(ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "accounts_password_required")]
        [StringLength(30, MinimumLength = 6, ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "string_length")]
        [Compare("Password", ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "accounts_comparepassword")]
        public string NewPassword { get; set; }


        public ChangePassWord()
        {
          
        }
        public ChangePassWord(HttpContextBase context)
        {
            OldPassword = context.Request["OldPassword"];
            Password = context.Request["Password"];
            NewPassword = context.Request["NewPassword"];
        }
    }
}
