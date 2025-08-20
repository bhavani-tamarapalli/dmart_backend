namespace Dmart_web.Core.DTOs
{
    public class SearchSuggestionDTO
    {
        public List<string> Suggestions { get; set; } = new();
        public string Query { get; set; }
    }
}
