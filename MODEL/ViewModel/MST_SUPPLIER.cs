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
    
    public partial class VIEW_MST_SUPPLIER_P
    {
        public int SUPPLIER_ID { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string ISCHECK { get; set; }
        public string BANNER_IMG { get; set; }
        public string SUPPLIER_URL { get; set; }
        public Nullable<int> CONTACT_NUM { get; set; }
        public Nullable<int> PRD_NUM { get; set; }
        public string FOOTER { get; set; }
        public string SUPPLIER_DESC { get; set; }
        public string SKYPE { get; set; }
        public string EMAIL { get; set; }
        public string TEL { get; set; }
        public string FAX { get; set; }
        public string PHONE { get; set; }
        public string CN_NAME { get; set; }
        public string STATUS { get; set; }
        public Nullable<decimal> VERSION { get; set; }
        public string SYNCOPERATION { get; set; }
        public Nullable<System.DateTime> SYNCVERSION { get; set; }
        public string SYNCFLAG { get; set; }
        public Nullable<System.DateTime> CREATE_DT { get; set; }
        public string CREATE_BY { get; set; }
        public Nullable<System.DateTime> MODIFY_DT { get; set; }
        public string MODIFY_BY { get; set; }
        public Nullable<int> FLAT1 { get; set; }
        public Nullable<int> FLAT2 { get; set; }
        public string REMARK1 { get; set; }
        public string REMARK2 { get; set; }
        public string REMARK3 { get; set; }
        public string REMARK4 { get; set; }
        public string TREE_NODE_ID { get; set; }
    }
    public partial class VIEW_MST_SUPPLIER:VIEW_MST_SUPPLIER_P
    {
    
    
    
    	public static MST_SUPPLIER ToEntity(VIEW_MST_SUPPLIER model)
        {
           MST_SUPPLIER item = new MST_SUPPLIER();
       		item.SUPPLIER_ID=model.SUPPLIER_ID;
    		item.SUPPLIER_NAME=model.SUPPLIER_NAME;
    		item.ADDRESS=model.ADDRESS;
    		item.ISCHECK=model.ISCHECK;
    		item.BANNER_IMG=model.BANNER_IMG;
    		item.SUPPLIER_URL=model.SUPPLIER_URL;
    		item.CONTACT_NUM=model.CONTACT_NUM;
    		item.PRD_NUM=model.PRD_NUM;
    		item.FOOTER=model.FOOTER;
    		item.SUPPLIER_DESC=model.SUPPLIER_DESC;
    		item.SKYPE=model.SKYPE;
    		item.EMAIL=model.EMAIL;
    		item.TEL=model.TEL;
    		item.FAX=model.FAX;
    		item.PHONE=model.PHONE;
    		item.CN_NAME=model.CN_NAME;
    		item.STATUS=model.STATUS;
    		item.VERSION=model.VERSION;
    		item.SYNCOPERATION=model.SYNCOPERATION;
    		item.SYNCVERSION=model.SYNCVERSION;
    		item.SYNCFLAG=model.SYNCFLAG;
    		item.CREATE_DT=model.CREATE_DT;
    		item.CREATE_BY=model.CREATE_BY;
    		item.MODIFY_DT=model.MODIFY_DT;
    		item.MODIFY_BY=model.MODIFY_BY;
    		item.FLAT1=model.FLAT1;
    		item.FLAT2=model.FLAT2;
    		item.REMARK1=model.REMARK1;
    		item.REMARK2=model.REMARK2;
    		item.REMARK3=model.REMARK3;
    		item.REMARK4=model.REMARK4;
    		item.TREE_NODE_ID=model.TREE_NODE_ID;
            return item;
        }
    
    
    	public static VIEW_MST_SUPPLIER ToViewModel(MST_SUPPLIER model)
        {
           VIEW_MST_SUPPLIER item = new VIEW_MST_SUPPLIER();
       		item.SUPPLIER_ID=model.SUPPLIER_ID;
    		item.SUPPLIER_NAME=model.SUPPLIER_NAME;
    		item.ADDRESS=model.ADDRESS;
    		item.ISCHECK=model.ISCHECK;
    		item.BANNER_IMG=model.BANNER_IMG;
    		item.SUPPLIER_URL=model.SUPPLIER_URL;
    		item.CONTACT_NUM=model.CONTACT_NUM;
    		item.PRD_NUM=model.PRD_NUM;
    		item.FOOTER=model.FOOTER;
    		item.SUPPLIER_DESC=model.SUPPLIER_DESC;
    		item.SKYPE=model.SKYPE;
    		item.EMAIL=model.EMAIL;
    		item.TEL=model.TEL;
    		item.FAX=model.FAX;
    		item.PHONE=model.PHONE;
    		item.CN_NAME=model.CN_NAME;
    		item.STATUS=model.STATUS;
    		item.VERSION=model.VERSION;
    		item.SYNCOPERATION=model.SYNCOPERATION;
    		item.SYNCVERSION=model.SYNCVERSION;
    		item.SYNCFLAG=model.SYNCFLAG;
    		item.CREATE_DT=model.CREATE_DT;
    		item.CREATE_BY=model.CREATE_BY;
    		item.MODIFY_DT=model.MODIFY_DT;
    		item.MODIFY_BY=model.MODIFY_BY;
    		item.FLAT1=model.FLAT1;
    		item.FLAT2=model.FLAT2;
    		item.REMARK1=model.REMARK1;
    		item.REMARK2=model.REMARK2;
    		item.REMARK3=model.REMARK3;
    		item.REMARK4=model.REMARK4;
    		item.TREE_NODE_ID=model.TREE_NODE_ID;
            return item;
        }
    
    	    public static IEnumerable<VIEW_MST_SUPPLIER> ToListViewModel(IEnumerable<MST_SUPPLIER> list)
            {
                var listModel = new List<VIEW_MST_SUPPLIER>();
                foreach (MST_SUPPLIER item in list)
                {
                    listModel.Add(VIEW_MST_SUPPLIER.ToViewModel(item));
                }
                return listModel;
            }
    
    
    }
}

//----------------------------jiezhi------------------------------------

