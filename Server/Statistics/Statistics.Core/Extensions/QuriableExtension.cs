using System.Collections.Generic;
using System.Linq;

namespace Statistics.Core.Extensions
{
    public static class QuriableExtension
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> items, int pageNumber, int pageSize) where T : class
        {
            pageNumber = (pageNumber <= 0) ? 1 : pageNumber;

            var pagedItems = items
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return pagedItems;
        }
    }
}
