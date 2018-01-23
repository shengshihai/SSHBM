/*  作者：       盛世海
*  创建时间：   2012/7/19 10:36:31
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using MODEL.ViewModel;
using Common;
using Common.Attributes;
using IBLLService;
using ShengUI.Helper;
using MODEL;

using Common.EfSearchModel.Model;


namespace ShengUI.Logic.Admin
{
    [AjaxRequestAttribute]
    [Description("物流管理")]
    public class LogisticalController : Controller
    {

        [DefaultPage]
        [ActionParent]
        [ActionDesc("物流管理首页")]
        [Description("[物流管理]物流管理首页列表信息")]
        public ActionResult LogisticalIndex()
        {
            return View();
        }

        [ActionDesc("物流管理详细信息")]
        [Description("[物流管理]物流详细信息(add,Update,Detail必备)")]
        public ActionResult LogisticalDetail()
        {
          
            return View();

        }
        [ActionDesc("查询快递单号")]
        [Description("[物流管理]查询快递单号")]
        public ActionResult SeeLogisticalInfo()
        {

            return View();

        }
        [ActionDesc("叫快递")]
        [Description("[物流管理]叫快递")]
        public ActionResult SayLogistical()
        {

            return View();

        }
    }
}
