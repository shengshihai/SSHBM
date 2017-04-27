namespace Common.EfSearchModel.Binders
{
    using System;
    using System.Web.Mvc;
    using Model;
    using System.Linq;

    /// <summary>
    /// 对SearchModel做为Action参数的绑定
    /// </summary>
    public class SearchModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = (QueryModel)(bindingContext.Model ?? new QueryModel());
            var dict = controllerContext.HttpContext.Request.Params;
            var keys = dict.AllKeys.Where(c => c.StartsWith("["));//我们认为只有[开头的为需要处理的
            if (keys.Count() != 0)
            {
                foreach (var key in keys)
                {
                    if (!key.StartsWith("[")) continue;
                    var val = dict[key];
                    //处理无值的情况
                    if (string.IsNullOrEmpty(val)) continue;
                    AddSearchItem(model, key, val);
                }
            }
            var tablecolumnskeys = dict.AllKeys.Where(c => c.StartsWith("columns[") && c.EndsWith("]"));//针对datatable的数据处理
            var tableorderkeys = dict.AllKeys.Where(c => c.StartsWith("order[0]") && c.EndsWith("]"));//针对datatable的数据处理
            var searchvalue = dict["search[value]"];
            var columnscount = tablecolumnskeys.Count();
            if (columnscount % 6 == 0)
            {
                for (int i = 0; i < (columnscount / 6); i++)
                {
                    var key = dict["columns[" + i + "][name]"];
                    if (!(key).StartsWith("[")) continue;
                    var val = dict["columns[" + i + "][search][value]"];
                    if (string.IsNullOrEmpty(val))
                        val = searchvalue;
                    //处理无值的情况
                    if (string.IsNullOrEmpty(val)) continue;
                    AddSearchItem(model, key, val);

                }

            }
            //if (tableorderkeys.Count() > 0)
            //{
            //    var i = dict["order[0][column]"];
            //    var orderfield = (dict["columns[" + i + "][name]"]);
            //    if (!string.IsNullOrEmpty(orderfield))
            //        orderfield = orderfield.Substring(orderfield.LastIndexOf(']') + 1);
            //    var orderdir = dict["order[0][dir]"];
            //    var key = ""; var val = "asc";
            //    if (!string.IsNullOrEmpty(orderdir))
            //        val = orderdir;
            //    if (!string.IsNullOrEmpty(orderfield))
            //    {
            //        key = "[Equal](order)" + orderfield;
            //        AddSearchItem(model, key, val);
            //    }

            //}
            return model;
        }

        /// <summary>
        /// 将一组key=value添加入QueryModel.Items
        /// </summary>
        /// <param name="model">QueryModel</param>
        /// <param name="key">当前项的HtmlName</param>
        /// <param name="val">当前项的值</param>
        public static void AddSearchItem(QueryModel model, string key, string val)
        {
            string field = "", prefix = "", orGroup = "", method = "";
            var keywords = key.Split(']', ')', '}');
            //将Html中的name分割为我们想要的几个部分
            foreach (var keyword in keywords)
            {
                if (Char.IsLetterOrDigit(keyword[0])) field = keyword;
                var last = keyword.Substring(1);
                if (keyword[0] == '(') prefix = last;
                if (keyword[0] == '[') method = last;
                if (keyword[0] == '{') orGroup = last;
            }
            if (string.IsNullOrEmpty(method)) return;
            if (!string.IsNullOrEmpty(field))
            {
                var item = new ConditionItem
                               {
                                   Field = field,
                                   Value = val.Trim(),
                                   Prefix = prefix,
                                   OrGroup = orGroup,
                                   Method = (QueryMethod)Enum.Parse(typeof(QueryMethod), method)
                               };
                model.Items.Add(item);
            }
        }
    }
}
