using MODEL;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
public partial interface IFW_PERMISSION_MANAGER : IBaseBLLService<FW_PERMISSION>
    {

        /// <summary>
        /// 根据条件获取权限信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <param name="Count">总个数</param>
        /// <returns></returns>
        IEnumerable<VIEW_FW_PERMISSION> GetPermission();

    }
}
