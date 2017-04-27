using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MODEL.ViewPage
{
    /// <summary>
    /// 按钮图标 模型
    /// </summary>
    public class ResumeInfo
    {
        public VIEW_MST_RESUME Main;
        public ResumeBaseInfo ResumeBase;
    }
    public class ReNameResume
    {
             [Required]
        public string RESUME_CD { get; set; }
             [Required]
        public string RESUME_NAME { get; set; }
             public  int VERSION { get; set; }
    }
    public class ResumeBaseInfo
    {
        public string RESUME_CD { get; set; }
        public string RESUME_NAME { get; set; }
        [Required]
        public string EMAIL { get; set; }
        [Required]
        public string NAME { get; set; }
        public string SEX { get; set; }
        [Required]
        public string EDUCATION { get; set; }
        //   [Required]
        public string EXPERIENCE { get; set; }
        [Required]
        public string PHONE { get; set; }
        public string PORTRAIT { get; set; }

        public string CURRENT_STATE { get; set; }
        public  string STATUS { get; set; }
        public  int VERSION { get; set; }
        public  string SYNCOPERATION { get; set; }
        public  System.DateTime SYNCVERSION { get; set; }
    }
    public class ResumeZWPJ
    {
        public int ResumeZWPJID { get; set; }
        [Required]
        public string RESUME_CD { get; set; }
        [Required]
        public string selfDesc { get; set; }
    }
    public class ResumeWork
    {
        public int ResumeWorkID { get; set; }
        [Required]
        public string RESUME_CD { get; set; }
       // [Required]
        public  string workLink { get; set; }
        [Required]
        public  string workDesc { get; set; }
    }
}
