using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
	public partial interface IBLLSession
    {
        IWeChat_MANAGER IWeChat_MANAGER { get; set; }
    }
}
