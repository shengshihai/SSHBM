using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DALMsSqlRepository
{
    public class BaseDALRepository<T> : IDALRepository.IBaseDALRepository<T> where T : class,new()
    {

        /// <summary>
        /// EF上下文对象 
        /// </summary>
        protected DbContext db = new DbContextFactory().GetDbContext(); 

        #region 1.0 新增 实体 +int Add(T model)
        /// <summary>
        /// 新增 实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual int Add(T model)
        {
            db.Set<T>().Add(model);

            //return db.SaveChanges();//保存成功后，会将自增的id设置给 model的 主键属性，并返回受影响行数
            return 1;
        }
        #endregion

        #region 2.0 根据 id 删除 +int Del(T model)
        /// <summary>
        /// 根据 id 删除
        /// </summary>
        /// <param name="model">包含要删除id的对象</param>
        /// <returns></returns>
        public virtual int Del(T model)
        {
            db.Set<T>().Attach(model);
            db.Set<T>().Remove(model);
            return 1;
        }
        public virtual int DelAll(T model)
        {
            //4.1将 对象 添加到 EF中
            DbEntityEntry entry = db.Entry<T>(model);
            //4.2先设置 对象的包装 状态为 Unchanged
            entry.State = System.Data.EntityState.Deleted;
            return 1;
        }
        #endregion

        #region 3.0 根据条件删除 +int DelBy(Expression<Func<T, bool>> delWhere)
        /// <summary>
        /// 3.0 根据条件删除
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public virtual int DelBy(Expression<Func<T, bool>> delWhere)
        {
            //3.1查询要删除的数据
            List<T> listDeleting = db.Set<T>().Where(delWhere).ToList();
            //3.2将要删除的数据 用删除方法添加到 EF 容器中
            listDeleting.ForEach(u =>
            {
                db.Set<T>().Attach(u);//先附加到 EF容器
                db.Set<T>().Remove(u);//标识为 删除 状态
            });
            //3.3一次性 生成sql语句到数据库执行删除
            return 1;
        }

        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public virtual int DelByList(List<T> listDeleting)
        {

            //3.2将要删除的数据 用删除方法添加到 EF 容器中
            listDeleting.ForEach(u =>
            {
                db.Set<T>().Attach(u);//先附加到 EF容器
                db.Set<T>().Remove(u);//标识为 删除 状态
            });
            //3.3一次性 生成sql语句到数据库执行删除
            return 1;
        }
        #endregion
        public virtual int ModifyAll(T model)
        {
            //4.1将 对象 添加到 EF中
            DbEntityEntry entry = db.Entry<T>(model);
            //4.2先设置 对象的包装 状态为 Unchanged
            entry.State = System.Data.EntityState.Modified;

            //4.4一次性 生成sql语句到数据库执行
            //return db.SaveChanges();
            return 1;
        }
        #region 4.0 修改 +int Modify(T model, params string[] proNames)
        /// <summary>
        /// 4.0 修改，如：
        /// T u = new T() { uId = 1, uLoginName = "asdfasdf" };
        /// this.Modify(u, "uLoginName");
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns></returns>
        public virtual int Modify(T model, params string[] proNames)
        {
            //4.1将 对象 添加到 EF中
            DbEntityEntry entry = db.Entry<T>(model);
            //4.2先设置 对象的包装 状态为 Unchanged
            entry.State = System.Data.EntityState.Unchanged;
            //4.3循环 被修改的属性名 数组
            foreach (string proName in proNames)
            {
                //4.4将每个 被修改的属性的状态 设置为已修改状态;后面生成update语句时，就只为已修改的属性 更新
                entry.Property(proName).IsModified = true;
            }
            //4.4一次性 生成sql语句到数据库执行
            //return db.SaveChanges();
            return 1;
        }
        #endregion

        #region 4.0 批量修改 +int Modify(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        /// <summary>
        /// 4.0 批量修改
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns></returns>
        public virtual int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            //4.1查询要修改的数据
            List<T> listModifing = db.Set<T>().Where(whereLambda).ToList();

            //获取 实体类 类型对象
            Type t = typeof(T); // model.GetType();
            //获取 实体类 所有的 公有属性
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            //创建 实体属性 字典集合
            Dictionary<string, PropertyInfo> dictPros = new Dictionary<string, PropertyInfo>();
            //将 实体属性 中要修改的属性名 添加到 字典集合中 键：属性名  值：属性对象
            proInfos.ForEach(p =>
            {
                if (modifiedProNames.Contains(p.Name))
                {
                    dictPros.Add(p.Name, p);
                }
            });

            //4.3循环 要修改的属性名
            foreach (string proName in modifiedProNames)
            {
                //判断 要修改的属性名是否在 实体类的属性集合中存在
                if (dictPros.ContainsKey(proName))
                {
                    //如果存在，则取出要修改的 属性对象
                    PropertyInfo proInfo = dictPros[proName];
                    //取出 要修改的值
                    object newValue = proInfo.GetValue(model, null); //object newValue = model.uName;

                    //4.4批量设置 要修改 对象的 属性
                    foreach (T usrO in listModifing)
                    {
                        //为 要修改的对象 的 要修改的属性 设置新的值
                        proInfo.SetValue(usrO, newValue, null); //usrO.uName = newValue;
                    }
                }
            }
            //4.4一次性 生成sql语句到数据库执行
            //return db.SaveChanges();
            return 1;
        }
        #endregion









        public List<T> GetListasNoTrackingBy(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().AsNoTracking().Where(whereLambda).ToList();
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
            return db.Database.ExecuteSqlCommand(strSql, paras);
        }
        #endregion

        #region 8.0 根据条件获取一个 不被ef跟踪的 对象 +T GetModelWithOutTrace(Expression<Func<T, bool>> whereLambda)
        /// <summary>
        /// 8.0 根据条件获取一个 不被ef跟踪的 对象
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public T GetModelWithOutTrace(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().AsNoTracking().Where(whereLambda).FirstOrDefault();
        }
        #endregion


        public T Get(Expression<Func<T, bool>> whereLambda)
        {

            return db.Set<T>().Where(whereLambda).FirstOrDefault();
        }










      

        public virtual IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, Expression<Func<T, TKey>> orderBy, bool isAsc = true,string orderfield="",  string prefix = "")
        {
            rowCount = db.Set<T>().Where(whereLambda).Where(model, prefix).Count();

            if (!string.IsNullOrEmpty(orderfield))
                return db.Set<T>().Where(whereLambda).Where(model, prefix).OrderBy(orderfield, isAsc).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable();
            if (isAsc)
                return db.Set<T>().Where(whereLambda).Where(model, prefix).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable();
            else
                return db.Set<T>().Where(whereLambda).Where(model, prefix).OrderBy(orderfield, isAsc).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable();
        }

        public virtual IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy, bool isAsc = true)
        {
            return LoadPagedList(pageIndex, pageSize,ref rowCount, whereLambda, null, orderBy);
        }

        public virtual IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, string orderfield, bool isAsc = true)
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, whereLambda, null, c => true, isAsc, orderfield);
        }

        public virtual IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Common.EfSearchModel.Model.QueryModel model, Expression<Func<T, TKey>> orderBy, bool isAsc = true, string prefix = "")
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, c => true, model, orderBy, isAsc,"", prefix);
        }

        public virtual IQueryable<T> LoadPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Common.EfSearchModel.Model.QueryModel model, string orderfield, bool isAsc = true, string prefix = "")
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, c => true, model, c => true, isAsc, orderfield, prefix);
        }

        public List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, Expression<Func<T, TKey>> orderBy, bool isAsc = true, string orderfield = "", string prefix = "")
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, whereLambda, model, orderBy,  isAsc, orderfield, prefix).ToList();
        }

        public virtual List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy, bool isAsc = true)
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, whereLambda,  orderBy, isAsc).ToList();
        }

        public virtual List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, string orderfield, bool isAsc = true)
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, whereLambda, null, c => true,  isAsc).ToList();
        }

        public virtual List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Common.EfSearchModel.Model.QueryModel model, Expression<Func<T, TKey>> orderBy, bool isAsc = true, string prefix = "")
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, model, orderBy, isAsc, prefix).ToList();
        }

        public virtual List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Common.EfSearchModel.Model.QueryModel model, string orderfield, bool isAsc = true, string prefix = "")
        {
            return LoadPagedList(pageIndex, pageSize, ref rowCount, c => true, model, c => true, isAsc, orderfield, prefix).ToList();
        }


        public virtual IQueryable<T> LoadListBy<TKey>(Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "", string prefix = "")
        {
  
                if (!string.IsNullOrEmpty(orderfield))
                    return db.Set<T>().Where(model, prefix).Where(whereLambda).OrderBy(orderfield, isAsc).AsQueryable();
                if (isAsc)
                    return db.Set<T>().Where(model, prefix).Where(whereLambda).OrderBy(orderLambda).AsQueryable();
                else
                    return db.Set<T>().Where(model, prefix).Where(whereLambda).OrderByDescending(orderLambda).AsQueryable();
            
         
        }




        public virtual IQueryable<T> LoadListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "")
        {
            return LoadListBy(whereLambda, null, orderLambda, isAsc, orderfield);
        }

        public virtual IQueryable<T> LoadListBy<TKey>(Common.EfSearchModel.Model.QueryModel model, Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "", string prefix = "")
        {
            return LoadListBy(c => true, model, orderLambda, isAsc, orderfield, prefix);
        }

        public virtual IQueryable<T> LoadListBy(Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, string prefix = "")
        {
            return LoadListBy(whereLambda, model, c => true, true, "", prefix);
        }

        public virtual IQueryable<T> LoadListBy(Common.EfSearchModel.Model.QueryModel model, string prefix = "")
        {
            return LoadListBy(c => true, model, prefix);
        }

        public virtual IQueryable<T> LoadListBy(Expression<Func<T, bool>> whereLambda)
        {
            return LoadListBy(whereLambda, null);
        }

        public List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "", string prefix = "")
        {
            return LoadListBy(whereLambda, model, orderLambda, isAsc, orderfield, prefix).ToList();
        }




        public List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "")
        {
            return LoadListBy(whereLambda, null, orderLambda, isAsc, orderfield).ToList();
        }

        public List<T> GetListBy<TKey>(Common.EfSearchModel.Model.QueryModel model, Expression<Func<T, TKey>> orderLambda, bool isAsc = true, string orderfield = "", string prefix = "")
        {
            return LoadListBy(c=>true, model, orderLambda, isAsc, orderfield, prefix).ToList();
        }

        public List<T> GetListBy(Expression<Func<T, bool>> whereLambda, Common.EfSearchModel.Model.QueryModel model, string prefix = "")
        {
           return LoadListBy(whereLambda, model, c => true, true, "", prefix).ToList();
        }

        public List<T> GetListBy(Common.EfSearchModel.Model.QueryModel model, string prefix = "")
        {
            return LoadListBy(c => true, model, prefix).ToList();
        }

        public List<T> GetListBy(Expression<Func<T, bool>> whereLambda)
        {
            return LoadListBy(whereLambda, null).ToList();
        }

        public List<T> GetListBySql(string sql, params object[] parameters)
        {
           return db.Database.SqlQuery<T>(sql,parameters).ToList();
        }


      
    }
}
