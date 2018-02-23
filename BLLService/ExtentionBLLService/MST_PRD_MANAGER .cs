using Common;
using IBLLService;
using IDALRepository;
using MODEL;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLLService
{

    public partial class MST_PRD_MANAGER : BaseBLLService<MST_PRD>, IMST_PRD_MANAGER
    {

        public MODEL.DataTableModel.DataTableGrid GetProductsForGrid(MODEL.DataTableModel.DataTableRequest request)
        {
            try
            {

                var predicate = PredicateBuilder.True<MST_PRD>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");

                int total = 0;
               predicate = predicate.And(p => p.ISCHECK ==true);

                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName).Select(p => new VIEW_MST_PRD(){
                        SEQ_NO=p.SEQ_NO,
                        PRD_CD=p.PRD_CD,
                        PRD_NAME=p.PRD_NAME,
                        PRD_SHORT_DESC=p.PRD_SHORT_DESC,
                        PRICE=p.PRICE,
                        ARKETPRICE=p.ARKETPRICE,
                        FRONTPRICE=p.FRONTPRICE,
                        CATEGORY_NAME=p.MST_CATEGORY.CATEGORY_NAME,
                        ISHOT=p.ISHOT,
                        STATUS=p.STATUS,
                        CREATE_DT=p.CREATE_DT,
                        MODIFY_DT=p.MODIFY_DT
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
        public MODEL.DataTableModel.DataTableGrid GetProductsForHot()
        {
            try
            {

                var predicate = PredicateBuilder.True<MST_PRD>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");

                int total = 0;
                predicate = predicate.And(p => p.ISCHECK == true&&p.ISHOT==true);

                var data = base.LoadListBy(predicate).Select(p => new VIEW_MST_PRD()
                {
                    SEQ_NO = p.SEQ_NO,
                    PRD_CD = p.PRD_CD,
                    PRD_SHORT_DESC = p.PRD_SHORT_DESC,
                  CATE_ID=p.CATE_ID
                });
                //var list = ViewModelProduct.ToListViewModel(data);
                return new MODEL.DataTableModel.DataTableGrid()
                {
                    draw = "",
                    data = data,
                    total = total
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
