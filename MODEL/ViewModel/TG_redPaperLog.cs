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
    
    public partial class VIEW_TG_redPaperLog_P
    {
        public int Id { get; set; }
        public string userOpenId { get; set; }
        public string UserNickName { get; set; }
        public string userTel { get; set; }
        public Nullable<decimal> reaPaperMoney { get; set; }
        public Nullable<int> jifen { get; set; }
        public Nullable<System.DateTime> GetTime { get; set; }
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
    }
    public partial class VIEW_TG_redPaperLog:VIEW_TG_redPaperLog_P
    {
    
    
    
    	public static TG_redPaperLog ToEntity(VIEW_TG_redPaperLog model)
        {
           TG_redPaperLog item = new TG_redPaperLog();
       		item.Id=model.Id;
    		item.userOpenId=model.userOpenId;
    		item.UserNickName=model.UserNickName;
    		item.userTel=model.userTel;
    		item.reaPaperMoney=model.reaPaperMoney;
    		item.jifen=model.jifen;
    		item.GetTime=model.GetTime;
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
            return item;
        }
    
    
    	public static VIEW_TG_redPaperLog ToViewModel(TG_redPaperLog model)
        {
           VIEW_TG_redPaperLog item = new VIEW_TG_redPaperLog();
       		item.Id=model.Id;
    		item.userOpenId=model.userOpenId;
    		item.UserNickName=model.UserNickName;
    		item.userTel=model.userTel;
    		item.reaPaperMoney=model.reaPaperMoney;
    		item.jifen=model.jifen;
    		item.GetTime=model.GetTime;
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
            return item;
        }
    
    	    public static IEnumerable<VIEW_TG_redPaperLog> ToListViewModel(IEnumerable<TG_redPaperLog> list)
            {
                var listModel = new List<VIEW_TG_redPaperLog>();
                foreach (TG_redPaperLog item in list)
                {
                    listModel.Add(VIEW_TG_redPaperLog.ToViewModel(item));
                }
                return listModel;
            }
    
    
    }
}

//----------------------------jiezhi------------------------------------
