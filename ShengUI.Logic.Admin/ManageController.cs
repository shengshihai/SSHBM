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
using Common.Attributes;
using ShengUI.Helper;

namespace ShengUI.Logic.Admin
{
    
    //[Description("系统管理")]
    public class ManageController : Controller
    {

        IFW_USER_MANAGER FW_USER_MANAGER = OperateContext.Current.BLLSession.IFW_USER_MANAGER;
        IFW_MODULE_MANAGER MODULE_MANAGER = OperateContext.Current.BLLSession.IFW_MODULE_MANAGER;
        IMST_PRD_MANAGER prd_MANAGER = OperateContext.Current.BLLSession.IMST_PRD_MANAGER;
        IMST_CATEGORY_MANAGER categroyB = OperateContext.Current.BLLSession.IMST_CATEGORY_MANAGER;

        [DefaultPage]
        [ActionParent]
        [ActionDesc("系统管理首页")]
        [Description("[系统管理首页]系统管理")]
        public ActionResult Index()
        {
            ViewBag.UserType = DataSelect.ToListViewModel(ConfigSettings.GetSysConfigList("")); 

            ViewBag.UserID = OperateContext.Current.UsrId;
            ViewBag.UserName = OperateContext.Current.UsrName;
            return View();
        }
        [ActionDesc("欢迎页")]
        [Description("[系统管理首页]欢迎页面")]
        public ActionResult WelCome()
        {
            ViewBag.UserID = OperateContext.Current.UsrId;
            ViewBag.UserName = OperateContext.Current.UsrName;
            ViewBag.PrdList = VIEW_MST_PRD.ToListViewModel(prd_MANAGER.GetListBy(s =>true,s=>s.SEQ_NO));
            ViewBag.CategoryList = VIEW_MST_CATEGORY.ToListViewModel(categroyB.GetListBy(s => s.SYNCOPERATION != "D"));
            return View();
        }
        [AjaxRequestAttribute]
        public ActionResult ReturnHot()
        {
            return this.JsonFormat(prd_MANAGER.GetProductsForHot());
        }
        [ActionDesc("左菜单页")]
        [Description("[系统管理首页]左菜单导航页面")] 
        public ActionResult ManageNavigation()
        {
            if (OperateContext.Current.UsrId == "Administrator")
            {
                ViewBag.ManageLeftMenu = VIEW_FW_MODULE.ToListViewModel(MODULE_MANAGER.GetListBy(m => m.ISMENU == true));
            }
            else
            {
                ViewBag.ManageLeftMenu = VIEW_FW_MODULE.ToListViewModel(MODULE_MANAGER.GetListBy(m => (OperateContext.Current.UsrMenu.Contains(m.MODULE_ID) || m.MODULE_PID == "MAIN_FIRST") && m.ISMENU == true));
            }
            return View();
        }
        [ActionDesc("左菜单页")]
        [Description("[系统管理首页]左菜单导航页面")] 
        public ActionResult ManageLeftMenu()
        {
            var UserMenus = OperateContext.Current.UsrMenu;
           // ViewData["ManageLeftMenu"]=OperateContext.Current.BLLSession.ISample_UserInfoManager.GetUserPermissionMenus(UserMenus);
           
            return View();
        }
        [ActionDesc("上传编辑器图片")]
        [Description("[系统管理首页]上传编辑器图片")] 
        public ActionResult UploadTinMceImg()
        {
            //return Content(UploadRequestImg.OneImageSave(HttpContext, "Supplier"));
            return Content("");
        }
        #region 菜单
        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        [ActionDesc("获取菜单")]
        [Description("[系统管理首页]Load菜单树获取菜单信息")]
        public ActionResult GetMenus()
        {
            var UserMenus = OperateContext.Current.UsrMenu;
            //序列化json数据并返回给前台
            
            return this.JsonFormat(
              ""//  OperateContext.Current.BLLSession.ISample_UserInfoManager.GetUserPermissionMenus(UserMenus)
                );
        }
        #endregion
       
         #region 按钮
        /// <summary>
        /// 按钮信息加载
        /// </summary>
        /// <returns></returns>
         [AjaxRequestAttribute]
        [ActionDesc("获取按钮")]
        [Description("[系统管理首页]获取按钮信息")]
        public ActionResult GetMyButton()
         {
             var UserRoles = OperateContext.Current.UserRole;
             var USER_CD = OperateContext.Current.UsrId;
            ButtonRequest RequestButtonData=new ButtonRequest (HttpContext);

                return this.JsonFormatSuccess(
                    FW_USER_MANAGER.GetUserRoleButtons(USER_CD, UserRoles,RequestButtonData),
                    SystemMessage.LoadSuccess.ToString()
                    );

     
            
         }
        [ActionDesc("获取按钮图片")]
        [Description("[系统管理首页]获取所有的按钮图标")]
         public ActionResult GetIcons()
         {
             
             var listFiles = new List<SelectListItem>();

             listFiles = Common.Controls.GetIcons();
      
             return this.JsonFormat(listFiles);
         }
         #endregion
         #region 用户信息
         /// <summary>
         /// 获取当前账户登录信息
         /// </summary>
         /// <returns></returns>
         //[Description("[Index页面加载用户登录信息]获取当前账户登录信息")]
         //[EasyUIExceptionResult]
         //public ActionResult GetCurrentUser()
         //{

