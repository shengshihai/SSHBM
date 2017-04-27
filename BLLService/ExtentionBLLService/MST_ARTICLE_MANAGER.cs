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
    public partial class MST_ARTICLE_MANAGER : BaseBLLService<MST_ARTICLE>, IMST_ARTICLE_MANAGER
    {


        public MODEL.DataTableModel.DataTableGrid GetArticleForGrid(MODEL.DataTableModel.DataTableRequest request)
        {

            try
            {

                var predicate = PredicateBuilder.True<MST_ARTICLE>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");

                int total = 0;
                predicate = predicate.And(p => p.SYNCOPERATION != "D");

                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName).Select(a => new VIEW_MST_ARTICLE()
                {
                  ARTICLE_ID=a.ARTICLE_ID,
                  CATALOG_CD=a.CATALOG_CD,
                  CODE = a.CODE,
                  SUBTITLE = a.SUBTITLE,
                  WRITER = a.WRITER,
                  RESOURCE = a.RESOURCE,
                  KEYWORDS = a.KEYWORDS,
                  SEQ_NO = a.SEQ_NO,
                  ACTIVE = a.ACTIVE,
                  SYNCVERSION=a.SYNCVERSION
                });
                //var list = ViewModelProduct.ToListViewModel(data);
                return new MODEL.DataTableModel.DataTableGrid()
                {
                    draw = request.Draw,
                    data = data,
                    total = total
                };
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 审核通过的
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int ApprovedMoreArticle(List<int> ids)
        {
            var productList = idal.GetListasNoTrackingBy(a => ids.Contains(a.ARTICLE_ID)).OrderBy(a=>a.CREATE_DT).ToList();
            foreach (var model in productList)
            {
                model.ACTIVE = "Y";
                idal.Modify(model, "ACTIVE");
            }
            return IDBSession.SaveChanges();
        }

        public override int Add(MST_ARTICLE model)
        {
             base.Add(model);
             return model.ARTICLE_ID;
        }
    }
}
