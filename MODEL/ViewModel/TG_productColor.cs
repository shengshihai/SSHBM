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
    
    public partial class VIEW_TG_productColor_P
    {
        public int Id { get; set; }
        public string color { get; set; }
    }
    public partial class VIEW_TG_productColor:VIEW_TG_productColor_P
    {
    
    
    
    	public static TG_productColor ToEntity(VIEW_TG_productColor model)
        {
           TG_productColor item = new TG_productColor();
       		item.Id=model.Id;
    		item.color=model.color;
            return item;
        }
    
    
    	public static VIEW_TG_productColor ToViewModel(TG_productColor model)
        {
           VIEW_TG_productColor item = new VIEW_TG_productColor();
       		item.Id=model.Id;
    		item.color=model.color;
            return item;
        }
    
    	    public static IEnumerable<VIEW_TG_productColor> ToListViewModel(IEnumerable<TG_productColor> list)
            {
                var listModel = new List<VIEW_TG_productColor>();
                foreach (TG_productColor item in list)
                {
                    listModel.Add(VIEW_TG_productColor.ToViewModel(item));
                }
                return listModel;
            }
    
    
    }
}

//----------------------------jiezhi------------------------------------

