
using Common;
using IBLLService;
using MODEL.ViewModel;
using SampleUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SampleUI.Logic.Admin
{
    public class SeoController : Controller
    {
       
          
        [Description("[公司Config--Seo页面]")]
        public ActionResult Index()
        {
            UserOperateLog.WriteOperateLog("[公司Config--Seo页面]浏览公司Config--Seo页面" + SysOperate.Load.ToMessage(true));
            return View();
        }

       
    }
}
