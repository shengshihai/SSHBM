using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.ViewModel
{
    public partial class OrderForCSV
    {
        public string orderNum { get; set; }
      
        public string UserId { get; set; }
       // public string userName { get; set; }
        public string UserTel { get; set; }
    
        public decimal startPrice { get; set; }
        public decimal endPrice { get; set; }
        public Nullable<int> Count { get; set; }
        public System.DateTime orderTime { get; set; }
        //public Nullable<int> flat2 { get; set; }

        public static OrderForCSV ToViewModel(TG_order model)
        {
            OrderForCSV item = new OrderForCSV();
            item.orderNum = model.orderNum;
            item.UserId = model.UserId;
            //item.userName = model.userName;
            item.UserTel = model.UserTel;
            item.orderTime = model.orderTime;
            item.startPrice = TypeParser.ToDecimal(model.remark1);
            item.endPrice = TypeParser.ToDecimal(model.remark2);
            item.Count = model.flat1;
           // item.flat2 = model.flat2;
            return item;
        }

        public static IEnumerable<OrderForCSV> ToListViewModel(IEnumerable<TG_order> list)
        {
            var listModel = new List<OrderForCSV>();
            foreach (TG_order item in list)
            {
                listModel.Add(OrderForCSV.ToViewModel(item));
            }
            return listModel;
        }
    }
}
