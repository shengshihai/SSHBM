//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODEL.ViewModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class VIEW_MST_CATALOG_P
    {
        public VIEW_MST_CATALOG_P()
        {
            this.SYNCOPERATION = "A";
        }
    
        public string CATALOG_CD { get; set; }
        public string CATALOG_PCD { get; set; }
        public string NAME { get; set; }
        public string PREVIEW { get; set; }
        public string REMARK { get; set; }
        public Nullable<int> SEQ_NO { get; set; }
        public string TEMPLATE { get; set; }
        public string ICON { get; set; }
        public string SCRIPT { get; set; }
        public string CATALOG_URL { get; set; }
        public string ISSHOW { get; set; }
        public string ACTIVE { get; set; }
        public Nullable<decimal> VERSION { get; set; }
        public string SYNCOPERATION { get; set; }
        public Nullable<System.DateTime> SYNCVERSION { get; set; }
        public string SYNCFLAG { get; set; }
        public Nullable<System.DateTime> CREATE_DT { get; set; }
        public string CREATE_BY { get; set; }
        public Nullable<System.DateTime> MODIFY_DT { get; set; }
        public string MODIFY_BY { get; set; }
    }
    public partial class VIEW_MST_CATALOG:VIEW_MST_CATALOG_P
    {
    
    
    
    	public static MST_CATALOG ToEntity(VIEW_MST_CATALOG model)
        {
           MST_CATALOG item = new MST_CATALOG();
       		item.CATALOG_CD=model.CATALOG_CD;
    		item.CATALOG_PCD=model.CATALOG_PCD;
    		item.NAME=model.NAME;
    		item.PREVIEW=model.PREVIEW;
    		item.REMARK=model.REMARK;
    		item.SEQ_NO=model.SEQ_NO;
    		item.TEMPLATE=model.TEMPLATE;
    		item.ICON=model.ICON;
    		item.SCRIPT=model.SCRIPT;
    		item.CATALOG_URL=model.CATALOG_URL;
    		item.ISSHOW=model.ISSHOW;
    		item.ACTIVE=model.ACTIVE;
    		item.VERSION=model.VERSION;
    		item.SYNCOPERATION=model.SYNCOPERATION;
    		item.SYNCVERSION=model.SYNCVERSION;
    		item.SYNCFLAG=model.SYNCFLAG;
    		item.CREATE_DT=model.CREATE_DT;
    		item.CREATE_BY=model.CREATE_BY;
    		item.MODIFY_DT=model.MODIFY_DT;
    		item.MODIFY_BY=model.MODIFY_BY;
            return item;
        }
    
    
    	public static VIEW_MST_CATALOG ToViewModel(MST_CATALOG model)
        {
           VIEW_MST_CATALOG item = new VIEW_MST_CATALOG();
       		item.CATALOG_CD=model.CATALOG_CD;
    		item.CATALOG_PCD=model.CATALOG_PCD;
    		item.NAME=model.NAME;
    		item.PREVIEW=model.PREVIEW;
    		item.REMARK=model.REMARK;
    		item.SEQ_NO=model.SEQ_NO;
    		item.TEMPLATE=model.TEMPLATE;
    		item.ICON=model.ICON;
    		item.SCRIPT=model.SCRIPT;
    		item.CATALOG_URL=model.CATALOG_URL;
    		item.ISSHOW=model.ISSHOW;
    		item.ACTIVE=model.ACTIVE;
    		item.VERSION=model.VERSION;
    		item.SYNCOPERATION=model.SYNCOPERATION;
    		item.SYNCVERSION=model.SYNCVERSION;
    		item.SYNCFLAG=model.SYNCFLAG;
    		item.CREATE_DT=model.CREATE_DT;
    		item.CREATE_BY=model.CREATE_BY;
    		item.MODIFY_DT=model.MODIFY_DT;
    		item.MODIFY_BY=model.MODIFY_BY;
            return item;
        }
    
    	    public static IEnumerable<VIEW_MST_CATALOG> ToListViewModel(IEnumerable<MST_CATALOG> list)
            {
                var listModel = new List<VIEW_MST_CATALOG>();
                foreach (MST_CATALOG item in list)
                {
                    listModel.Add(VIEW_MST_CATALOG.ToViewModel(item));
                }
                return listModel;
            }
    
    
    }
}

//----------------------------jiezhi------------------------------------

