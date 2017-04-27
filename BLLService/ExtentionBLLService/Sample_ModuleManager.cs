using IBLLService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLService
{
    public partial class Sample_ModuleManager : BaseBLLService<Sample_Module>, ISample_ModuleManager
    {
        public IQueryable<Sample_Module> GetAdminMenus(MODEL.ViewModel.LigerUIGridRequest request, out int Count)
        {
            throw new NotImplementedException();
        }
    }
}
