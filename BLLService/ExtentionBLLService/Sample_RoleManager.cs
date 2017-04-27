using IBLLService;
using MODEL;
using MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLService
{
    public partial class Sample_RoleManager : BaseBLLService<Sample_Role>, ISample_RoleManager
    {


        /// <summary>
        /// 根据条件获取所有角色
        /// </summary>
        /// <param name="request">请求条件</param>
        /// <returns></returns>
        public EasyUIGrid GetAllRoles(EasyUIGridRequest request)
        {
            int total = 0;
            return new EasyUIGrid()
            {
                rows = ViewModelRole.ToListViewModel(GetAllRoles(request, ref total)),
                total = total
            };
        }

        public IEnumerable<Sample_Role> GetAllRoles(EasyUIGridRequest request, ref int Count)
        {
            return base.GetPagedList( request.PageNumber, request.PageSize,ref Count, r => true, r => r.sort, true);
           // throw new NotImplementedException();
        }

        public IEnumerable<EasyUISelect> GetRolesForSelect(EasyUISelectRequest request)
        {
            //wher语句
            //string commandText = "";
            //if (!request.Where.IsNullOrEmpty())
            //{
            //    //做Where的翻译处理工作
            //    FilterTranslator whereTranslator = new FilterTranslator();
            //    //反序列化Filter Group JSON
            //    whereTranslator.Group = JsonHelper.FromJson<FilterGroup>(request.Where);
            //    //开始翻译sql语句
            //    whereTranslator.Translate();
            //    commandText = FilterParam.AddParameters(whereTranslator.CommandText, whereTranslator.Parms);
            //}
            //return LigerUISelect.ToListModel(myDao.GetEntities(commandText));
            return EasyUISelect.ToListModel(base.GetListBy(r=>r.isDel==false).ToList());
        }

        #region 请求角色树形
        /// <summary>
        /// 请求角色树形
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IEnumerable<EasyUITree> GetRoleTree(EasyUITreeRequest request)
        {
            ////wher语句查询条件
            //string commandText = "";
            //if (!request.Where.IsNullOrEmpty())
            //{
            //    //做Where的翻译处理工作
            //    FilterTranslator whereTranslator = new FilterTranslator();
            //    //反序列化Filter Group JSON
            //    whereTranslator.Group = JsonHelper.FromJson<FilterGroup>(request.Where);
            //    //开始翻译sql语句
            //    whereTranslator.Translate();
            //    commandText = FilterParam.AddParameters(whereTranslator.CommandText, whereTranslator.Parms);
            //}

            //返回ui层的菜单
            IEnumerable<EasyUITree> rootRole = new List<EasyUITree>(){
            new EasyUITree()
            {

                icon = request.RootIcon,
                id=0,
                 desc="角色组",
                text = "角色组",
                children = (List<EasyUITree>)EasyUITree.ToListViewModel(base.GetListBy(r=>true)), 
            
            }
        };
            return rootRole;

        }
        #endregion
    }
}
