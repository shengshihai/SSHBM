using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class VIEW_MENUSBUTTONS
    {
        #region - 属性 -

        public string ModulePermissionID { get; set; }

        public string MenuID { get; set; }

        public string ButtonID { get; set; }

        public string ButtonName { get; set; }

        public string MenuName { get; set; }

        public string MenuUrl { get; set; }

        public string MenuController { get; set; }

        public string ButtonAction { get; set; }

        public string ButtonIcon { get; set; }

        public string MenuNo { get; set; }

        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public string ParentID { get; set; }
        #endregion
        /// <summary>
        /// ToEntity实体对象(保存到数据库的实体对象)
        /// </summary>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static FW_MODULEPERMISSION ToEntity(VIEW_MENUSBUTTONS buttons)
        {
            FW_MODULEPERMISSION item = new FW_MODULEPERMISSION();
            item.MP_ID = buttons.ModulePermissionID;
            item.MODULE_ID = buttons.MenuID;
            item.PERMISSION_ID = buttons.ButtonID;
            item.MODIFY_DT = DateTime.Now;
            item.MODIFY_BY = SessionHelper.Get("UsrId");
            item.CREATE_BY = SessionHelper.Get("UsrId");
           // item.isDel = buttons.IsDeleted;
            return item;
        }
    }
}
