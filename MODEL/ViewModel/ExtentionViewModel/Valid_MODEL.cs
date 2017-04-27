using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class VIEW_YX_weiXinMenus
    {
        [Required]
        public new string WX_menuName { get; set; }

    }
    public partial class VIEW_YX_MenusNews
    {
        public int ID { get; set; }
        [Required]
        public string Event_ID { get; set; }
        [Required]
        public string Event_Type { get; set; }
        [Required]
        public string EventCate { get; set; }
        [Required]
        public string NewsTitle { get; set; }
        [Required]
        public string NewsDescription { get; set; }
        [Required]
        public string NewsPicUrl { get; set; }
        [Required]
        public string NewsUrl { get; set; }
    }
    public partial class VIEW_YX_MenusMsg
    {
        [Required]
        public int MID { get; set; }
        [Required]
        public string Menu_ID { get; set; }
        [Required]
        public int Event_ID { get; set; }
        [Required]
        public string Event_Type { get; set; }
        [Required]
        public string EventCate { get; set; }
        [Required]
        public string MsgContent { get; set; }
        [Required]
        public string NewsTitle { get; set; }
        [Required]
        public string NewsDescription { get; set; }
        [Required]
        public string NewsPicUrl { get; set; }
        [Required]
        public string NewsUrl { get; set; }

        public static VIEW_YX_MenusMsg ToViewModel(VIEW_YX_news model)
        {
            VIEW_YX_MenusMsg item = new VIEW_YX_MenusMsg();
            item.MID = model.Id;
            item.Event_ID = model.EventId;
            item.Event_Type = "2";
            item.EventCate = model.EventCate;
            item.MsgContent = model.newsTitle;
            item.NewsTitle = model.newsTitle;
            item.NewsDescription = model.newsDescription;
            item.NewsPicUrl = model.newsPicUrl;
            item.NewsUrl = model.newsUrl;
            return item;
        }
        public static VIEW_YX_MenusMsg ToViewModel(VIEW_YX_text model)
        {
            VIEW_YX_MenusMsg item = new VIEW_YX_MenusMsg();
            item.MID = model.Id;
            item.Event_ID = model.EventId;
            item.Event_Type = "1";
            item.EventCate = model.EventCate;
            item.MsgContent = model.msgContent;
            return item;
        }
    }
}
