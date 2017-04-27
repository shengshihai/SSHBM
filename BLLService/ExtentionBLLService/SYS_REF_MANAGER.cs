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
    public partial class SYS_REF_MANAGER : BaseBLLService<SYS_REF>, ISYS_REF_MANAGER
    {

        public bool Save(string name, string value)
        {
            bool status = false;
          
           try
           {
               var model=base.GetModelWithOutTrace(sc => sc.REF_TYPE== "WebSiteSYS"&&sc.REF_PARAM==name);
               if (model != null)
               {
                   model.REF_VALUE = value;
                   base.Modify(model, "REF_VALUE");
               }
               else
               {
                   model = new SYS_REF() { REF_TYPE = "WebSiteSYS", REF_PARAM=name, REF_VALUE= value, REF_SEQ = 1 };
                   base.Add(model);
               }
               IDBSession.SaveChanges();

               return status;
           }
           catch (Exception)
           {

               return status;
           }
        }
    }
}
