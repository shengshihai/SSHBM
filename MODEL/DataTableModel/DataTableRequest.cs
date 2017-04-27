/*  作者：       sea
*  创建时间：   2012/7/19 18:16:08
*
*/
/*  作者：       sea
*  创建时间：   2012/7/16 15:31:37
*
*/

using Common;
using Common.EfSearchModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace MODEL.DataTableModel
{
    public class DataTableRequest
    {

        private bool sortOrder;

        private int pageSize;
        /// <summary>
        /// 字段查看视图(暂时没做到)
        /// </summary>
        public string View
        {
            get;
            set;
        }
        /// <summary>
        /// 排序字段名称
        /// </summary>
        public string SortName { get; set; }
        /// <summary>
        /// 排序规则
        /// </summary>
        public bool SortOrder
        {
            get
            {
                if (this.sortOrder == false)
                    return this.sortOrder;
                else
                    return true;
            }

            set
            {
                this.sortOrder = value;
            }
        }
        private int pageNumber;
        /// <summary>
        /// 页号
        /// </summary>
        public int PageNumber
        {
            get
            {
                if (this.pageNumber <= 0)
                    return 1;
                else
                    return pageNumber;
            }
            set
            {
                if (value <= 0)
                    pageNumber = 1;
                else
                    pageNumber = value;
            }
        }

        /// <summary>
        /// 每页的多少条数据
        /// </summary>
        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                this.pageSize = (value == 0 ? 10 : value);
            }
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Where { get; set; }

        public string Search { get; set; }

        public string controllerName { get; set; }
        /// <summary>
        /// Draw
        /// </summary>
        public string Draw { get; set; }
        /// <summary>
        /// 页号
        /// </summary>
        public int ID { get; set; }

        private int parentId;
        /// <summary>
        /// 页号
        /// </summary>
        public int ParentId
        {
            get
            {
                if (this.parentId <= 0)
                    return 0;
                else
                    return parentId;
            }
            set
            {
                parentId = value;
            }
        }
        public QueryModel Model { get; set; }
        /// <summary>
        /// 初始化读取信息
        /// </summary>
        /// <param name="context"></param>
        public DataTableRequest(HttpContextBase context)
        {
            this.View = context.Request["view"];
            this.Draw = context.Request["draw"];
            var columnid = context.Request["order[0][column]"];
            this.SortName = "";
            if (!string.IsNullOrEmpty(columnid))
                this.SortName = context.Request["columns["+columnid+"][orderable]"];
            this.SortOrder = context.Request["order[0][dir]"] == "asc" ? true : false;
            //this.PageNumber = TypeParser.ToInt32(context.Request["page"]);
            this.PageSize = TypeParser.ToInt32(context.Request["length"]);
            this.PageNumber = (TypeParser.ToInt32(context.Request["start"])/this.pageSize)+1;
            if (string.IsNullOrEmpty(context.Request["where"]))
                this.Where = context.Request["filterRules"];
            else
                this.Where = context.Request["where"];
            this.Search = context.Request["search[value]"];

            controllerName = context.Request["controllerName"];

            this.ID = TypeParser.ToInt32(context.Request["ID"]);
            this.ParentId = TypeParser.ToInt32(context.Request["ParentId"]);
        }
        public DataTableRequest(HttpContextBase context,QueryModel model)
        {
            this.View = context.Request["view"];
            this.Draw = context.Request["draw"];
            var columnid = context.Request["order[0][column]"];
            this.SortName = "";
            if (!string.IsNullOrEmpty(columnid))
                this.SortName = context.Request["columns[" + columnid + "][orderable]"];
            this.SortOrder = context.Request["order[0][dir]"] == "asc" ? true : false;
            this.PageSize = TypeParser.ToInt32(context.Request["length"]);
            this.PageNumber = (TypeParser.ToInt32(context.Request["start"]) / this.pageSize) + 1;
            if (string.IsNullOrEmpty(context.Request["where"]))
                this.Where = context.Request["filterRules"];
            else
                this.Where = context.Request["where"];
            this.Search = context.Request["search[value]"];

            controllerName = context.Request["controllerName"];

            this.ID = TypeParser.ToInt32(context.Request["ID"]);
            this.ParentId = TypeParser.ToInt32(context.Request["ParentId"]);
            this.Model = model;
        }
    }
}