         //    var currUser = UserInfoManager.Get(OperateContext.Current.UsrId);
         //   var User = new { Title = currUser.nickName };
         //    return this.JsonFormat(User, SysOperate.Load);
         //}
        //[Description("login登录(带验证码验证),登录成功则跳转")]
        //[Anonymous]
        //[EasyUIExceptionResult]
        //public ActionResult LoginAndRedirect()
        //{
        //    UserRequest request = new UserRequest(HttpContext);
        //    IUserService userService = new UserService();
        //    bool status = false;
        //    if(true)// (Session["CheckCode"].ToString ()== request.CheckCode)
        //    {
        //        tbUser user = userService.Login(request);
        //        if (!user.IsNullOrEmpty())
        //        {
        //            status = true;
        //            //保存信息到Session
        //            SysCurrentUser.SaveUserInfo(user);
        //            UserOperateLog.WriteOperateLog("[用户登录]" + SysOperate.Add.ToMessage(user.IsNullOrEmpty()));
        //        }
        //        else
        //            status = false;
        //    }
        //    else
        //        status = false; ;
        //    return this.JsonFormat(status, status, SysOperate.Operate);

        //}
        //[Description("[Index页面Login]登陆")]
        //[LoginAllowView]
        //[EasyUIExceptionResult]
        //public ActionResult Login()
        //{
        //    UserRequest request=new UserRequest (HttpContext);
        //    IUserService userService=new UserService();
        //    tbUser user = userService.Login(request);
        //    //保存信息到Session
        //    SysCurrentUser.SaveUserInfo(user);
        //    UserOperateLog.WriteOperateLog("[用户登录]" + SysOperate.Add.ToMessage(user.IsNullOrEmpty()));
        //    return this.JsonFormat(user,!user.IsNullOrEmpty(), SysOperate.Operate);
        //}
        //[Description("[Index页面修改密码]修改密码")]
        //[LoginAllowView]
        //[EasyUIExceptionResult]
        //public ActionResult ChangePassword()
        //{
        //    UserRequest request = new UserRequest(HttpContext);
        //    IUserService userService = new UserService();
        //    var status = userService.ChangePassword(request,new SysCurrentUser().UserID);
        //    UserOperateLog.WriteOperateLog("[用户修改密码]" + SysOperate.Operate.ToMessage(status));
        //    return this.JsonFormat(status, status, SysOperate.Operate);
            
        //}
        // #endregion
        //#region 用户收藏信息
        // [Description("[Index页面Load收藏]加载我的收藏信息")]

        // [EasyUIExceptionResult]
        // public ActionResult GetMyFavorite()
        // {
        //     var userId = OperateContext.Current.UsrId;
        //     IEnumerable<MODEL.Sample_Favorite> listFavorite = FavoriteManager.GetListBy(f => f.userId == userId);
        //     var data = ViewModelFavorite.ToListViewModel(listFavorite);
        //     return this.JsonFormat(data, SysOperate.Load);


        // }
        // [Description("[Index页面Add收藏]添加我的收藏信息")]
        // [EasyUIExceptionResult]
        // public ActionResult AddFavorite()
        // {

        //     //请求参数获取
        //     FavoriteRequest request = new FavoriteRequest(HttpContext);

        //     var module = ModuleManager.Get(TypeParser.ToInt32(request.MenuNo));
        //     request.GetFavoriteModuleInfo(module);
        //     request.Favorite.userId = OperateContext.Current.UsrId;
        //     //添加状态
        //     bool status = false;
        //     try
        //     {
        //         FavoriteManager.Save(request.Favorite);
        //         status = true;
        //     }
        //     catch (Exception)
        //     {

        //         return this.JsonFormat(status, status, SysOperate.Add);
        //     }

        //     UserOperateLog.WriteOperateLog("[收藏信息]" + SysOperate.Add.ToMessage(status));
        //     return this.JsonFormat(status, status, SysOperate.Add);
        // }
        // [Description("[Index页面Delete收藏]删除我的收藏信息")]
        // [EasyUIExceptionResult]
        // public ActionResult RemoveFavorite()
        // {
        //     //请求参数获取
        //     RequestBase request = new RequestBase(HttpContext);
        //     bool status = false;
        //     try
        //     {
        //         FavoriteManager.Delete(request.ID);
        //         status = true;
        //     }
        //     catch (Exception)
        //     {
        //         return this.JsonFormat(status, status, SysOperate.Delete);
        //     }
        //     return this.JsonFormat(status, status, SysOperate.Delete);

        // }
        #endregion
    }
}
