using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewPage
{
    /// <summary>
    /// 按钮图标 模型
    /// </summary>
    public class ButtonIcon
    {
       
        public string id { get; set; }
        public string text { get; set; }
        public bool selected { get; set; }
        public int type { get; set; }
    }
}
