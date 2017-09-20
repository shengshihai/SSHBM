using Common;
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

    public partial class MST_CAR_MANAGER : BaseBLLService<MST_CAR>, IMST_CAR_MANAGER
    {

        public MODEL.DataTableModel.DataTableGrid GetCarForGrid(MODEL.DataTableModel.DataTableRequest request)
        {
            try
            {

                var predicate = PredicateBuilder.True<MST_CAR>();

                DateTime time = TypeParser.ToDateTime("1975-1-1");

                int total = 0;
                predicate = predicate.And(p => p.SYNCOPERATION != "D");
                var list = IDBSession.ISYS_USERLOGIN_REPOSITORY.LoadListBy(su => su.LOGIN_ID == OperateContext.Current.UsrId).Select(su => su.SLSORG_CD);
                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName).Select(p => new VIEW_MST_CAR()
                {
                    CAR_CD = p.CAR_CD,
                    CAR_BRAND = p.CAR_BRAND,
                    CAR_CATEGORY = p.CAR_CATEGORY,
                    CAR_COLOR = p.CAR_COLOR,
                    CAR_NUM = p.CAR_NUM,
                    CAR_REMARK = p.CAR_REMARK,
                    UserId = list.Contains(p.YX_weiUser.TREE_NODE_ID)?p.UserId:"",
                    CAR_DATE = p.CAR_DATE,
                    USERNAME=list.Contains(p.YX_weiUser.TREE_NODE_ID)?p.YX_weiUser.userRelname:"",
                    USERTYPE=list.Contains(p.YX_weiUser.TREE_NODE_ID)?p.YX_weiUser.isfenxiao:-1,
                    USERTEL = list.Contains(p.YX_weiUser.TREE_NODE_ID) ? p.YX_weiUser.userTel : ""
                });
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

    }
}
