using MODEL;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface IMST_ARTICLE_MANAGER : IBaseBLLService<MST_ARTICLE>
    {

        MODEL.DataTableModel.DataTableGrid GetArticleForGrid(MODEL.DataTableModel.DataTableRequest request);
        int ApprovedMoreArticle(List<int> ids);
    }
}
