using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewPage
{
    /// <summary>
    /// 登陆的用户 模型
    /// </summary>
    public class LoginedUser
    {

        public int Type { get; set; }//1为供应商0为空2为采购商
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
