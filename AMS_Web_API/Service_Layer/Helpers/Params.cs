namespace Service_Layer.Helpers
{

    public class Param
    {
        #region Paging
        private const int maxPageSize = 50;
        private int pageSize = 10;
        private int pageNumber = 1;


        public int PageNumber { get => pageNumber; set => pageNumber = value; }
        public int PageSize { get => pageSize; set => pageSize = (value > maxPageSize) ? maxPageSize : value; }
        public string SortBy { get; set; } = "createdDate";
        public string SortDirection { get; set; } = "";//asc/desc/""
        public string SearchBy { get; set; } = "";
        public string SearchText { get; set; } = "";

        #endregion

        // public bool IsActive { get; set; } = true;

    }
}