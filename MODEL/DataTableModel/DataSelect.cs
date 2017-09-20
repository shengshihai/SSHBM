/*  作者：       盛世海
*  创建时间：   2012/7/21 9:34:11
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using MODEL;
using MODEL.ActionModel;
using System.Web.Mvc;

namespace MODEL.ViewModel
{
    /// <summary>
    /// EasyUISelect中Select的实体类
    /// </summary>
    public class DataSelect
    {
        #region - 属性 -

        /// <summary>
        /// ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 显示内容
        /// </summary>

        public string text { get; set; }

        public string parentid { get; set; }
        public string style { get; set; }
        #endregion

        #region - 方法 -

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented,
  new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, });

        }

        /// <summary>
        /// 将实体转为为Select列表
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>



        public static DataSelect ToViewModel(VIEW_MST_CATALOG catalog)
        {
            DataSelect item = new DataSelect();
            item.id = catalog.CATALOG_CD;
            item.value = catalog.CATALOG_CD;
            item.text = catalog.NAME;
            return item;
        }
        public static DataSelect ToViewModel(VIEW_MST_CATEGORY category)
        {
            DataSelect item = new DataSelect();
            item.id = category.CATE_CD;
            item.value = category.CATE_CD;
            item.text = category.CATEGORY_NAME;
            return item;
        }
        public static IEnumerable<DataSelect> ToListModel(IEnumerable<VIEW_MST_CATALOG> list)
        {
            var selectList = new List<DataSelect>() { new DataSelect { id = "", text = "顶级分类", value = "" } };
            foreach (var item in list)
            {
                selectList.Add(DataSelect.ToViewModel(item));
            }
            return selectList;
        }
        public static IEnumerable<DataSelect> ToListModel(IEnumerable<VIEW_MST_CATEGORY> list)
        {
            var selectList = new List<DataSelect>() { new DataSelect { id = "", text = "顶级分类", value = "" } };
            foreach (var item in list)
            {
                selectList.Add(DataSelect.ToViewModel(item));
            }
            return selectList;
        }

        public static DataSelect ToEntity(VIEW_FW_MODULE module)
        {
            DataSelect item = new DataSelect();
            item.id = module.MODULE_ID;
            item.text = module.MODULE_NAME;
            item.value = module.ICON;
            item.parentid = module.MODULE_PID;
            return item;
        }
        public static SelectListItem ToEntity(VIEW_FW_MODULE module, string style)
        {
            //   '<div><span  class="' + state .style+ '"></span> ' + state.text + 'c'
            SelectListItem item = new SelectListItem();
            item.Value = module.MODULE_ID;
            if(string.IsNullOrEmpty(style))
            item.Text = module.MODULE_NAME;
            else
                item.Text = "<div><span  class='" + style + "'></span>" + module.MODULE_NAME + "</div>";
            return item;
        }
        public static SelectListItem ToEntity(VIEW_MST_CATEGORY category, string style)
        {
            //   '<div><span  class="' + state .style+ '"></span> ' + state.text + 'c'
            SelectListItem item = new SelectListItem();
            item.Value = category.CATE_CD;
            if (string.IsNullOrEmpty(style))
                item.Text = category.CATEGORY_NAME;
            else
                item.Text = "<div><span  class='" + style + "'></span>" + category.CATEGORY_NAME + "</div>";
            return item;
        }
        public static SelectListItem ToEntity(VIEW_MST_CATALOG catalog, string style)
        {
            //   '<div><span  class="' + state .style+ '"></span> ' + state.text + 'c'
            SelectListItem item = new SelectListItem();
            item.Value = catalog.CATALOG_CD;
            if (string.IsNullOrEmpty(style))
                item.Text = catalog.NAME;
            else
                item.Text = "<div><span  class='" + style + "'></span>" + catalog.NAME + "</div>";
            return item;
        }
        public static List<SelectListItem> ToListViewModel(IEnumerable<VIEW_FW_MODULE> listModule)
        {
            List<SelectListItem> list = new List<SelectListItem>() { new SelectListItem() { Value = "", Text = "请选择" } };

            foreach (VIEW_FW_MODULE module in listModule.Where(m=>m.MODULE_PID==""))
            {
                list.Add(ToEntity(module,"b1"));
                foreach (var item in listModule.Where(m=>m.MODULE_PID==module.MODULE_ID))
                {
                    list.Add(ToEntity(item, "b2"));
                     foreach (var itemtwo in listModule.Where(m => m.MODULE_PID == item.MODULE_ID))
                     {
                         list.Add(ToEntity(itemtwo, "b3"));
                     }
                }
            }
            return list;

        }
        public static List<SelectListItem> ToListViewModel(IEnumerable<VIEW_MST_CATEGORY> listCategory)
        {
            List<SelectListItem> list = new List<SelectListItem>() { new SelectListItem() { Value = "", Text = "请选择" } };

            foreach (VIEW_MST_CATEGORY category in listCategory.Where(m => m.PARENT_CD == "MAIN"))
            {
                list.Add(ToEntity(category, "b1"));
                foreach (var item in listCategory.Where(m => m.PARENT_CD == category.CATE_CD))
                {
                    list.Add(ToEntity(item, "b2"));
                    foreach (var itemtwo in listCategory.Where(m => m.PARENT_CD == item.CATE_CD))
                    {
                        list.Add(ToEntity(itemtwo, "b3"));
                    }
                }
            }
            return list;

        }
        public static SelectListItem ToEntity(MVCController controller)
        {
            SelectListItem item = new SelectListItem();
            item.Value = controller.ControllerName;
             item.Text = controller.ControllerName;
            return item;
        }
        public static List<SelectListItem> ToListViewModel(IEnumerable<MVCController> listcontroller)
        {
            List<SelectListItem> list = new List<SelectListItem>() { new SelectListItem() { Value = " ", Text = "请选择" } };
            foreach (MVCController module in listcontroller)
            {
                list.Add(ToEntity(module));
                
            }
            return list;

        }
        public static SelectListItem ToEntity(VIEW_YX_weiXinMenus weiXinMenu)
        {
            SelectListItem item = new SelectListItem();
            item.Value = weiXinMenu.Id.ToString();
            item.Text = weiXinMenu.WX_menuName;
            return item;
        }
  
        public static List<SelectListItem> ToListViewModel(IEnumerable<VIEW_YX_weiXinMenus> listweiXinMenu)
        {
            List<SelectListItem> list = new List<SelectListItem>() { new SelectListItem() { Value = "0", Text = "请选择" } };
            foreach (VIEW_YX_weiXinMenus weiXinMenu in listweiXinMenu)
            {
                list.Add(ToEntity(weiXinMenu));

            }
            return list;

        }
        public static List<SelectListItem> ToListViewModel(IEnumerable<VIEW_MST_CATALOG> listCatalog)
        {
            List<SelectListItem> list = new List<SelectListItem>() { new SelectListItem() { Value = "", Text = "请选择" } };

            foreach (VIEW_MST_CATALOG catalog in listCatalog.Where(m => m.CATALOG_PCD == ""))
            {
                list.Add(ToEntity(catalog, "b1"));
                foreach (var item in listCatalog.Where(m => m.CATALOG_PCD == catalog.CATALOG_CD))
                {
                    list.Add(ToEntity(item, "b2"));
                    foreach (var itemtwo in listCatalog.Where(m => m.CATALOG_PCD == item.CATALOG_CD))
                    {
                        list.Add(ToEntity(itemtwo, "b3"));
                    }
                }
            }
            return list;

        }
        public static SelectListItem ToEntity(VIEW_YX_weiUser weiUser)
        {
            SelectListItem item = new SelectListItem();
            item.Value = weiUser.userNum;
            item.Text = string.IsNullOrEmpty(weiUser.userRelname)?weiUser.nickname:weiUser.userRelname;
            return item;
        }
        public static List<SelectListItem> ToListViewModel(IEnumerable<VIEW_YX_weiUser> listweiUser)
        {
            List<SelectListItem> list = new List<SelectListItem>() { new SelectListItem() { Value = "", Text = "请选择" } };
            foreach (VIEW_YX_weiUser weiUser in listweiUser)
            {
                list.Add(ToEntity(weiUser));

            }
            return list;

        }
        public static SelectListItem ToEntity(VIEW_MST_SUPPLIER supplier)
        {
            SelectListItem item = new SelectListItem();
            item.Value = supplier.SUPPLIER_ID.ToString();
            item.Text =  supplier.SUPPLIER_NAME;
            return item;
        }
        public static SelectListItem ToEntity_TreeNode(VIEW_MST_SUPPLIER supplier)
        {
            SelectListItem item = new SelectListItem();
            item.Value = supplier.TREE_NODE_ID.ToString();
            item.Text = supplier.SUPPLIER_NAME;
            return item;
        }
        public static List<SelectListItem> ToListViewModel(IEnumerable<VIEW_MST_SUPPLIER> listsupplier)
        {
            List<SelectListItem> list = new List<SelectListItem>() { new SelectListItem() { Value = "", Text = "请选择" } };
            foreach (VIEW_MST_SUPPLIER supplier in listsupplier)
            {
                list.Add(ToEntity(supplier));

            }
            return list;

        }
        public static List<SelectListItem> ToListViewModel(IEnumerable<VIEW_MST_SUPPLIER> listsupplier,bool isTreeNode)
        {
            List<SelectListItem> list = new List<SelectListItem>() { new SelectListItem() { Value = "", Text = "请选择" } };
            foreach (VIEW_MST_SUPPLIER supplier in listsupplier)
            {
                if(isTreeNode)
                    list.Add(ToEntity_TreeNode(supplier));
                else
                    list.Add(ToEntity(supplier));

            }
            return list;

        }
        public static SelectListItem ToEntity(VIEW_SYS_REF sysref)
        {
            SelectListItem item = new SelectListItem();
            item.Value = sysref.REF_PARAM;
            item.Text = sysref.REF_VALUE;
            return item;
        }
        public static List<SelectListItem> ToListViewModel(IEnumerable<VIEW_SYS_REF> listsysref)
        {
            List<SelectListItem> list = new List<SelectListItem>() { new SelectListItem() { Value = "0", Text = "请选择" } };
            foreach (VIEW_SYS_REF sysref in listsysref)
            {
                list.Add(ToEntity(sysref));

            }
            return list;

        }
        #endregion

    }

}
