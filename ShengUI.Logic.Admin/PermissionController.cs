using IBLLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Common;
using System.ComponentModel;
using ShengUI.Helper;
using Common.Attributes;
using MODEL.ViewPage;
using MODEL.ActionModel;
using MODEL.ViewModel;
using MODEL.DataTableModel;

namespace ShengUI.Logic.Admin
{
    public class PermissionController : Controller
    {
        public IFW_PERMISSION_MANAGER PermissionManager = OperateContext.Current.BLLSession.IFW_PERMISSION_MANAGER;


        [DefaultPage]
        [ActionParent]
        [ActionDesc("权限维护页")]
        [Description("[权限维护页]按钮管理")]
        public ActionResult PermissionInfo()
        {

            var data = PermissionManager.GetPermission();
            ViewBag.PermissionList = data;
            //UserOperateLog.WriteOperateLog("[系统权限管理]浏览系统权限维护页" + SysOperate.Load.ToMessage(true));
            return View();
        }
        [ActionDesc("获取动作sql")]
        [Description("[权限维护页]请求所有控制器的动作信息")]  
        public ActionResult GetAllAction()
        {
            DataTableRequest gridRequest = new DataTableRequest(HttpContext);
            var list = PermissionManager.GetListBy(p => true).ToList();
            var data = ConfigSettings.GetAllAction();
            string sqlstr = @" INSERT INTO FW_PERMISSION (PERMISSION_ID, PERMISSION_PID, NAME, AREANAME, CONTROLLERNAME, ACTIONNAME, ISLINK, LINKURL, REMARK, ISSHOW, ISBUTTON, CREATE_DT,SEQ_NO ) VALUES('{0}','{1}',N'{2}','{3}','{4}','{5}','{6}','{7}',N'{8}','{9}','{10}',{11},{12});</BR>";
            int i = 1;
            StringBuilder sb = new StringBuilder();
            foreach (var item in data)
            {
                if (list.Where(p => p.PERMISSION_ID == item.CD).Count() <= 0)
                {
                    sb.Append(string.Format(sqlstr, item.CD, item.PCD, item.Name, "Admin", item.ControllerName, item.ActionName, item.IsLink, item.LinkUrl, item.Description, "Y", item.IsButton, "Getdate()", i));
                }
              i++;
            }
            return Content(sb.ToString());
            //忽略掉公共页面的权限动作
            //return this.JsonFormat(
            //    new DataTableGrid()
            //    {
            //        rows = LINQHelper.GetIenumberable<MVCAction>(data,
            //               p => p.ControllerName.ToLower() != "",
            //               q => gridRequest.SortOrder?"DESC":"ASC", 10000,
            //               gridRequest.PageNumber),
            //        total = data.Count()
            //    });

        }
        ///// <summary>
        ///// 请求权限功能列表信息
        ///// </summary>
        ///// <returns></returns>
        //[Description("[系统权限维护页Ajax请求]请求权限功能列表信息(返回Grid)(主页必须)")]
        //public ActionResult GetPermissionForGrid()
        //{
        //    EasyUIGridRequest request = new EasyUIGridRequest(HttpContext);

        //    return this.JsonFormat(PermissionManager.GetPermissionGridTree(request));
        //}
        //[Description("[系统权限维护页]添加动作")]
        //[EasyUIExceptionResult]
        //public ActionResult Add()
        //{
        //    bool status = false;
        //    try
        //    {
        //        ViewModelButton viewModel = new ViewModelButton(HttpContext);
        //        viewModel.pRemark =
        //            !viewModel.pActionName.IsNullOrEmpty() && !viewModel.pControllerName.IsNullOrEmpty() ? ConfigSettings.GetAllAction()
        //            .Where(p => p.ActionName == viewModel.pActionName && p.ControllerName == viewModel.pControllerName)
        //            .SingleOrDefault()
        //            .Description
        //            : "";
        //        PermissionManager.Add(ViewModelButton.ToEntity(viewModel));
        //    }
        //    catch (Exception e)
        //    {
        //        UserOperateLog.WriteOperateLog("[系统权限管理]添加权限动作信息" + SysOperate.Add.ToMessage(status), e.ToString());
        //    }
        //    UserOperateLog.WriteOperateLog("[系统权限管理]添加权限动作信息" + SysOperate.Add.ToMessage(status));
        //    return this.JsonFormat(status, status, SysOperate.Add);

