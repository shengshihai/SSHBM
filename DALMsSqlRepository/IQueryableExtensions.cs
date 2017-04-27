//-----------------------------------------------------------------------
// <copyright file="IQueryableExtensions.cs">
// </copyright>
// <author>Zou Jian</author>
// <addtime>2010-09-03</addtime>
//-----------------------------------------------------------------------

namespace DALMsSqlRepository
{
    using Common.EfSearchModel.Model;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// 对IQueryable的扩展方法
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// zoujian add , 使IQueryable支持QueryModel
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="table">IQueryable的查询对象</param>
        /// <param name="model">QueryModel对象</param>
        /// <param name="prefix">使用前缀区分查询条件</param>
        /// <returns></returns>
        public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> table, QueryModel model, string prefix = "") where TEntity : class
        {
            Contract.Requires(table != null);
            if (model == null) return table;
            return Where<TEntity>(table, model.Items, prefix);
        }

        private static IQueryable<TEntity> Where<TEntity>(IQueryable<TEntity> table, IEnumerable<ConditionItem> items, string prefix = "")
        {
            Contract.Requires(table != null);
            IEnumerable<ConditionItem> filterItems =
                string.IsNullOrWhiteSpace(prefix)
                    ? items.Where(c => string.IsNullOrEmpty(c.Prefix))
                    : items.Where(c => c.Prefix == prefix);
            if (filterItems.Count() == 0) return table;
            return new QueryableSearcher<TEntity>(table, filterItems).Search();
        }
      
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderfield,
  bool asc) where TEntity : class
        {
            Contract.Requires(source != null);
            if (string.IsNullOrEmpty(orderfield)) return source;
            string orderByProperty = orderfield;
            string command = asc ? "OrderBy" : "OrderByDescending";
            var props = orderByProperty.Split('.');
            var type = typeof(TEntity);
            var typeOfProp = typeof(TEntity);
            var parameter = Expression.Parameter(type, "p");
            Expression propertyAccess = parameter;
            var property = type.GetProperty(orderByProperty);
            int i = 0;
            do
            {
                var propertys = typeOfProp.GetProperty(props[i]);
                if (propertys == null) return null;
                typeOfProp = propertys.PropertyType;
                propertyAccess = Expression.MakeMemberAccess(propertyAccess, propertys);
                i++;
            } while (i < props.Length);

            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, typeOfProp }, source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
            
        }
    }
}
