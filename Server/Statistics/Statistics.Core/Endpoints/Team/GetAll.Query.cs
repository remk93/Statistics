using Statistics.Core.Exceptions;
using Statistics.Core.Extensions;
using Statistics.Core.Queries;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Statistics.Core.Endoints.Team
{
    internal static class GetAllQuery
    {
        private enum TeamSortColumns
        {
            Id,
            Name,
            City,
            Abbreviation,
            Conference,
            Division
        }

        public static Expression<Func<DataStorage.Entities.Team, bool>> GetExpression(string searchByText)
        {
            Expression<Func<DataStorage.Entities.Team, bool>> filter = uniqueEntity => true;

            if (!string.IsNullOrEmpty(searchByText))
                searchByText.Split().ForEach(term =>
                {
                    filter = filter.And(f => f.Name.Contains(term)
                    || f.Code.Contains(term)
                    || f.City.Contains(term)
                    || f.Conference.Contains(term)
                    || f.Division.Contains(term));
                });

            return filter;
        }

        public static IOrderedQueryable<DataStorage.Entities.Team> SortExpression(this IQueryable<DataStorage.Entities.Team> @this, string sortBy, bool isAscending)
        {
            if (Enum.TryParse<TeamSortColumns>(sortBy, true, out var sortColumn))
            {
                return GetSortingExpression(@this, sortColumn, isAscending);
            }
            else
            {
                throw new BadRequestException("Invalid sort key");
            }
        }

        private static IOrderedQueryable<DataStorage.Entities.Team> GetSortingExpression(this IQueryable<DataStorage.Entities.Team> @this, TeamSortColumns sortColumn, bool isAscending) =>
            sortColumn switch
            {
                TeamSortColumns.Name => @this.SortByOrder(item => item.Name, isAscending),
                TeamSortColumns.City => @this.SortByOrder(item => item.City, isAscending),
                TeamSortColumns.Abbreviation => @this.SortByOrder(item => item.City, isAscending),
                TeamSortColumns.Conference => @this.SortByOrder(item => item.City, isAscending),
                TeamSortColumns.Division => @this.SortByOrder(item => item.City, isAscending),

                _ => @this.SortByOrder(item => item.Id, isAscending),
            };
    }
}