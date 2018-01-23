using IBLLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Common;
using MODEL.ViewModel;
using System.ComponentModel;
using ShengUI.Helper;
using Common.Attributes;


namespace ShengUI.Logic.Admin
{
    [AjaxRequestAttribute]
    [Description("日志管理")]
    public class OperateLogController :Controller
    {
          
        //
        // GET: /Admin/OperateLog/
        [DefaultPage]
        [ActionParent]
        [ActionDesc("日志管理首页")]
        [Description("[日志管理]日志管理首页列表信息")]
        [ViewPage]
        public ActionResult OperateLogInfo()
        {
            //记录操作日志
            return View();
        }

        [ActionDesc("获取系统操作日志信息")]
        [Description("[日志管理]获取系统操作日志信息(首页必须)")]
        public ActionResult GetLogsGrid()
        {

            //var strFilter = base.GetHqlstrByExtFilter(filters, "d");
            return this.JsonFormat("");
        }
        [ActionDesc("查看日志详情")]
        [Description("[日志管理]查看日志详情(Detail必须)")]
        [ViewPage]
        public ActionResult Detail()
        {

          
            return View();
        }
        [ActionDesc("清空三个月以前的日志")]
        [Description("[日志管理]清空三个月以前的日志")]
        public ActionResult DeleteThreeMonthLog()
        {

            //执行状态
            bool status = false;
            return this.JsonFormat(status,SysOperate.Delete);
        }


    }
}
