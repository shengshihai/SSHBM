/*  作者：       盛世海
*  创建时间：   2012/7/17 21:41:51
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MODEL.ViewModel
{

    public class DataTree 
    {
        public string id { get; set; }
        public string text { get; set; }
        public string desc { get; set; }
        public List<DataTree> children { get; set; }
        public string icon { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented,
new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        }
     
        public static DataTree ToEntity(VIEW_MST_CATALOG Catalog)
        {
            DataTree item = new DataTree();
            item.id = Catalog.CATALOG_CD;
            item.text = Catalog.NAME;
            item.desc = Catalog.REMARK;
            if (Catalog.children != null)
                item.children = ToListViewModel(Catalog.children);
            return item;
        }
        public static DataTree ToEntity(VIEW_MST_CATEGORY Category)
        {
            DataTree item = new DataTree();
            item.id = Category.CATE_CD;
            item.text = Category.CATEGORY_NAME;
            item.desc = Category.CATEGORY_NAME;
            if (Category.children != null)
                item.children = ToListViewModel(Category.children);
            return item;
        }

        public static List<DataTree> ToListViewModel(IEnumerable<VIEW_MST_CATALOG> listCatalogs)
        {
            List<DataTree> list = new List<DataTree>();
            foreach (VIEW_MST_CATALOG catalog in listCatalogs)
            {
                list.Add(ToEntity(catalog));
            }
            return list;

        }
        public static List<DataTree> ToListViewModel(IEnumerable<VIEW_MST_CATEGORY> listCategorys)
        {
            List<DataTree> list = new List<DataTree>();
            foreach (VIEW_MST_CATEGORY category in listCategorys)
            {
                list.Add(ToEntity(category));
            }
            return list;

        }
        public static DataTree ToEntity(VIEW_FW_MODULE module)
        {
            DataTree item = new DataTree();
            item.id = module.MODULE_ID;
            item.text = module.MODULE_NAME;
            item.desc = module.ICON;
            return item;
        }
        public static List<DataTree> ToListViewModel(IEnumerable<VIEW_FW_MODULE> listModule)
        {
            List<DataTree> list = new List<DataTree>();
            foreach (VIEW_FW_MODULE module in listModule)
            {
                list.Add(ToEntity(module));
            }
            return list;

        }
      
    }



}
