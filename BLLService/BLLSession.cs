using IBLLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLService
{
    public partial class BLLSession:IBLLService.IBLLSession
    {
        IWeChat_MANAGER iWeChat_MANAGER;
        public IWeChat_MANAGER IWeChat_MANAGER
        {
            get
            {
                if (iWeChat_MANAGER == null)
                    iWeChat_MANAGER = new WeChat_MANAGER();
                return iWeChat_MANAGER;
            }
            set
            {
                iWeChat_MANAGER = value;
            }
        }
    }
    public partial class WeChat_MANAGER : IWeChat_MANAGER
    {

    }
}
