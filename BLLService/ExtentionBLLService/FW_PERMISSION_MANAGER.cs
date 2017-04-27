using IBLLService;
using MODEL;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
    public partial class FW_PERMISSION_MANAGER : BaseBLLService<FW_PERMISSION>, IFW_PERMISSION_MANAGER
    {

        //public  IEnumerable<Sample_Permission>  GetPermissionGridTree(MODEL.ViewModel.EasyUIGridRequest request)
        //{
        //    int count = 0;

        //    var data = base.GetListBy(p => true).OrderBy(p=>p.pOrder);
        //    count = data.Count();
        //    //GetPermission(request, out count);
        //    List<ViewModelButton> listPermission = new List<ViewModelButton>();
        //    //查找所有的一级权限
        //    var ParentPermission = data.Where(con => con.pParentId == 0 && con.pIsDel == false);
        //    foreach (var parent in ParentPermission)
        //    {
        //        //实体转化 
        //        ViewModelButton parentItem = ViewModelButton.ToViewModel(parent);
        //        //获取子级
        //        GetPermissionChildren(ref parentItem, data.ToList());
        //        listPermission.Add(parentItem);
        //    }
        //    return new MODEL.ViewModel.EasyUIGrid()
        //    {
        //        rows = listPermission,
        //        total = count
        //    };
        //}
        /// <summary>
        /// 获取子集
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="allList"></param>
        public void GetPermissionChildren(ref VIEW_FW_PERMISSION parent, List<FW_PERMISSION> allList)
        {
            foreach (FW_PERMISSION permission in allList)
            {

                if (permission.PERMISSION_PID == parent.PERMISSION_ID)
                {

                    //实体转化
                    VIEW_FW_PERMISSION child = VIEW_FW_PERMISSION.ToViewModel(permission);
                    if (parent.children == null)
                        parent.children = new List<VIEW_FW_PERMISSION>();
                    //添加到父级的Children中
                    parent.children.Add(child);
                    GetPermissionChildren(ref child, allList);//递归添加子树
                }
            }
        }
        /// <summary>
        /// 请求权限列表信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        //public EasyUIGrid GetPermissionForGrid(EasyUIGridRequest request)
        //{
        //    int count = 0;
        //    return new EasyUIGrid()
        //    {
        //        rows = ViewModelButton.ToListViewModel(GetPermission(request, ref count)),
        //        total = count//myDao.GetEntitiesCount(p => true)
        //    };
        //}
        /// <summary>
        /// 根据条件获取权限信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <param name="Count">总个数</param>
        /// <returns></returns>
        public IEnumerable<VIEW_FW_PERMISSION> GetPermission()
        {

            int count = 0;

            var data = base.GetListBy(p => true,p => p.SEQ_NO);
            count = data.Count();
            //GetPermission(request, out count);
            List<VIEW_FW_PERMISSION> listPermission = new List<VIEW_FW_PERMISSION>();
            //查找所有的一级权限
            var ParentPermission = data.Where(con => con.PERMISSION_PID == "" );
            foreach (var parent in ParentPermission)
            {
                //实体转化 
                VIEW_FW_PERMISSION parentItem = VIEW_FW_PERMISSION.ToViewModel(parent);
                //获取子级
                GetPermissionChildren(ref parentItem, data.ToList());
                listPermission.Add(parentItem);
            }
            return listPermission;
           
        }
       
    }
}
