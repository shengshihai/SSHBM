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
    public partial class Sample_OperateLogManager : BaseBLLService<Sample_OperateLog>, ISample_OperateLogManager
    {

        /// <summary>
        /// 获取树形的Grid的json数据
        /// </summary>
        /// <param name="gridData"></param>
        /// <returns></returns>
        public EasyUIGrid GetAllLogsToGrid(EasyUIGridRequest gridData)
        {
            string alias = "o";
            string where = FilterHelper.GetFilterTanslate(gridData.Where,"o");
            string sortName = alias + "." + gridData.SortName;
            int total = 0;
            IEnumerable<Sample_OperateLog> list = base.GetPagedList(gridData.PageNumber, gridData.PageSize, ref total, so=>true,so => so.createDate,false).ToList();
            List<ViewModelOperateLog> listLogs = new List<ViewModelOperateLog>();
            foreach (Sample_OperateLog log in list)
            {
                listLogs.Add(ViewModelOperateLog.ToViewModel(log));
            }
            EasyUIGrid grid = new EasyUIGrid();
            grid.rows = listLogs;
            grid.total = total;
            return grid;

        }
        /// <summary>
        /// 写系统操作日志
        /// </summary>
        /// <param name="Log"></param>
        /// <returns></returns>
        public  bool WriteOperateLog(ViewModelOperateLog Log)
        {
            try
            {
                foreach (var item in ((System.Data.Entity.Infrastructure.IObjectContextAdapter)IDBSession.DbContext).ObjectContext.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added | System.Data.EntityState.Modified | System.Data.EntityState.Deleted))
                {
                    item.AcceptChanges();
                }
               idal.Add(ViewModelOperateLog.ToEntity(Log));
               IDBSession.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //public override int Add(Sample_OperateLog model)
        //{
        //    idal.Add(
        //}
        /// <summary>
        /// 清空三个月以前的日志
        /// </summary>
        /// <returns></returns>
        public bool DeleteThreeMonthLogs()
        {
            int month = 3;
            return true;
        }
    }
}
