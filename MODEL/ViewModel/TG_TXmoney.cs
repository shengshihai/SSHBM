//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODEL.ViewModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class VIEW_TG_TXmoney_P
    {
        public int Id { get; set; }
        public Nullable<int> userId { get; set; }
        public string openid { get; set; }
        public string Utel { get; set; }
        public Nullable<decimal> TXmoney { get; set; }
        public string bankInfo { get; set; }
        public string bankUserInfo { get; set; }
        public Nullable<int> TXstate { get; set; }
        public Nullable<System.DateTime> Addtime { get; set; }
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
    public partial class VIEW_TG_TXmoney:VIEW_TG_TXmoney_P
    {
    
    
    
    	public static TG_TXmoney ToEntity(VIEW_TG_TXmoney model)
        {
           TG_TXmoney item = new TG_TXmoney();
       		item.Id=model.Id;
    		item.userId=model.userId;
    		item.openid=model.openid;
    		item.Utel=model.Utel;
    		item.TXmoney=model.TXmoney;
    		item.bankInfo=model.bankInfo;
    		item.bankUserInfo=model.bankUserInfo;
    		item.TXstate=model.TXstate;
    		item.Addtime=model.Addtime;
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
    
    
    	public static VIEW_TG_TXmoney ToViewModel(TG_TXmoney model)
        {
           VIEW_TG_TXmoney item = new VIEW_TG_TXmoney();
       		item.Id=model.Id;
    		item.userId=model.userId;
    		item.openid=model.openid;
    		item.Utel=model.Utel;
    		item.TXmoney=model.TXmoney;
    		item.bankInfo=model.bankInfo;
    		item.bankUserInfo=model.bankUserInfo;
    		item.TXstate=model.TXstate;
    		item.Addtime=model.Addtime;
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
    
    	    public static IEnumerable<VIEW_TG_TXmoney> ToListViewModel(IEnumerable<TG_TXmoney> list)
            {
                var listModel = new List<VIEW_TG_TXmoney>();
                foreach (TG_TXmoney item in list)
                {
                    listModel.Add(VIEW_TG_TXmoney.ToViewModel(item));
                }
                return listModel;
            }
    
    
    }
}

//----------------------------jiezhi------------------------------------

