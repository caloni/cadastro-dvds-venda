namespace TodoREST.Models
{
    public class MovieItem
    {
        public string title { get; set; }
        public string director { get; set; }
        public int year { get; set; }

        public override string ToString() { return $"{title} ({year})"; }
    }
}
