using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebApp.Common.Helpers
{
    public class UtilsHelper
    {
        public static bool IsGuid(string value)
        {
            return Guid.TryParse(value, out Guid x);
        }

        public static string GenerateReceiptNumber(DateTime date)
        {
            return $"07590152{date.ToString("yyyyMMdd")}";
        }

      
    }

    public static class ExtensionsUtilsHelper
    {
        public static int GetMonthDifference(this DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }
    }
    public static class LinqExtension
    {
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
