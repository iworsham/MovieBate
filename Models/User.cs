namespace MovieBate.Models
{
    public class User
    {
        public string Id { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
