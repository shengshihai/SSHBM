using IBLLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace BLLService
{
    public abstract class BaseBLLService<T> : IBaseBLLService<T> where T : class ,new()
    {
        public BaseBLLService()
        { 
            SetDALRespositry();
        }

        protected IDALRepository.IBaseDALRepository<T> idal;//子类创建

        public abstract void SetDALRespositry();

        private IDALRepository.IDBSession iDbSession;

        public IDALRepository.IDBSession IDBSession
        {
            get
            {
                if (iDbSession == null)
                {
                    ////1.读取配置文件
                    //string strFactoryDLL = Common.ConfigurationHelper.AppSetting("DBSessionFatoryDLL");
                    //string strFactoryType = Common.ConfigurationHelper.AppSetting("DBSessionFatory");
                    ////2.1通过反射创建 DBSessionFactory 工厂对象
                    //Assembly dalDLL = Assembly.LoadFrom(strFactoryDLL);
                    //Type typeDBSessionFatory = dalDLL.GetType(strFactoryType);
                    IDALRepository.IDBSessionFactory sessionFactory = DI.SpringHelper.GetObject<IDALRepository.IDBSessionFactory>("DBSessionFactory");
                    //2.根据配置文件内容 使用 DI层里的Spring.Net 创建 DBSessionFactory 工厂对象
                     

                    //3.通过 工厂 创建 DBSession对象
                    iDbSession = sessionFactory.GetDBSession();
                }
                return iDbSession;
            }
        }

        public virtual int Add(T model)
        {
            int id= idal.Add(model);
            return IDBSession.SaveChanges();
        }

        public int Del(T model)
        {
             idal.Del(model);
             return IDBSession.SaveChanges();
        }
        public int DelAll(T model)
        {
            idal.DelAll(model);
            return IDBSession.SaveChanges();
        }
        public int DelBy(System.Linq.Expressions.Expression<Func<T, bool>> delWhere)
        {
             idal.DelBy(delWhere);
             return IDBSession.SaveChanges();
        }

        public virtual int ModifyAll(T model)
        {
            idal.ModifyAll(model);
            return IDBSession.SaveChanges();
        }

        public int Modify(T model, params string[] proNames)
        {
             idal.Modify(model, proNames);
             return IDBSession.SaveChanges();
        }

        public int ModifyBy(T model, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
             idal.ModifyBy(model, whereLambda, modifiedProNames);
             return IDBSession.SaveChanges();
        }

        #region 7.0 执行sql语句 +int ExcuteSql(string strSql, params object[] paras)
        /// <summary>
        /// 7.0 执行sql语句 +int ExcuteSql(string strSql, params object[] paras)
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public virtual int ExcuteSql(string strSql, params object[] paras)
        {
            return idal.ExcuteSql(strSql, paras);
        }
        #endregion
        public List<T> GetListasNoTrackingBy(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return idal.GetListasNoTrackingBy(whereLambda);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return idal.Get(whereLambda);

        }

        public T GetModelWithOutTrace(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return idal.GetModelWithOutTrace(whereLambda);
        }








        public IQueryable<T> LoadListBy<TKey>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, System.Linq.Expressions.Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "", string prefix = "")
        {
            return idal.LoadListBy(whereLambda,model,orderLambda,isAsc,orderfield,prefix);
        }

        public IQueryable<T> LoadListBy<TKey>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "")
        {
            return idal.LoadListBy(whereLambda, orderLambda, isAsc, orderfield);
        }

        public IQueryable<T> LoadListBy<TKey>(Common.EfSearchModel.Model.QueryModel model, System.Linq.Expressions.Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "", string prefix = "")
        {
            return idal.LoadListBy(model, orderLambda, isAsc, orderfield, prefix);
        }

        public IQueryable<T> LoadListBy(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, string prefix = "")
        {
            return idal.LoadListBy(whereLambda, model, prefix);
        }

        public IQueryable<T> LoadListBy(Common.EfSearchModel.Model.QueryModel model, string prefix = "")
        {
            return idal.LoadListBy( model, prefix);
        }

        public IQueryable<T> LoadListBy(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return idal.LoadListBy(whereLambda);
        }

        public List<T> GetListBy<TKey>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, System.Linq.Expressions.Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "", string prefix = "")
        {
            return idal.GetListBy(whereLambda, model, orderLambda, isAsc, orderfield, prefix);
        }

        public List<T> GetListBy<TKey>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "")
        {
            return idal.GetListBy(whereLambda, orderLambda, isAsc, orderfield);
        }

        public List<T> GetListBy<TKey>(Common.EfSearchModel.Model.QueryModel model, System.Linq.Expressions.Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "", string prefix = "")
        {
            return idal.GetListBy(model, orderLambda, isAsc, orderfield, prefix);
        }

        public List<T> GetListBy(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, string prefix = "")
        {
            return idal.GetListBy(whereLambda, model, prefix);
        }

        public List<T> GetListBy(Common.EfSearchModel.Model.QueryModel model, string prefix = "")
        {
            return idal.GetListBy( model, prefix);
        }

        public List<T> GetListBy(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return idal.GetListBy(whereLambda);
        }

        public IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, System.Linq.Expressions.Expression<Func<T, TKey>> orderBy, bool isAsc = true,string orderfield="",  string prefix = "")
        {
            return idal.LoadPagedList(pageIndex, pageSize,ref rowCount,whereLambda,model,orderBy,isAsc,orderfield,prefix);
        }




        public IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderBy, bool isAsc = true)
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, whereLambda,null,orderBy, isAsc);
        }

        public IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, string orderfield, bool isAsc = true)
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount,null, c=>true, isAsc,orderfield);
        }

        public IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Common.EfSearchModel.Model.QueryModel model, System.Linq.Expressions.Expression<Func<T, TKey>> orderBy, bool isAsc = true, string prefix = "")
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, c => true, model, orderBy, isAsc, "", prefix);
        }

        public IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Common.EfSearchModel.Model.QueryModel model, string orderfield, bool isAsc = true, string prefix = "")
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, c => true, model, c => true, isAsc, orderfield, prefix);
        }

        public List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, System.Linq.Expressions.Expression<Func<T, TKey>> orderBy, bool isAsc = true, string orderfield = "", string prefix = "")
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, whereLambda, model, orderBy, isAsc, orderfield, prefix).ToList();
        }

        public List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderBy, bool isAsc = true)
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, whereLambda,  orderBy, isAsc).ToList();
        }

        public List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, string orderfield, bool isAsc = true)
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, null, c => true, isAsc, orderfield).ToList();
        }

        public List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Common.EfSearchModel.Model.QueryModel model, System.Linq.Expressions.Expression<Func<T, TKey>> orderBy, bool isAsc = true, string prefix = "")
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, model, orderBy, isAsc, prefix).ToList();
        }

        public List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Common.EfSearchModel.Model.QueryModel model, string orderfield, bool isAsc = true, string prefix = "")
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, c => true, model, c => true, isAsc, orderfield, prefix).ToList();
        }
        public List<T> GetListBySql(string sql, params object[] parameters)
        {
            return idal.GetListBySql(sql);
        }
    }
}
