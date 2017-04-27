using Common;
using IBLLService;
using MODEL;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
    public partial class Sample_ModulePermissionManager : BaseBLLService<Sample_ModulePermission>, ISample_ModulePermissionManager
    {
        ISample_PermissionManager PermissionManager { get; set; }
        /// <summary>
        /// 获取菜单的按钮信息
        /// </summary>
        /// <param name="request"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        //public IEnumerable<ViewModelMenuButtons> GetMenuButtons(EasyUIGridRequest request, int menuid, ref int Count)
        //{
        //    //string where = FilterHelper.GetFilterTanslate(request.Where);
        //    //string tableName = "mp";
        //    //string innerJoin = "left join fetch  mp.Permission p left join fetch mp.Module m";
        //    //string SortName = "";
        //    //if(!string.IsNullOrEmpty(request.SortName))
        //    //SortName= tableName + "." + request.SortName;
        //    return base.LoadListBy(mp => mp.moduleId == menuid && mp.isDel == false).Select(mb => new ViewModelMenuButtons() { });
        //    //return base.GetDataByPage(tableName, innerJoin, tableName, request.PageNumber, request.PageSize, SortName, request.SortOrder, where, out Count);
        //}
        /// <summary>
        /// 获取菜单的按钮信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EasyUIGrid GetMenuButtons(EasyUIGridRequest request,int menuid)
        {
            
            int count = 0;
            var data = base.LoadListBy(mp => mp.moduleId == menuid && mp.isDel == false).Select(mp => new ViewModelMenuButtons() { ModulePermissionID = mp.mpId,MenuUrl = mp.Sample_Module.moduleLinkUrl,MenuName = mp.Sample_Module.moduleName,MenuID = mp.Sample_Module.moduleId,MenuNo = mp.Sample_Module.moduleId,IsDeleted = mp.isDel.Value,ButtonName = mp.Sample_Permission.pName,ButtonAction = mp.Sample_Permission.pActionName,ButtonID = mp.Sample_Permission.pId,ButtonIcon = mp.Sample_Permission.pIco,MenuController = mp.Sample_Permission.pControllerName,Description = mp.Sample_Permission.pRemark, ParentID = mp.Sample_Permission.pParentId.Value});
            return new EasyUIGrid()
            {
                rows = data,
                total = count
            };
        }
       
    }
}
