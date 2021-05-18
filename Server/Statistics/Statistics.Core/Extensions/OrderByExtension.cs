using System;
using System.Linq;
using System.Linq.Expressions;

namespace Statistics.Core.Extensions
{
    public static class OrderByExtension
    {
        public static IOrderedQueryable<TResult> SortByOrder<TType, TResult>(this IQueryable<TResult> @this, Expression<Func<TResult, TType>> selector, bool isAscending) where TResult : class
        {
            return isAscending ? @this.OrderBy(selector) : @this.OrderByDescending(selector);
        }
    }
}
