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
    public partial class Sample_DepartmentManager : BaseBLLService<Sample_Department>, ISample_DepartmentManager
    {
        /// <summary>
        /// 获取树形的Select数据(暂时没有任何处理)
        /// </summary>
        /// <param name="selectData"></param>
        /// <returns></returns>
        public IEnumerable<Sample_Department> GetAllDepartmentSelect(EasyUISelectRequest selectData)
        {
            return base.GetListBy(d => true);
        }
        /// <summary>
        /// 获取树形的Select的json数据
        /// </summary>
        /// <param name="selectData"></param>
        /// <returns></returns>
        public string GetAllDepartmentSelectToViewModel(EasyUISelectRequest selectData)
        {

            int total = 0;
            var departAllList = base.GetListBy(d => true).ToList();
            departAllList.Add(new Sample_Department() { depId = 0, depName = "顶级分类",depPid=-1 });
            List<EasyUITree> listDepart = new List<EasyUITree>();
            
            //查找所有的一级部门
            var ParentDepart = departAllList.Where(con => con.depPid == -1);


            foreach (var parent in ParentDepart)
            {
                //实体转化 
                EasyUITree parentItem = EasyUITree.ToEntity(parent);
                //获取子级
                GetDepartmentChildren(ref parentItem, (List<Sample_Department>)departAllList);
                listDepart.Add(parentItem);

            }
           
            return JsonHelper.ToJson(listDepart, true);


        }
        #region 获取部门GridTree的json格式数据
        /// <summary>
        /// 获取部门的Tree格式
        /// </summary>
        /// <param name="treeData">获得树级请求数据</param>
        /// <returns></returns>
        public IEnumerable<EasyUITree> GetDepartmentTree(EasyUITreeRequest treeData)
        {
            StringBuilder sbJson = new StringBuilder();
            IEnumerable<Sample_Department> departAllList = base.GetListBy(d => true).ToList();
            List<EasyUITree> listDepart = new List<EasyUITree>();
            //查找所有的一级部门
            var ParentDepart = departAllList.Where(con => con.depPid == 0);

            foreach (var parent in ParentDepart)
            {
                //实体转化 
                EasyUITree parentItem = EasyUITree.ToEntity(parent);
                //获取子级
                GetDepartmentChildren(ref parentItem, (List<Sample_Department>)departAllList);
                listDepart.Add(parentItem);
            }
            return listDepart;

        }

        #region 获取部门GridTree的json格式数据
        /// <summary>
        /// 获取部门GridTree的json格式数据
        /// </summary>
        /// <returns></returns>
        public string GetDepartmentGridTree(EasyUIGridRequest gridData)
        {
            int total = 0;
            var departAllList = base.GetPagedList(gridData.PageNumber, gridData.PageSize, ref total, d => d.isDel == false, d => d.createDate, true).ToList();// GetAllEntitiesByPaging(gridData, out total);
            //List<LigerUITree> listDepart = new List<LigerUITree>();
            //查找所有的一级部门
            var ParentDepart = departAllList.Where(con => con.depPid == 0);
            var listDepart=ViewModelDeptment.ToListViewModel(departAllList);

            //foreach (var parent in ParentDepart)
            //{
            //    //实体转化 
            //    LigerUITree parentItem = LigerUITree.ToEntity(parent);
            //    //获取子级
            //    GetDepartmentChildren(ref parentItem, (List<Sample_Department>)departAllList);
            //    listDepart.Add(parentItem);

            //}
            //grid数据输出
            EasyUIGrid grid = new EasyUIGrid();
            grid.rows = listDepart;
            grid.total = total;
            return JsonHelper.ToJson(grid, true);

        }
        #endregion
        /// <summary>
        /// 获取父级部门下的子部门列表信息
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="allList"></param>
        /// <returns></returns>
        private void GetDepartmentChildren(ref EasyUITree parent, List<Sample_Department> allList)
        {
            foreach (Sample_Department depart in allList)
            {

                if (depart.depPid == parent.id)
                {

                    //实体转化
                    EasyUITree child = EasyUITree.ToEntity(depart);
                    if (parent.children == null)
                        parent.children = new List<EasyUITree>();
                    //添加到父级的Children中
                    parent.children.Add(child);
                    GetDepartmentChildren(ref child, allList);//递归添加子树
                }
            }
        }
        #endregion

    }
}
