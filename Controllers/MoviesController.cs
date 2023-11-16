using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieBate.Models;
using MovieBate.Services;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using MovieBate.DataAccess;

namespace MovieBate.Controllers
{
    public class MoviesController : Controller
    {
        //  private readonly MovieBateServices _movieServices;
        private readonly IConfiguration _configuration;
        private readonly MovieBateContext _context;

        public MoviesController(IConfiguration configuration, MovieBateContext context)
        {
            _configuration = configuration;
            _context = context;

        }
        //public async Task<IActionResult> Index()
        //{
        //    var client = new HttpClient();
        //    var request = new HttpRequestMessage(HttpMethod.Get, "http://www.omdbapi.com/?s=interstellar&apikey");
        //    var response = await client.SendAsync(request);
        //    response.EnsureSuccessStatusCode();
        //    var json = await response.Content.ReadAsStringAsync();
        //    ApiResponse myInstance = JsonConvert.DeserializeObject<ApiResponse>(json);




        //    return View(myInstance);
        //}
        public async Task<IActionResult> Index()
        {
            var apikey = _configuration["APIKey"];
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://www.omdbapi.com/?s=Fast&apikey={apikey}");
            ApiResponse myInstance = null;

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                myInstance = JsonConvert.DeserializeObject<ApiResponse>(json);
            }
            catch (HttpRequestException ex)
            {
                // Log and handle the exception
                // Consider returning an error view if the API call fails
            }
            catch (JsonException ex)
            {
                // Log and handle the JSON deserialization exception
            }

            if (myInstance == null)
            {
                // Handle the case where myInstance is still null
                // Return an appropriate view or error message
            }

            var movie = new Movie
            {
                Title = "Fast & Furious 6",
                Year = "2013",
                ImdbID = "tt1905041",
                Type = "movie",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTM3NTg2NDQzOF5BMl5BanBnXkFtZTcwNjc2NzQzOQ@@._V1_SX300.jpg"
            };
        
            
           
            await _context.SaveChangesAsync();



            return View(myInstance);
        }
        
        [Route("movies/{id}")]
        public async Task<IActionResult> Show(int id,Comment comment)
        {
            if (id == null)
            {
                return NotFound();
            }
            else if (_context.Movies.Where(e => e.Id == id).Any())
            {
                var movie = _context.Movies.Find(id);
                return View(movie);
            }
            else
            {
                return NotFound();

            }

        }
    

    }
}
