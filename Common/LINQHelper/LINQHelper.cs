 /*  作者：       盛世海
 *  创建时间：   2012/7/17 23:55:01
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data;

namespace Common
{
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
    public static class PredicateBuilder
    {

        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)  
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first  
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression   
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }
        public static Expression<Func<T, bool>> Or2<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }
    }  
   public static  class LINQHelper
    {
        /// <summary> 
        /// 分页  
        /// <summary> 
        /// <typeparam name="T">type<param> 
        /// <param name="List">实现IEnumerable<param> 
        /// <param name="FunWhere">delegate检索条件<param> 
        /// <param name="FunOrder">delegate排序<param> 
        /// <param name="PageSize">每页显示数<param> 
        /// <param name="PageIndex">当前页码<param> 
        /// <returns>returns> 
       public static IEnumerable<T> GetIenumberable<T>(IEnumerable<T> List, Func<T,
         bool> FunWhere, Func<T, string> FunOrder, int PageSize, int PageIndex)
       {
           var rance = List.Where(FunWhere).OrderByDescending(FunOrder).
           Select(t => t).Skip((PageIndex - 1) * PageSize).Take(PageSize);
           return rance;
       }
       /// <summary>
       ///      region 利用反射把DataTable的数据写到单个实体类
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="dtSource"></param>
       /// <returns></returns>
         public static T ToSingleEntity<T>(this System.Data.DataTable dtSource)
        {
            if (dtSource == null)
            {
                return default(T);
            }
 
            if (dtSource.Rows.Count != 0)
            {
                Type type = typeof(T);
                Object entity = Activator.CreateInstance(type);         //创建实例               
                foreach (PropertyInfo entityCols in type.GetProperties())
                {
                    if (!string.IsNullOrEmpty(dtSource.Rows[0][entityCols.Name].ToString()))
                    {
                        entityCols.SetValue(entity, dtSource.Rows[0][entityCols.Name], null);
                    }
                }
                return (T)entity;
            }
            return default(T);
        }
    
 
        /// <summary>
        /// 利用反射把DataTable的数据写到集合实体类里
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dtSource"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToListEntity<T>(this System.Data.DataTable dtSource)
        {
            if (dtSource == null)
            {
                return null;
            }
 
            List<T> list = new List<T>();
            Type type = typeof(T);
            foreach (DataRow dataRow in dtSource.Rows)
            {
                Object entity = Activator.CreateInstance(type);         //创建实例               
                foreach (PropertyInfo entityCols in type.GetProperties())
                {
                    if (!string.IsNullOrEmpty(dataRow[entityCols.Name].ToString()))
                    {
                        entityCols.SetValue(entity, dataRow[entityCols.Name], null);
                    }
                }
                list.Add((T)entity);
            }
            return list;
        }
       #region 删除
       /// <summary>
       /// 执行批量删除操作。直接使用 ado.net
       /// </summary>
       /// <typeparam name="TEntity"></typeparam>
       /// <param name="source"></param>
       /// <param name="predicate">条件</param>
       /// <returns></returns>
       public static int Delete<TEntity>(this ObjectQuery<TEntity> source, Expression<Func<TEntity, bool>> predicate)
                                                              where TEntity : global::System.Data.Objects.DataClasses.EntityObject
       {
           var selectSql = (source.Where(predicate) as ObjectQuery).ToTraceString();

           //
           int startIndex = selectSql.IndexOf(",");
           int endIndex = selectSql.IndexOf(".");
           string tableAlias = selectSql.Substring(startIndex + 1, endIndex - startIndex - 1);//get table alias
           startIndex = selectSql.IndexOf("FROM");
           string deleteSql = "DELETE " + tableAlias + " " + selectSql.Substring(startIndex);
           //Gets the string used to open a SQL Server database
           string connectionString = ((source as ObjectQuery).Context.Connection as EntityConnection).StoreConnection.ConnectionString;

           return ExecuteNonQuery(connectionString, deleteSql);
       }

       /// <summary>
       /// 执行T-sql 语句
       /// </summary>
       /// <param name="connectionString"></param>
       /// <param name="sql"></param>
       /// <param name="parameters"></param>
       /// <returns></returns>
       private static int ExecuteNonQuery(string connectionString, string sql, params SqlParameter[] parameters)
       {
           using (SqlConnection conn = new SqlConnection(connectionString))
           {
               SqlCommand cmd = conn.CreateCommand();
               cmd.Parameters.AddRange(parameters);
               cmd.CommandType = System.Data.CommandType.Text;
               cmd.CommandText = sql;

               if (conn.State != System.Data.ConnectionState.Open)
               {
                   conn.Open();
               }
               return cmd.ExecuteNonQuery();
           }
       } 
       #endregion
   

    }
}