        //}
        //[Description("[系统权限维护页]修改动作")]
        //[EasyUIExceptionResult]
        //public ActionResult Update()
        //{
        //    var model = new MODEL.Sample_Permission();
        //    string[] ModifyParas = { "pAreaName", "pActionName", "pName", "pIsShow", "pScript", "pIco", "pControllerName", "pIsButton", "pOrder", "pRemark" };
        //    bool status = false;
        //    try
        //    {
        //        ViewModelButton viewModel = new ViewModelButton(HttpContext);
        //        model.pId = viewModel.pId;
        //        model.pAreaName = viewModel.pAreaName;
        //        model.pActionName = viewModel.pActionName;
        //        model.pName = viewModel.pName;
        //        model.pIsShow = viewModel.pIsShow;
        //        model.pScript = viewModel.pScript;
        //        model.pIco = viewModel.pIco;
        //        model.pControllerName = viewModel.pControllerName;
        //        model.pIsButton = viewModel.pIsButton;
        //        //model.pParentId = viewModel.pParentId;
        //        model.pOrder = viewModel.pOrder;
        //        model.pRemark =
        //        !viewModel.pActionName.IsNullOrEmpty() && !viewModel.pControllerName.IsNullOrEmpty() ?
        //         ConfigSettings.GetAllAction()
        //        .Where(p => p.ActionName == viewModel.pActionName && p.ControllerName == viewModel.pControllerName)
        //        .SingleOrDefault()
        //        .Description
        //        : "";
        //        PermissionManager.Modify(model, ModifyParas);
        //        status = true;
        //    }
        //    catch (Exception e)
        //    {
        //        UserOperateLog.WriteOperateLog("[系统权限管理]修改权限动作信息ID:" + model.pId + SysOperate.Update.ToMessage(status), e.ToString());
        //        return this.JsonFormat(status, status, SysOperate.Update);
        //    }
        //    UserOperateLog.WriteOperateLog("[系统权限管理]修改权限动作信息ID:" + model.pId + SysOperate.Update.ToMessage(status));
        //    return this.JsonFormat(status, status, SysOperate.Update);

        //}

        //[Description("[系统权限维护页]软删除动作")]
        //[EasyUIExceptionResult]
        //public ActionResult Delete()
        //{
        //    ViewModelButton viewModel = new ViewModelButton(HttpContext);
        //    MODEL.Sample_Permission model = new MODEL.Sample_Permission();
        //    model.pId = viewModel.pId;
        //    model.pIsDel = true;
        //    bool status = false;
        //    try
        //    {
        //        PermissionManager.Modify(model, "pIsDel");
        //        status = true;
        //    }
        //    catch (Exception e)
        //    {
        //        UserOperateLog.WriteOperateLog("[系统权限管理](软)删除权限动作信息ID:" + model.pId + SysOperate.Delete.ToMessage(status),e.ToString());
        //        return this.JsonFormat(status, status, SysOperate.Update);
        //    }

        //    UserOperateLog.WriteOperateLog("[系统权限管理](软)删除权限动作信息ID:" + model.pId + SysOperate.Delete.ToMessage(status));
        //    return this.JsonFormat(status, status, SysOperate.Delete);

        //}
        //[Description("[系统权限维护页]永久删除动作")]
        //[EasyUIExceptionResult]
        //public ActionResult RealDelete()
        //{
        //    var pid = TypeParser.ToInt32(HttpContext.Request["pId"]);
        //    MODEL.Sample_Permission model = new MODEL.Sample_Permission();
        //    model.pId = pid;
        //    bool status = false;
        //    try
        //    {
        //        PermissionManager.Del(model);
        //        status = true;
        //    }
        //    catch (Exception e)
        //    {
        //        UserOperateLog.WriteOperateLog("[系统权限管理](永久)删除权限动作信息ID:" + model.pId + SysOperate.Delete.ToMessage(status),e.ToString());
        //        return this.JsonFormat(status, status, SysOperate.Update);
        //    }

        //    UserOperateLog.WriteOperateLog("[系统权限管理](永久)删除权限动作信息ID:" + model.pId + SysOperate.Delete.ToMessage(status));
        //    return this.JsonFormat(status, status, SysOperate.Delete);

        //}


    }
}
