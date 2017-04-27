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

    public partial class YX_weiUser_MANAGER : BaseBLLService<YX_weiUser>, IYX_weiUser_MANAGER
    {

        public MODEL.DataTableModel.DataTableGrid GetWeChatUserForGrid(MODEL.DataTableModel.DataTableRequest request)
        {
            try
            {

                var predicate = PredicateBuilder.True<YX_weiUser>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");

                int total = 0;
                //predicate = predicate.And(p => p.isdelete != 1);

                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName);
                //var list = ViewModelProduct.ToListViewModel(data);
                return new MODEL.DataTableModel.DataTableGrid()
                {
                    draw = request.Draw,
                    data = VIEW_YX_weiUser.ToListViewModel(data),
                    total = total
                };
            }
            catch (Exception)
            {

                throw;
            }
        }




        public int ChargeMoney(TG_transactionLog log,YX_weiUser model, params string[] proNames)
        {
            idal.Modify(model, proNames);
            IDBSession.ITG_transactionLog_REPOSITORY.Add(log);
           return  IDBSession.SaveChanges();
        }
    }
}
