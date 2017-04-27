using MODEL;
using MODEL.DataTableModel;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLLService
{
    public partial interface IFW_MODULEPERMISSION_MANAGER : IBaseBLLService<FW_MODULEPERMISSION>
    {


        DataTableGrid GetMenusButtonsForGrid(MODEL.DataTableModel.DataTableRequest request);

        int SetMenusButtonsByMenuCD(string menu_cd);

        IEnumerable<VIEW_FW_MODULEPERMISSION> GetAllModulePermission();

    }
}
