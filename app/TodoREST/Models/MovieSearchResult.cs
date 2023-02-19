namespace TodoREST.Models
{
    public class MovieSearchResult
    {
        public string id { get; set; }
        public string title { get; set; }
        public string longTitle { get; set; }
        public string coverUrl { get; set; }
        public string director { get; set; }
        public int year { get; set; }
        public override string ToString() { return longTitle != null ? longTitle : title; }
    }
}
