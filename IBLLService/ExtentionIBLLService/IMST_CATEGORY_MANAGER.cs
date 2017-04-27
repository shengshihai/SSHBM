using MODEL;
using MODEL.DataTableModel;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface IMST_CATEGORY_MANAGER : IBaseBLLService<MST_CATEGORY>
    {

               /// <summary>
        /// 获得分类树
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        MODEL.DataTableModel.DataTableGrid GetCategoryGridTree(DataTableRequest treeData);
            /// <summary>
        /// 获取树形的Select数据(暂时没有任何处理)
        /// </summary>
        /// <param name="selectData"></param>
        /// <returns></returns>
        IEnumerable<MST_CATEGORY> GetAllCategorySelect(DataSelectRequest selectData);

         /// <summary>
        /// 获取树形的Select的json数据
        /// </summary>
        /// <param name="selectData"></param>
        /// <returns></returns>
        IEnumerable<DataSelect> GetAllCategorySelectToViewModel(DataSelectRequest selectData);


        IEnumerable<DataTree> GetCategoryTree(DataTreeRequest request);
    }
}
