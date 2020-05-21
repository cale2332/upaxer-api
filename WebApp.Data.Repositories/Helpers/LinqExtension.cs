using WebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace WebApp.Data.Repositories.Helpers
{
    public static class LinqExtension
    {
        private delegate Func<A, R> Recursive<A, R>(Recursive<A, R> r);
        private static Func<A, R> Y<A, R>(Func<Func<A, R>, Func<A, R>> f)
        {
            Recursive<A, R> rec = r => a => f(r(r))(a); return rec(rec);
        }

        public static IEnumerable<TSource> Between<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, Expression<Func<TSource, TKey>> keySelector, TKey low, TKey high) where TKey : IComparable<TKey>
        {
            Expression key = Expression.Invoke(keySelector, keySelector.Parameters.ToArray());
            Expression lowerBound = Expression.GreaterThanOrEqual(key, Expression.Constant(low));
            Expression upperBound = Expression.LessThanOrEqual(key, Expression.Constant(high));
            Expression and = Expression.AndAlso(lowerBound, upperBound);
            Expression<Func<TSource, bool>> lambda = Expression.Lambda<Func<TSource, bool>>(and, keySelector.Parameters);
            return source.Where(predicate).Where(lambda).AsEnumerable();
        }

    }
}
