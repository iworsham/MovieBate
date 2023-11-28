namespace MovieBate.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AnonId { get; set; }
        public Movie Movie { get; set; }
    }
}
