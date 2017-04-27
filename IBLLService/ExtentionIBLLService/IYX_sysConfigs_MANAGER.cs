using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface IYX_sysConfigs_MANAGER : IBaseBLLService<MODEL.YX_sysConfigs>
    {
        string GetKeyValue(string key);
        bool Save(string name, string value);

    }
}
