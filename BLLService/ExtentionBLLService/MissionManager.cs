using Common;
using IBLLService;
using IDALRepository;
using MODEL;
using MODEL.ViewModel;
using SampleUI.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLLService
{

    public partial class MissionManager : BaseBLLService<mission>, IMissionManager
    {

        public EasyUIGrid GetMissionGrid(DataTableRequest request)
        {
            try
            {
                var predicate = PredicateBuilder.True<mission>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");
                predicate = predicate.And(p => p.isdelete == 0);
                int total = 0;
                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName).Select(m => new ViewModelMission()
                {
                    id = m.id,
                    title = m.title,
                    person = m.person,
                    enddate = m.enddate,
                    createdate = m.createdate,
                    completiondate = m.completiondate,
                    status = m.status,
                    context = m.context,
                    isdelete = m.isdelete,
                    sid = m.sid,
                    suppliername=m.supplier.suppliername,
                    username=m.supplier_user.fullname
                });

                return new MODEL.ViewModel.EasyUIGrid()
                {
                    draw = request.Draw,
                    rows = data,
                    total = total
                };
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int ApprovedMoreMission(List<int> ids)
        {
            var missionList = idal.GetListasNoTrackingBy(m => ids.Contains(m.id)).ToList();
            foreach (var model in missionList)
            {
                model.status = (int)SupplierEnum.SupplierCheckedEnum.Checked;

                idal.Modify(model, "status");
            }
            return IDBSession.SaveChanges();
        }
    }
}
