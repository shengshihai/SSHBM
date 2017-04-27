using Common;
using IBLLService;
using IDALRepository;
using MODEL;
using MODEL.ViewModel;
using SampleUI.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLLService
{

    public partial class MessageManager : BaseBLLService<message>, IMessageManager
    {
        public override int Add(message model)
        {
            var userid = model.objectid;
            var sid = OperateContext.Current.BLLSession.ISupplier_userManager.Get(su => su.suid == userid).sid;
            model.tosupplier = sid;
            if(model.toproduct==null)
            model.toproduct = 0;
            IDBSession.IMessageRepository.Add(model);
            var messagereply = ViewModelMessage.ToEntityReply(model);
            IDBSession.IMessagereplyRepository.Add(messagereply);
            IDBSession.SaveChanges();
            var item = new message();
            item=model;
            item.supplierid = sid;
            item.userid = messagereply.msgto;
            item.objectid = messagereply.msgfrom;
            item.ismain = 0;
            item.ismessage = 1;
            IDBSession.IMessageRepository.Add(item);
             IDBSession.SaveChanges();
             return messagereply.replyid;
        }






        public EasyUIGrid GetMessageGrid(DataTableRequest request)
        {
            try
            {
             var predicate = PredicateBuilder.True<message>();
             
                DateTime time = TypeParser.ToDateTime("1975-1-1");
                predicate = predicate.And(p => p.ismain == 1);
                int total = 0;
                var data = base.LoadPagedList(request.PageNumber, request.PageSize, ref total, predicate, request.Model, p => true, request.SortOrder, request.SortName).Select(m => new ViewModelMessage() { 
                id = m.id,
                title=m.title,
                messageid = m.messageid,
                messagetype = m.messagetype,
                messagedate = m.messagedate,
                supplierid = m.supplierid,
                buyername = m.supplier.suppliername,
                tosupplier = m.tosupplier,
                suppliername = m.forsupplier.suppliername,
                toproduct = m.toproduct,
                productname = m.forproduct.productname,
                userid = m.userid,
                username = m.user.fullname,
                objectid = m.objectid,
                objectname = m.object_user.fullname,
                });

                return new MODEL.ViewModel.EasyUIGrid()
                {
                    draw=request.Draw,
                    rows = data,
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
