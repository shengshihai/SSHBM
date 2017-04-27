/*  作者：       盛世海
*  创建时间：   2012/7/30 15:30:17
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using Common.Attributes;
using MODEL.ViewModel;
using Common;
using IBLLService;
using ShengUI.Helper;
using Common.EfSearchModel.Model;


namespace ShengUI.Logic.Admin
{
    [Description("角色管理")]
    public class RoleController : Controller
    {
          
        // GET: /Admin/Role/
     
        [DefaultPage]
        [ActionParent]
        [ActionDesc("角色管理首页")]
        [Description("[角色管理]角色管理首页列表信息")]
        public ActionResult RoleInfo()
        {
            return View();
        }

        [ActionDesc("产品详细信息")]
        [Description("[角色管理]产品详细信息(add,Update,Detail必备)")]
        public ActionResult Detail()
        {

            return View();

        }

        [ActionDesc("角色管理获取产品信息列表")]
        [Description("[角色管理]获取产品信息(主页必须)")]
        public ActionResult GetAllRolesForGrid(QueryModel model)
        {
            return this.JsonFormat("");
        }






        [ValidateInput(false)]
        [ActionDesc("添加", "Y")]
        [Description("[角色管理]添加动作")]
        public ActionResult Add()
        {

            bool status = false;
            try
            {

                status = true;
            }
            catch (Exception e)
            {

                return this.JsonFormat(status, status, SysOperate.Add);
            }
            return this.JsonFormat(status, status, SysOperate.Add);
        }


        [ValidateInput(false)]
        [ActionDesc("修改", "Y")]
        [Description("[角色管理]修改动作")]
        public ActionResult Update()
        {
            var id = TypeParser.ToInt32(HttpContext.Request["Pid"]);
            bool status = false;
            try
            {


                status = true;
            }
            catch (Exception ex)
            {
                return this.JsonFormat(status, !status, ex.Message + ex.StackTrace);
            }
            return this.JsonFormat(status, status, SysOperate.Update);
        }

        [ActionDesc("删除", "Y")]
        [Description("[角色管理]软删除动作")]
        public ActionResult Delete()
        {
            bool status = false;
            try
            {
                status = true;
            }
            catch (Exception e)
            {

                return this.JsonFormat(status, status, SysOperate.Delete);
            }

            return this.JsonFormat(status, status, SysOperate.Delete);
        }
        [ActionDesc("永久删除", "Y")]
        [Description("[角色管理]永久删除动作")]
        public ActionResult RealDelete()
        {
            bool status = false;
            try
            {
                status = true;
            }
            catch (Exception e)
            {

                return this.JsonFormat(status, status, SysOperate.Delete);
            }

            return this.JsonFormat(status, status, SysOperate.Delete);
        }
       
    }
}
