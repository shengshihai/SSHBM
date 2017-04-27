using Common.EfSearchModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDALRepository
{
    public interface IBaseDALRepository<T> where T : class,new()
    {
        //1.定义 ef 上下文
        //MODEL.OuOAEntities db = new MODEL.OuOAEntities();
        T Get(Expression<Func<T, bool>> whereLambda);
         
        //2.定义增删改查方法

        #region 1.0 新增 实体 +int Add(T model)
        /// <summary>
        /// 新增 实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(T model);
        #endregion

        #region 2.0 根据 id 删除 +int Del(T model)
        /// <summary>
        /// 根据 id 删除
        /// </summary>
        /// <param name="model">包含要删除id的对象</param>
        /// <returns></returns>
        int Del(T model);
        int DelAll(T model);
        #endregion

        #region 3.0 根据条件删除 +int DelBy(Expression<Func<T, bool>> delWhere)
        /// <summary>
        /// 3.0 根据条件删除
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        int DelBy(Expression<Func<T, bool>> delWhere);
        int DelByList(List<T> listDeleting);
        #endregion

        int ModifyAll(T model);

        #region 4.0 修改 +int Modify(T model, params string[] proNames)
        /// <summary>
        /// 4.0 修改，如：
        /// T u = new T() { uId = 1, uLoginName = "asdfasdf" };
        /// this.Modify(u, "uLoginName");
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns></returns>
        int Modify(T model, params string[] proNames);
        #endregion

        #region 4.0 批量修改 +int Modify(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        /// <summary>
        /// 4.0 批量修改
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns></returns>
        int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames);
        #endregion

      #region 7.0 执行sql语句 +int ExcuteSql(string strSql, params object[] paras)
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        int ExcuteSql(string strSql, params object[] paras);
        #endregion


        T GetModelWithOutTrace(Expression<Func<T, bool>> whereLambda);
        List<T> GetListasNoTrackingBy(Expression<Func<T, bool>> whereLambda);


        IQueryable<T> LoadListBy<TKey>(Expression<Func<T, bool>> whereLambda, QueryModel model, Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield="", string prefix = "");

        IQueryable<T> LoadListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield="");


        IQueryable<T> LoadListBy<TKey>(QueryModel model, Expression<Func<T, TKey>> orderLambda,  bool isAsc = true, string orderfield = "", string prefix = "");

        IQueryable<T> LoadListBy(Expression<Func<T, bool>> whereLambda, QueryModel model, string prefix = "");
        
        IQueryable<T> LoadListBy(QueryModel model,  string prefix = "");

        IQueryable<T> LoadListBy(Expression<Func<T, bool>> whereLambda);


     
        List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, QueryModel model, Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "", string prefix = "");

        List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "");


        List<T> GetListBy<TKey>(QueryModel model, Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "", string prefix = "");

        List<T> GetListBy(Expression<Func<T, bool>> whereLambda, QueryModel model, string prefix = "");

        List<T> GetListBy(QueryModel model, string prefix = "");

        List<T> GetListBy(Expression<Func<T, bool>> whereLambda);




        IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, Expression<Func<T, TKey>> orderBy,  bool isAsc = true, string orderfield="",string prefix = "");

        IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy, bool isAsc = true);

        IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, string orderfield, bool isAsc = true);

        IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, QueryModel model, Expression<Func<T, TKey>> orderBy, bool isAsc = true, string prefix = "");

        IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, QueryModel model, string orderfield, bool isAsc = true, string prefix = "");


        List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, Expression<Func<T, TKey>> orderBy,  bool isAsc = true,string orderfield="", string prefix = "");

        List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy, bool isAsc = true);

        List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, string orderfield, bool isAsc = true);

        List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, QueryModel model, Expression<Func<T, TKey>> orderBy, bool isAsc = true, string prefix = "");

        List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, QueryModel model, string orderfield, bool isAsc = true, string prefix = "");

        List<T> GetListBySql(string sql, params object[] parameters);
        

      
    }
}
