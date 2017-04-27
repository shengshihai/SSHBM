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

    public partial class FW_MODULE_MANAGER : BaseBLLService<FW_MODULE>, IFW_MODULE_MANAGER
    {

        public MODEL.DataTableModel.DataTableGrid GetMenusForGrid(MODEL.DataTableModel.DataTableRequest request)
        {
            try
            {

                var predicate = PredicateBuilder.True<FW_MODULE>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");

                int total = 0;
                //predicate = predicate.And(p => p.isdelete != 1);

                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName).Select(p => new VIEW_FW_MODULE(){
                    	MODULE_ID=p.MODULE_ID,
    		            MODULE_NAME=p.MODULE_NAME,
    		            MODULE_LINK=p.MODULE_LINK,
    		            ICON=p.ICON,
    		            MODULE_PID=p.MODULE_PID,
    		            SEQ_NO=p.SEQ_NO,
    		            ISVISIBLE=p.ISVISIBLE,
    		            ISLEAF=p.ISLEAF,
    		            ISMENU=p.ISMENU,
    		            MODULE_CONTROLLER=p.MODULE_CONTROLLER,
    		            CREATE_DT=p.CREATE_DT,
    		            CREATE_BY=p.CREATE_BY,
    		            MODIFY_DT=p.MODIFY_DT,
    		            MODIFY_BY=p.MODIFY_BY
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
    }
}
