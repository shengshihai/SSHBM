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
    
    public partial class MST_CATALOG
    {
        public MST_CATALOG()
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
}
