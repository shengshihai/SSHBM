using MODEL.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface ITokenConfig_MANAGER : IBaseBLLService<MODEL.TokenConfig>
    {
        string IsExistAccess_Token();

    }
}
