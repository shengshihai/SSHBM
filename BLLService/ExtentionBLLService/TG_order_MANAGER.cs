﻿using Common;
using IBLLService;
using IDALRepository;
using MODEL;
using MODEL.ViewModel;
using ShengUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLLService
{

    public partial class TG_order_MANAGER : BaseBLLService<TG_order>, ITG_order_MANAGER
    {

        public MODEL.DataTableModel.DataTableGrid GetOrderForGrid(MODEL.DataTableModel.DataTableRequest request)
        {
            try
            {

                var predicate = PredicateBuilder.True<TG_order>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");

                int total = 0;
               
                var list = IDBSession.ISYS_USERLOGIN_REPOSITORY.LoadListBy(su => su.LOGIN_ID == OperateContext.Current.UsrId).Select(su => su.SLSORG_CD);
                var userlist = IDBSession.IYX_weiUser_REPOSITORY.LoadListBy(wu => list.Contains(wu.TREE_NODE_ID)).Select(su => su.userNum);
                predicate = predicate.And(o => o.SYNCOPERATION != "D" && userlist.Contains(o.UserId));
                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName).ToList();//Select(p => VIEW_TG_order.ToViewModel(p));
                //var list = ViewModelProduct.ToListViewModel(data);
                return new MODEL.DataTableModel.DataTableGrid()
                {
                    draw = request.Draw,
                    data =VIEW_TG_order.ToListViewModel(data),
                    total = total
                };
            }
            catch (Exception)
            {

                throw;
            }
        }




        public bool DownOrder(VIEW_TG_order order)
        {
            throw new NotImplementedException();
        }
    }
}
