using Common;
using IBLLService;
using MODEL;
using MODEL.DataTableModel;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
    public partial class MST_CATALOG_MANAGER : BaseBLLService<MST_CATALOG>, IMST_CATALOG_MANAGER
    {


        /// <summary>
        /// 获得分类树
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public MODEL.DataTableModel.DataTableGrid GetCatalogGridTree(DataTableRequest treeData)
        {
            int count = 0;

            var data = base.GetListBy(sc => true).OrderBy(sc => sc.SEQ_NO);
            count = data.Count();
            //GetPermission(request, out count);
            List<VIEW_MST_CATALOG> listCatalog = new List<VIEW_MST_CATALOG>();
            //查找所有的一级权限
            var ParentCatalog = data.Where(con => con.CATALOG_PCD == "" && con.SYNCOPERATION != "D");
            foreach (var parent in ParentCatalog)
            {
                //实体转化 
                VIEW_MST_CATALOG parentItem = VIEW_MST_CATALOG.ToViewModel(parent);
                //获取子级
                GetCatalogChildren(ref parentItem, data.ToList());
                listCatalog.Add(parentItem);
            }
            return new MODEL.DataTableModel.DataTableGrid()
            {
                data = listCatalog,
                total = count
            };
        }
        /// <summary>
        /// 获取子集
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="allList"></param>
        public void GetCatalogChildren(ref VIEW_MST_CATALOG parent, List<MST_CATALOG> allList)
        {
            foreach (MST_CATALOG catalog in allList)
            {

                if (catalog.CATALOG_PCD == parent.CATALOG_CD && catalog.SYNCOPERATION != "D")
                {

                    //实体转化
                    VIEW_MST_CATALOG child = VIEW_MST_CATALOG.ToViewModel(catalog);
                    if (parent.children == null)
                        parent.children = new List<VIEW_MST_CATALOG>();
                    //添加到父级的Children中
                    parent.children.Add(child);
                    GetCatalogChildren(ref child, allList);//递归添加子树
                }
            }
        }
        /// <summary>
        /// 获取树形的Select数据(暂时没有任何处理)
        /// </summary>
        /// <param name="selectData"></param>
        /// <returns></returns>
        public IEnumerable<MST_CATALOG> GetAllCatalogSelect(DataSelectRequest selectData)
        {
            return base.GetListBy(d => true);
        }
        /// <summary>
        /// 获取树形的Select的json数据
        /// </summary>
        /// <param name="selectData"></param>
        /// <returns></returns>
        public IEnumerable<DataSelect> GetAllCatalogSelectToViewModel(DataSelectRequest selectData)
        {
            IEnumerable<VIEW_MST_CATALOG> list = VIEW_MST_CATALOG.ToListViewModel(GetAllCatalogSelect(selectData));
            return DataSelect.ToListModel(list);

        }
        ///// <summary>
        ///// 获取树形的Select数据(暂时没有任何处理)
        ///// </summary>
        ///// <param name="selectData"></param>
        ///// <returns></returns>
        //public IEnumerable<Sample_Department> GetAllDepartmentSelect(LigerUISelectRequest selectData)
        //{
        //    return base.GetListBy(d => true);
        //}
        ///// <summary>
        ///// 获取树形的Select的json数据
        ///// </summary>
        ///// <param name="selectData"></param>
        ///// <returns></returns>
        //public IEnumerable<LigerUISelect> GetAllDepartmentSelectToViewModel(LigerUISelectRequest selectData)
        //{
        //    IEnumerable<Sample_Department> list = GetAllDepartmentSelect(selectData);
        //    return LigerUISelect.ToListModel(list);

        //}
        //#region 获取部门GridTree的json格式数据
        ///// <summary>
        ///// 获取部门的Tree格式
        ///// </summary>
        ///// <param name="treeData">获得树级请求数据</param>
        ///// <returns></returns>
        //public IEnumerable<LigerUITree> GetDepartmentTree(LigerUITreeRequest treeData)
        //{
        //    StringBuilder sbJson = new StringBuilder();
        //    IEnumerable<Sample_Department> departAllList = base.GetListBy(d => true).ToList();
        //    List<LigerUITree> listDepart = new List<LigerUITree>();
        //    //查找所有的一级部门
        //    var ParentDepart = departAllList.Where(con => con.depPid == 0);

        //    foreach (var parent in ParentDepart)
        //    {
        //        //实体转化 
        //        LigerUITree parentItem = LigerUITree.ToEntity(parent);
        //        //获取子级
        //        GetDepartmentChildren(ref parentItem, (List<Sample_Department>)departAllList);
        //        listDepart.Add(parentItem);
        //    }
        //    return listDepart;

        //}

        //#region 获取部门GridTree的json格式数据
        ///// <summary>
        ///// 获取部门GridTree的json格式数据
        ///// </summary>
        ///// <returns></returns>
        //public string GetDepartmentGridTree(LigerUIGridRequest gridData)
        //{
        //    int total = 0;
        //    var departAllList = base.GetPagedList(out total, gridData.PageNumber, gridData.PageSize, d => d.isDel==false, d =>d.depId, true).ToList();// GetAllEntitiesByPaging(gridData, out total);
        //    List<LigerUITree> listDepart = new List<LigerUITree>();
        //    //查找所有的一级部门
        //    var ParentDepart = departAllList.Where(con => con.depPid == 0);


        //    foreach (var parent in ParentDepart)
        //    {
        //        //实体转化 
        //        LigerUITree parentItem = LigerUITree.ToEntity(parent);
        //        //获取子级
        //        GetDepartmentChildren(ref parentItem, (List<Sample_Department>)departAllList);
        //        listDepart.Add(parentItem);

        //    }
        //    //grid数据输出
        //    LigerUIGrid grid = new LigerUIGrid();
        //    grid.Rows = listDepart;
        //    grid.Total = total;
        //    return JsonHelper.ToJson(grid, true);

        //}
        //#endregion
        ///// <summary>
        ///// 获取父级部门下的子部门列表信息
        ///// </summary>
        ///// <param name="parent"></param>
        ///// <param name="allList"></param>
        ///// <returns></returns>
        //private void GetDepartmentChildren(ref LigerUITree parent, List<Sample_Department> allList)
        //{
        //    foreach (Sample_Department depart in allList)
        //    {

        //        if (depart.depPid == parent.id)
        //        {

        //            //实体转化
        //            LigerUITree child = LigerUITree.ToEntity(depart);
        //            if (parent.children == null)
        //                parent.children = new List<LigerUITree>();
        //            //添加到父级的Children中
        //            parent.children.Add(child);
        //            GetDepartmentChildren(ref child, allList);//递归添加子树
        //        }
        //    }
        //}
        //#endregion






        public IEnumerable<DataTree> GetCatalogTree(DataTreeRequest request)
        {
            //返回ui层的菜单
            IEnumerable<DataTree> rootRole = new List<DataTree>();
            var data = base.GetListBy(sc => true).OrderBy(sc => sc.SEQ_NO);
            //GetPermission(request, out count);
            List<VIEW_MST_CATALOG> listCatalog = new List<VIEW_MST_CATALOG>();
            //查找所有的一级权限
            var ParentCatalog = data.Where(con => con.CATALOG_PCD == "" && con.SYNCOPERATION!="D");
            foreach (var parent in ParentCatalog)
            {
                //实体转化 
                VIEW_MST_CATALOG parentItem = VIEW_MST_CATALOG.ToViewModel(parent);
                //获取子级
                GetCatalogChildren(ref parentItem, data.ToList());
                listCatalog.Add(parentItem);
            }
            rootRole = DataTree.ToListViewModel(listCatalog);
            
            return rootRole;
        }
    }
}
