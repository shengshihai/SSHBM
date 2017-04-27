using Common;
using IBLLService;
using MODEL;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLService
{
    public partial class MST_CATEGORY_MANAGER : BaseBLLService<MST_CATEGORY>, IMST_CATEGORY_MANAGER
    {


        public MODEL.DataTableModel.DataTableGrid GetCategoryGridTree(MODEL.DataTableModel.DataTableRequest treeData)
        {
            int count = 0;

            var data = base.GetListBy(sc => true).OrderBy(sc => sc.CATE_CD);
            count = data.Count();
            //GetPermission(request, out count);
            List<VIEW_MST_CATEGORY> listCategory= new List<VIEW_MST_CATEGORY>();
            //查找所有的一级权限
            var ParentCatalog = data.Where(con => con.PARENT_CD == "MAIN" && con.SYNCOPERATION != "D");
            foreach (var parent in ParentCatalog)
            {
                //实体转化 
                VIEW_MST_CATEGORY parentItem = VIEW_MST_CATEGORY.ToViewModel(parent);
                //获取子级
                GetCategoryChildren(ref parentItem, data.ToList());
                listCategory.Add(parentItem);
            }
            return new MODEL.DataTableModel.DataTableGrid()
            {
                data = listCategory,
                total = count
            };
        }
        // <summary>
        /// 获取子集
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="allList"></param>
        public void GetCategoryChildren(ref VIEW_MST_CATEGORY parent, List<MST_CATEGORY> allList)
        {
            foreach (MST_CATEGORY category in allList)
            {

                if (category.PARENT_CD == parent.CATE_CD && category.SYNCOPERATION != "D")
                {

                    //实体转化
                    VIEW_MST_CATEGORY child = VIEW_MST_CATEGORY.ToViewModel(category);
                    if (parent.children == null)
                        parent.children = new List<VIEW_MST_CATEGORY>();
                    //添加到父级的Children中
                    parent.children.Add(child);
                    GetCategoryChildren(ref child, allList);//递归添加子树
                }
            }
        }
        public IEnumerable<MST_CATEGORY> GetAllCategorySelect(MODEL.DataTableModel.DataSelectRequest selectData)
        {
            return base.GetListBy(d => true);
        }

        public IEnumerable<DataSelect> GetAllCategorySelectToViewModel(MODEL.DataTableModel.DataSelectRequest selectData)
        {
            IEnumerable<VIEW_MST_CATEGORY> list = VIEW_MST_CATEGORY.ToListViewModel(GetAllCategorySelect(selectData));
            return DataSelect.ToListModel(list);
        }

        public IEnumerable<DataTree> GetCategoryTree(MODEL.DataTableModel.DataTreeRequest request)
        {
            //返回ui层的菜单
            IEnumerable<DataTree> rootRole = new List<DataTree>();
            var data = base.GetListBy(sc => true).OrderBy(sc => sc.CATE_CD);
            //GetPermission(request, out count);
            List<VIEW_MST_CATEGORY> listCategory = new List<VIEW_MST_CATEGORY>();
            //查找所有的一级权限
            var ParentCatalog = data.Where(con => con.PARENT_CD == "" && con.SYNCOPERATION != "D");
            foreach (var parent in ParentCatalog)
            {
                //实体转化 
                VIEW_MST_CATEGORY parentItem = VIEW_MST_CATEGORY.ToViewModel(parent);
                //获取子级
                GetCategoryChildren(ref parentItem, data.ToList());
                listCategory.Add(parentItem);
            }
            rootRole = DataTree.ToListViewModel(listCategory);

            return rootRole;
        }
    }
}
