namespace API.Helpers
{
    public class PaginationHeader
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public PaginationHeader(int currentPage, int pageSize, int totalCount, int totalPages)
        {
            TotalPages = totalPages;
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
        }
    }
}