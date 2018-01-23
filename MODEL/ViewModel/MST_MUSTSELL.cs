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
    
    public partial class VIEW_MST_MUSTSELL_P
    {
        public string MUSTSELL_CD { get; set; }
        public string MUSTSELL_NAME { get; set; }
        public Nullable<System.DateTime> STARTDAY { get; set; }
        public Nullable<System.DateTime> ENDDAY { get; set; }
        public Nullable<decimal> VERSION { get; set; }
        public string SYNCOPERATION { get; set; }
        public Nullable<System.DateTime> SYNCVERSION { get; set; }
        public string SYNCFLAG { get; set; }
    }
    public partial class VIEW_MST_MUSTSELL:VIEW_MST_MUSTSELL_P
    {
    
    
    
    	public static MST_MUSTSELL ToEntity(VIEW_MST_MUSTSELL model)
        {
           MST_MUSTSELL item = new MST_MUSTSELL();
       		item.MUSTSELL_CD=model.MUSTSELL_CD;
    		item.MUSTSELL_NAME=model.MUSTSELL_NAME;
    		item.STARTDAY=model.STARTDAY;
    		item.ENDDAY=model.ENDDAY;
    		item.VERSION=model.VERSION;
    		item.SYNCOPERATION=model.SYNCOPERATION;
    		item.SYNCVERSION=model.SYNCVERSION;
    		item.SYNCFLAG=model.SYNCFLAG;
            return item;
        }
    
    
    	public static VIEW_MST_MUSTSELL ToViewModel(MST_MUSTSELL model)
        {
           VIEW_MST_MUSTSELL item = new VIEW_MST_MUSTSELL();
       		item.MUSTSELL_CD=model.MUSTSELL_CD;
    		item.MUSTSELL_NAME=model.MUSTSELL_NAME;
    		item.STARTDAY=model.STARTDAY;
    		item.ENDDAY=model.ENDDAY;
    		item.VERSION=model.VERSION;
    		item.SYNCOPERATION=model.SYNCOPERATION;
    		item.SYNCVERSION=model.SYNCVERSION;
    		item.SYNCFLAG=model.SYNCFLAG;
            return item;
        }
    
    	    public static IEnumerable<VIEW_MST_MUSTSELL> ToListViewModel(IEnumerable<MST_MUSTSELL> list)
            {
                var listModel = new List<VIEW_MST_MUSTSELL>();
                foreach (MST_MUSTSELL item in list)
                {
                    listModel.Add(VIEW_MST_MUSTSELL.ToViewModel(item));
                }
                return listModel;
            }
    
    
    }
}

//----------------------------jiezhi------------------------------------
