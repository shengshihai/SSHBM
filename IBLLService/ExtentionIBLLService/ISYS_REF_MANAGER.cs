using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using MODEL.ViewModel;

namespace IBLLService
{
    public partial interface ISYS_REF_MANAGER : IBaseBLLService<SYS_REF>
    {
        bool Save(string name, string value);
    }
}
