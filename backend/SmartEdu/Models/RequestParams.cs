namespace SmartEdu.Models
{
    public class RequestParams
    {
        const int maxPageSize = 50;
        private int _pageSize = 50;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > maxPageSize ? maxPageSize : value;
        }
        public int PageNumber { get; set; } = 1;
    }
}
