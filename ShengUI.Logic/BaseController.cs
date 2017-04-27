using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using IBLLService;
using MODEL.ViewModel;
using ShengUI.Helper;

namespace ShengUI.Logic
{
    public class BaseController : Controller
    {

      //  ISYS_REF_MANAGER sys_ref = OperateContext.Current.BLLSession.ISYS_REF_MANAGER;
        public BaseController()
        {

            //ViewBag.REF = VIEW_SYS_REF.ToListViewModel(sys_ref.GetListBy(r => true));
        }
    }
}
