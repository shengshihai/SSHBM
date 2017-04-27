using MODEL;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IBLLService
{
    public partial interface IFW_OPERATELOGManager : IBaseBLLService<FW_OPERATELOG>
    {
        /// <summary>
        /// 获取树形的Grid的json数据
        /// </summary>
        /// <param name="gridData"></param>
        /// <returns></returns>
        EasyUIGrid GetAllLogsToGrid(EasyUIGridRequest gridData);
        /// <summary>
        /// 写系统操作日志
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        bool WriteOperateLog(VIEW_FW_OPERATELOG log);
        /// <summary>
        /// 清空三个月以前的日志
        /// </summary>
        /// <returns></returns>
        bool DeleteThreeMonthLogs();
    }
}
