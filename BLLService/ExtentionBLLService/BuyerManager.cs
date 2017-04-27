using IBLLService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
    public partial class BuyerManager : BaseBLLService<buyer>, IBuyerManager
    {
        public override int Add(buyer model)
        {
            base.Add(model);
            return model.bid;
        }
    }
}
