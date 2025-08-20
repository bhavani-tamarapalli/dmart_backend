namespace Dmart_web.Core.DTOs
{
    public class SearchResultDTO
    {
        public List<ProductSearchDTO> Products { get; set; } = new();
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public string SearchQuery { get; set; }
        public string Message { get; set; }
    }
}
