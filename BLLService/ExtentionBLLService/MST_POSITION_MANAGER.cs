using Common;
using IBLLService;
using IDALRepository;
using MODEL;
using MODEL.DataTableModel;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLLService
{

    public partial class MST_POSITION_MANAGER : BaseBLLService<MST_POSITION>, IMST_POSITION_MANAGER
    {
        public MODEL.DataTableModel.DataTableGrid GetPositionGrid(MODEL.DataTableModel.DataTableRequest request)
        {
            try
            {

                var predicate = PredicateBuilder.True<MST_POSITION>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");
                int total = 0;
                predicate = predicate.And(p => p.STATUS == "Y" && p.SYNCOPERATION != "D");
                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName).Select(p => new VIEW_MST_POSITION()
                {
                    POSITION_CD = p.POSITION_CD,
                    COMPANY_CD = p.COMPANY_CD,
                    NAME = p.NAME,
                    DEPARTMENTNAME = p.DEPARTMENTNAME,
                    WORKTYPE = p.WORKTYPE,
                    MONEY = p.MONEY,
                    WORKPLACE = p.WORKPLACE,
                    EXPERIENCE = p.EXPERIENCE,
                    EDUCATION = p.EDUCATION,
                    REMARK = p.REMARK,
                    ISNEW = p.ISNEW,
                    ISHOT = p.ISHOT,
                    STATUS = p.STATUS,
                    PUBLISH_DT = p.PUBLISH_DT,
                    COMPANY_NAME = p.MST_COMPANY.COMPANY_NAME,
                    COMPANY_SIZE = p.MST_COMPANY.COMPANY_SIZE,
                    DEVELOPMENT = p.MST_COMPANY.DEVELOPMENT

                });
                //var list = ViewModelProduct.ToListViewModel(data);
                return new DataTableGrid()
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
