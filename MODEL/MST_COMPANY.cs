//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MST_COMPANY
    {
        public MST_COMPANY()
        {
            this.MST_POSITION_LIST = new HashSet<MST_POSITION>();
        }
    
        public string COMPANY_CD { get; set; }
        public string COMPANY_NAME { get; set; }
        public string COMPANY_EMAIL { get; set; }
        public string PHONE { get; set; }
        public string TELEPHONE { get; set; }
        public string COMPANY_SUBNAME { get; set; }
        public string LOGO { get; set; }
        public string WEBSITE { get; set; }
        public string ADDRESS { get; set; }
        public string INDUSTRY { get; set; }
        public string COMPANY_SIZE { get; set; }
        public string DEVELOPMENT { get; set; }
        public string INVESTMENT { get; set; }
        public string REMARK { get; set; }
        public string DESCRIPTION { get; set; }
        public string ISCHECK { get; set; }
        public string BANNER_IMG { get; set; }
        public string COMPANY_URL { get; set; }
        public string FOOTER { get; set; }
        public string COMPANY_DESC { get; set; }
        public Nullable<int> VERSION { get; set; }
        public string SYNCOPERATION { get; set; }
        public Nullable<System.DateTime> SYNCVERSION { get; set; }
        public string SYNCFLAG { get; set; }
    
        public virtual ICollection<MST_POSITION> MST_POSITION_LIST { get; set; }
    }
}
