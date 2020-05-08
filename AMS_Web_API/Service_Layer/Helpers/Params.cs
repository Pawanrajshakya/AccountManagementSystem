namespace Service_Layer.Helpers
{

    public abstract class Param
    {
        #region Paging
        private const int maxPageSize = 50;
        private int pageSize = 10;
        private int pageNumber = 1;
        public int PageNumber { get => pageNumber; set => pageNumber = value; }
        public int PageSize { get => pageSize; set => pageSize = (value > maxPageSize) ? maxPageSize : value; }
        #endregion
        
        public bool IsActive { get; set; } = true;

    }

    public class UserParam : Param
    {
        #region Filter
        public string UserName { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        #endregion
    }

    public class RoleParam: Param
    {
        public string Description { get; set; }
    }
}