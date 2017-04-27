using IBLLService;
using ShengUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Common;
using System.Web;

namespace ShengUI.Logic.Admin
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            ViewBag.ReturnUrl = Request.QueryString["returnurl"];
           
        }

    }
}
