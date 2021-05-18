using System.Collections.Generic;

namespace Statistics.Core.Models
{
    public record PagedResult<TResult> where TResult : class
    {
        public PagedResult(int totalCount, List<TResult> result)
        {
            TotalCount = totalCount;
            Result = result;
        }

        public int TotalCount { get; set; }
        public List<TResult> Result { get; set; }
    }
}