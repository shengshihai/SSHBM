using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MODEL.ViewPage
{
    /// <summary>
    /// 按钮图标 模型
    /// </summary>
    public class UserRegister
    {
        [Required(ErrorMessage = "请选择使用兼职的目的")]
        public string type { get; set; }
       [Required(ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "accounts_email_required")]
       [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "accounts_email_regular")]
        public string email { get; set; }
       [Required(ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "accounts_password_required")]
       [StringLength(30, MinimumLength = 6, ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "string_length")]
       //[Required(ErrorMessage = "请选择使用兼职的目的")]
        public string password { get; set; }
       //[Required(ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "accounts_password_required")]
       //[StringLength(30, MinimumLength = 6, ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "string_length")]
       //[Compare("password", ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "accounts_comparepassword")]
       // public string repassword { get; set; }
       // [Required]
       // public int country { get; set; }
       // public int city { get; set; }
       // public string chinesename { get; set; }
       // [Required]
       // public string firstname { get; set; }
       // [Required]
       // public string lastname { get; set; }
       // [StringLength(4, MinimumLength = 1, ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "number_length")]
        // [RegularExpression(@"^\w+[-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "number_regular")]
       // public string moblieareacode { get; set; }
       // [StringLength(20, MinimumLength = 4, ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "number_length")]
       // [RegularExpression(@"[0-9]+", ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "number_regular")]
       // public string mobliecode { get; set; }
       // public string mobile { get; set; }
       // [StringLength(4, MinimumLength = 1, ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "number_length")]
       // [RegularExpression(@"[0-9]+", ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "number_regular")]
       // public string telcountrycode { get; set; }
       // [StringLength(4, MinimumLength = 1, ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "number_length")]
       // [RegularExpression(@"[0-9]+", ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "number_regular")]
       // public string telareacode { get; set; }
       // [StringLength(20, MinimumLength = 4, ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "number_length")]
       // [RegularExpression(@"[0-9]+", ErrorMessageResourceType = typeof(Language.Resource), ErrorMessageResourceName = "number_regular")]
       // public string telcode { get; set; }
       // public string tel { get; set; }
       // [Required]
       // public string suppliername { get; set; }
       // [Required]
       // public int sendtype { get; set; }
       // public string cnsuppliername { get; set; }
       // public string Code { get; set; }

       
    }
}
