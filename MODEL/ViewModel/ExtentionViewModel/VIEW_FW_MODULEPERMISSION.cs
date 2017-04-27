using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class VIEW_FW_MODULEPERMISSION : VIEW_FW_MODULEPERMISSION_P
    {

        public string PERMISSION_PID { get; set; }
        public string MODULE_NAME { get; set; }
        public string NAME { get; set; }
        public string ICON { get; set; }
        public int SEQ_NO { get; set; }
        public string ISLINK { get; set; }
        public string LINKURL { get; set; }
        public string REMARK { get; set; }

        public List<VIEW_FW_MODULEPERMISSION> children { get; set; }
    }

}
