using MovieBate.Migrations;

namespace MovieBate.Models
{

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }
        public string Type { get; set; }
        //public string Plot { get; set; }
        public string Poster { get; set; }
        public List<Comment>? Comments { get; set; } = new List<Comment>();
    }

    public class ApiResponse
    {
        public int Id { get; set; }
        public List<Movie> Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }
        
    }
}