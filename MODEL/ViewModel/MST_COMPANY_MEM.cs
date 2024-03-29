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
    
    public partial class VIEW_MST_COMPANY_MEM_P
    {
        public string C_MEMBER_CD { get; set; }
        public string COMPANY_CD { get; set; }
        public string NAME { get; set; }
        public string POSITION_NAME { get; set; }
        public string PHONE { get; set; }
        public string TELEPHONE { get; set; }
        public string PORTRAIT { get; set; }
        public string WEBSITE { get; set; }
        public string ADDRESS { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<int> VERSION { get; set; }
        public string SYNCOPERATION { get; set; }
        public Nullable<System.DateTime> SYNCVERSION { get; set; }
        public string SYNCFLAG { get; set; }
    }
    public partial class VIEW_MST_COMPANY_MEM:VIEW_MST_COMPANY_MEM_P
    {
    
    
    
    	public static MST_COMPANY_MEM ToEntity(VIEW_MST_COMPANY_MEM model)
        {
           MST_COMPANY_MEM item = new MST_COMPANY_MEM();
       		item.C_MEMBER_CD=model.C_MEMBER_CD;
    		item.COMPANY_CD=model.COMPANY_CD;
    		item.NAME=model.NAME;
    		item.POSITION_NAME=model.POSITION_NAME;
    		item.PHONE=model.PHONE;
    		item.TELEPHONE=model.TELEPHONE;
    		item.PORTRAIT=model.PORTRAIT;
    		item.WEBSITE=model.WEBSITE;
    		item.ADDRESS=model.ADDRESS;
    		item.DESCRIPTION=model.DESCRIPTION;
    		item.VERSION=model.VERSION;
    		item.SYNCOPERATION=model.SYNCOPERATION;
    		item.SYNCVERSION=model.SYNCVERSION;
    		item.SYNCFLAG=model.SYNCFLAG;
            return item;
        }
    
    
    	public static VIEW_MST_COMPANY_MEM ToViewModel(MST_COMPANY_MEM model)
        {
           VIEW_MST_COMPANY_MEM item = new VIEW_MST_COMPANY_MEM();
       		item.C_MEMBER_CD=model.C_MEMBER_CD;
    		item.COMPANY_CD=model.COMPANY_CD;
    		item.NAME=model.NAME;
    		item.POSITION_NAME=model.POSITION_NAME;
    		item.PHONE=model.PHONE;
    		item.TELEPHONE=model.TELEPHONE;
    		item.PORTRAIT=model.PORTRAIT;
    		item.WEBSITE=model.WEBSITE;
    		item.ADDRESS=model.ADDRESS;
    		item.DESCRIPTION=model.DESCRIPTION;
    		item.VERSION=model.VERSION;
    		item.SYNCOPERATION=model.SYNCOPERATION;
    		item.SYNCVERSION=model.SYNCVERSION;
    		item.SYNCFLAG=model.SYNCFLAG;
            return item;
        }
    
    	    public static IEnumerable<VIEW_MST_COMPANY_MEM> ToListViewModel(IEnumerable<MST_COMPANY_MEM> list)
            {
                var listModel = new List<VIEW_MST_COMPANY_MEM>();
                foreach (MST_COMPANY_MEM item in list)
                {
                    listModel.Add(VIEW_MST_COMPANY_MEM.ToViewModel(item));
                }
                return listModel;
            }
    
    
    }
}

//----------------------------jiezhi------------------------------------

