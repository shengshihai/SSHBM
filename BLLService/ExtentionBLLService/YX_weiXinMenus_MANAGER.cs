using Common;
using IBLLService;
using MODEL;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
    public partial class YX_weiXinMenus_MANAGER : BaseBLLService<YX_weiXinMenus>, IYX_weiXinMenus_MANAGER
    {

        public List<MODEL.WeChat.WeChatMenus> GetMainMenus()
        {
            return MODEL.WeChat.WeChatMenus.ToListViewModel( base.GetListBy(m => m.WX_Fid.Value == 0, m => m.flat2, false)).ToList();
        }

        public List<MODEL.WeChat.WeChatMenus> GetChildMenus()
        {
            return MODEL.WeChat.WeChatMenus.ToListViewModel(base.GetListBy(m => m.WX_Fid.Value != 0, m => m.flat2, false)).ToList();
        }

        public MODEL.DataTableModel.DataTableGrid GetWeChatMenusForGrid(MODEL.DataTableModel.DataTableRequest request)
        {
            try
            {

                var predicate = PredicateBuilder.True<YX_weiXinMenus>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");

                int total = 0;
                //predicate = predicate.And(p => p.isdelete != 1);

                var data = VIEW_YX_weiXinMenus.ToListViewModel(base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p =>true , request.SortOrder, request.SortName));
                
                //var list = ViewModelProduct.ToListViewModel(data);
                return new MODEL.DataTableModel.DataTableGrid()
                {
                    draw = request.Draw,
                    data = data,
                    total = total
                };
            }
            catch (Exception)
            {

                throw;
            }
        }


        public MODEL.DataTableModel.DataTableGrid GetWeChatMsgSetForGrid(MODEL.DataTableModel.DataTableRequest request)
        {
            try
            {

                var predicate = PredicateBuilder.True<YX_Event>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");

                int total = 0;
                //predicate = predicate.And(p => p.isdelete != 1);
              IBLLService.IYX_Event_MANAGER YX_Event_MANAGER =new BLLService.YX_Event_MANAGER();
              var data = VIEW_YX_Event.ToListViewModel(YX_Event_MANAGER.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName));

                //var list = ViewModelProduct.ToListViewModel(data);
                return new MODEL.DataTableModel.DataTableGrid()
                {
                    draw = request.Draw,
                    data = data,
                    total = total
                };
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<MODEL.WeChat.WeChatMenus> GetClickMenus()
        {
            return MODEL.WeChat.WeChatMenus.ToListViewModel(base.GetListBy(m => m.WX_MenuType== "1", m => m.flat2, false)).ToList();
        }
    }
}
