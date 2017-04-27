using Common;
using IBLLService;
using MODEL;
using MODEL.ViewModel;
using SampleUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
    public partial class Sample_UserInfoManager : BaseBLLService<Sample_UserInfo>, ISample_UserInfoManager
    {
        ISample_ModuleManager ModuleManager = OperateContext.Current.BLLSession.ISample_ModuleManager;
        ISample_PermissionManager PermissionManager = OperateContext.Current.BLLSession.ISample_PermissionManager;
        ISample_RoleManager RoleManager { get; set; }
        ISample_UserRoleManager UserRoleManager = OperateContext.Current.BLLSession.ISample_UserRoleManager;


        public override int ModifyAll(Sample_UserInfo model)
        {
            UserRoleManager.DelBy(ur => ur.urUId == model.userId);
            idal.ModifyAll(model);
            return IDBSession.SaveChanges();
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public Sample_UserInfo Login(string strName, string strPwd)
        {
            ////1.调用业务层方法 根据登陆名查询
            var usr = base.GetListBy(u => u.userName == strName).FirstOrDefault();
            //2.判断是否登陆成功
            if (usr != null && usr.userPwd == strPwd)
            {
                return usr;
            }
            return null;
        }


        public IEnumerable<ViewModelMenu> GetUserTreeMenus(EasyUITreeRequest request, string userRoles)
        {
            //返回ui层的菜单
            IEnumerable<ViewModelMenu> rootMenus = new List<ViewModelMenu>(){
            new ViewModelMenu()
            {
                icon = request.RootIcon,
                MenuIcon = request.RootIcon,
                MenuParentNo = request.PidField,
                MenuName = "主菜单",
                MenuNo = request.IdField,
                text = "主菜单",
                children = (List<ViewModelMenu>)ViewModelMenu.ToListViewModel(ModuleManager.GetListBy(m=>m.moduleParentId==0)) 
            
            }
        };
            return rootMenus;

        }


        public EasyUIGrid GetUserGridMenus(EasyUIGridRequest request, List<int> userMenuId, int parentid)
        {
             
            int total = 0;
            EasyUIGrid grid = new EasyUIGrid();
            if(OperateContext.Current.UserRole.Contains(1))
            grid.rows = ViewModelMenu.ToListViewModel(ModuleManager.GetPagedList(request.PageNumber,request.PageSize,ref total,m =>m.isDel==false&& m.moduleParentId ==parentid,m=>m.sort));
            else
                grid.rows = ViewModelMenu.ToListViewModel(ModuleManager.GetPagedList(request.PageNumber, request.PageSize, ref total, m => m.isDel == false && m.moduleParentId == parentid && userMenuId.Contains(m.moduleId), m => m.sort));
            //记录总数
            grid.total = total;
            //返回ui层的菜单
            return grid;
        }
       
        public IEnumerable<MODEL.ViewModel.ViewModelMyButton> GetUserRoleButtons(List<int> Roles, ButtonRequest RequestController, int AdminUserRoleID)
        {
            List<ViewModelMyButton> listButtons = new List<ViewModelMyButton>();
             IEnumerable<Sample_Permission> Actions = new List<Sample_Permission>();
            //获取当前角色的按钮模块数组
             if (Roles.Contains(AdminUserRoleID))
                 Actions = PermissionManager.GetListBy(p => p.pControllerName == RequestController.MenuNo && p.pIsButton == true).OrderBy(p=>p.pOrder).ToList();
             else
             {
                 var buttonids = OperateContext.Current.UsrPermissionId;
                 Actions = OperateContext.Current.BLLSession.ISample_PermissionManager.LoadListBy(p => p.pControllerName == RequestController.MenuNo && p.pIsButton == true && buttonids.Contains(p.pId)).ToList() ;
             }

             foreach (Sample_Permission data in Actions)
             {
                 //添加到按钮数组
                 listButtons.Add(ViewModelMyButton.ToEntity(data));
             } 
            return listButtons;
        }

        #region 获取用户的菜单
        /// <summary>
        /// 获取用户的菜单
        /// </summary>
        /// <param name="Roles"></param>
        /// <returns></returns>
        public IEnumerable<ViewModelMenu> GetUserPermissionMenus(List<int> UserMenu)
        {
            
            List<ViewModelMenu> menusList = new List<ViewModelMenu>();
            //获取当前角色的json菜单数据
            IEnumerable<Sample_Module> RolesMenus = new List<Sample_Module>();
            if(OperateContext.Current.UserRole.Contains(1))
                RolesMenus = ModuleManager.GetListBy(m =>m.isMenu==true).OrderBy(m=>m.sort).ToList();
            else
                RolesMenus = ModuleManager.GetListBy(m => UserMenu.Contains(m.moduleId) && m.isMenu == true).OrderBy(m => m.sort).ToList();
            //首先找出父级菜单
            var ParentMenus = ModuleManager.GetListBy(p => p.moduleParentId == 0).OrderBy(m => m.sort);
            foreach (Sample_Module roleMenu in ParentMenus)
            {
                //实体转化
                ViewModelMenu menu = ViewModelMenu.ToEntity(roleMenu);
                //添加子菜单
                foreach (Sample_Module childMenu in RolesMenus)
                {
                    if (childMenu.moduleParentId == roleMenu.moduleId)
                    {
                        ViewModelMenu child = ViewModelMenu.ToEntity(childMenu);
                        if (menu.children == null)
                            menu.children = new List<ViewModelMenu>();
                        menu.children.Add(child);
                    }
                }
                if(menu.children!=null&&menu.children.Count>0)
                menusList.Add(menu);
            }
            return menusList;

        }
        #endregion


        /// <summary>
        /// 根据条件获取所有用户
        /// </summary>
        /// <param name="request">请求条件</param>
        /// <param name="Count">记录总数</param>
        /// <returns></returns>
        public IEnumerable<Sample_UserInfo> GetAllUsers(EasyUIGridRequest request, ref int Count)
        {

            return base.GetPagedList(request.PageNumber, request.PageSize, ref Count, u => true, u => u.createDate, false).ToList();
           
        }
        /// <summary>
        /// 根据条件获取所有菜单
        /// </summary>
        /// <param name="request">请求条件</param>
        /// <returns></returns>
        public EasyUIGrid GetAllUsers(EasyUIGridRequest request)
        {
            int total = 0;
            return new EasyUIGrid()
            {
                rows = ViewModelUser.ToListViewModel(GetAllUsers(request, ref total)),
                total = total
            };
        }

        public string GetUserAllRole(Sample_UserInfo User)
        {
            throw new NotImplementedException();
        }

        public string GetUserAllRole(int UserID)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(UserRequest requestInfo, int UserID)
        {
            throw new NotImplementedException();
        }
    }
}
