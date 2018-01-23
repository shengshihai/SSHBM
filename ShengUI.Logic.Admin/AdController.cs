
using Common;
using Common.Attributes;
using IBLLService;
using MODEL.ViewModel;
using ShengUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShengUI.Logic.Admin
{
    [AjaxRequestAttribute]
     [Description("广告管理")]
    public class AdController : Controller
    {
         [DefaultPage]
         [ActionParent]
         [ActionDesc("广告管理首页")]
         [Description("[广告管理]角色管理首页列表信息")]
         public ActionResult AdInfo()
        {
            
            return View();
        }
      
       
    }
}
