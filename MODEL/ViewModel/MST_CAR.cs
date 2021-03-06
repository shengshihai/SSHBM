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
    
    public partial class VIEW_MST_CAR_P
    {
        public string CAR_CD { get; set; }
        public string UserId { get; set; }
        public string CAR_NUM { get; set; }
        public string CAR_BRAND { get; set; }
        public string CAR_CATEGORY { get; set; }
        public string CAR_COLOR { get; set; }
        public string CAR_REMARK { get; set; }
        public System.DateTime AddTime { get; set; }
        public string remark1 { get; set; }
        public string remark2 { get; set; }
        public string remark3 { get; set; }
        public Nullable<int> flat1 { get; set; }
        public Nullable<int> flat2 { get; set; }
        public string remark4 { get; set; }
        public string remark5 { get; set; }
        public string remark6 { get; set; }
        public Nullable<int> flat7 { get; set; }
        public Nullable<int> flat8 { get; set; }
        public Nullable<System.DateTime> RegTim1 { get; set; }
        public Nullable<System.DateTime> RegTim2 { get; set; }
        public Nullable<int> VERSION { get; set; }
        public string SYNCOPERATION { get; set; }
        public Nullable<System.DateTime> SYNCVERSION { get; set; }
        public string SYNCFLAG { get; set; }
        public Nullable<System.DateTime> CREATE_DT { get; set; }
        public string CREATE_BY { get; set; }
        public Nullable<System.DateTime> MODIFY_DT { get; set; }
        public string MODIFY_BY { get; set; }
        public string CAR_DATE { get; set; }
    
        public virtual YX_weiUser YX_weiUser { get; set; }
    }
    public partial class VIEW_MST_CAR:VIEW_MST_CAR_P
    {
    
    
    
    	public static MST_CAR ToEntity(VIEW_MST_CAR model)
        {
           MST_CAR item = new MST_CAR();
       		item.CAR_CD=model.CAR_CD;
    		item.UserId=model.UserId;
    		item.CAR_NUM=model.CAR_NUM;
    		item.CAR_BRAND=model.CAR_BRAND;
    		item.CAR_CATEGORY=model.CAR_CATEGORY;
    		item.CAR_COLOR=model.CAR_COLOR;
    		item.CAR_REMARK=model.CAR_REMARK;
    		item.AddTime=model.AddTime;
    		item.remark1=model.remark1;
    		item.remark2=model.remark2;
    		item.remark3=model.remark3;
    		item.flat1=model.flat1;
    		item.flat2=model.flat2;
    		item.remark4=model.remark4;
    		item.remark5=model.remark5;
    		item.remark6=model.remark6;
    		item.flat7=model.flat7;
    		item.flat8=model.flat8;
    		item.RegTim1=model.RegTim1;
    		item.RegTim2=model.RegTim2;
    		item.VERSION=model.VERSION;
    		item.SYNCOPERATION=model.SYNCOPERATION;
    		item.SYNCVERSION=model.SYNCVERSION;
    		item.SYNCFLAG=model.SYNCFLAG;
    		item.CREATE_DT=model.CREATE_DT;
    		item.CREATE_BY=model.CREATE_BY;
    		item.MODIFY_DT=model.MODIFY_DT;
    		item.MODIFY_BY=model.MODIFY_BY;
    		item.CAR_DATE=model.CAR_DATE;
            return item;
        }
    
    
    	public static VIEW_MST_CAR ToViewModel(MST_CAR model)
        {
           VIEW_MST_CAR item = new VIEW_MST_CAR();
       		item.CAR_CD=model.CAR_CD;
    		item.UserId=model.UserId;
    		item.CAR_NUM=model.CAR_NUM;
    		item.CAR_BRAND=model.CAR_BRAND;
    		item.CAR_CATEGORY=model.CAR_CATEGORY;
    		item.CAR_COLOR=model.CAR_COLOR;
    		item.CAR_REMARK=model.CAR_REMARK;
    		item.AddTime=model.AddTime;
    		item.remark1=model.remark1;
    		item.remark2=model.remark2;
    		item.remark3=model.remark3;
    		item.flat1=model.flat1;
    		item.flat2=model.flat2;
    		item.remark4=model.remark4;
    		item.remark5=model.remark5;
    		item.remark6=model.remark6;
    		item.flat7=model.flat7;
    		item.flat8=model.flat8;
    		item.RegTim1=model.RegTim1;
    		item.RegTim2=model.RegTim2;
    		item.VERSION=model.VERSION;
    		item.SYNCOPERATION=model.SYNCOPERATION;
    		item.SYNCVERSION=model.SYNCVERSION;
    		item.SYNCFLAG=model.SYNCFLAG;
    		item.CREATE_DT=model.CREATE_DT;
    		item.CREATE_BY=model.CREATE_BY;
    		item.MODIFY_DT=model.MODIFY_DT;
    		item.MODIFY_BY=model.MODIFY_BY;
    		item.CAR_DATE=model.CAR_DATE;
            return item;
        }
    
    	    public static IEnumerable<VIEW_MST_CAR> ToListViewModel(IEnumerable<MST_CAR> list)
            {
                var listModel = new List<VIEW_MST_CAR>();
                foreach (MST_CAR item in list)
                {
                    listModel.Add(VIEW_MST_CAR.ToViewModel(item));
                }
                return listModel;
            }
    
    
    }
}

//----------------------------jiezhi------------------------------------

