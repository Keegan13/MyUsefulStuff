using System.Linq.Expressions;


namespace System.Linq
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<TEntity> OrderByDescending<TEntity>(this IQueryable<TEntity> source, string orderByProperty)
        {
            var property = typeof(TEntity).GetProperty(orderByProperty);
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), "OrderByDescending", new Type[] { typeof(TEntity), property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));
            return (IOrderedQueryable<TEntity>)source.Provider.CreateQuery<TEntity>(resultExpression);
        }

        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty)
        {
            var property = typeof(TEntity).GetProperty(orderByProperty);
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { typeof(TEntity), property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));
            return (IOrderedQueryable<TEntity>)source.Provider.CreateQuery<TEntity>(resultExpression);
        }
    }
}