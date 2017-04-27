using IBLLService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
    public partial class Buyer_userManager : BaseBLLService<buyer_user>, IBuyer_userManager
    {
        public override int Add(buyer_user model)
        {
            base.Add(model);
            return model.buid;
        }
    }
}
