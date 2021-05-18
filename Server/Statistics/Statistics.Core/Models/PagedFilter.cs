namespace Statistics.Core.Queries
{
    public record PagedFilter
    {
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public string SortBy { get; set; } = "Id";
        public bool IsAscending { get; set; }
        public string SearchByText { get; set; }
    }
}