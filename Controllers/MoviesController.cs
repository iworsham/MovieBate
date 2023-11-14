using Microsoft.AspNetCore.Mvc;
using MovieBate.Models;
using MovieBate.Services;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieBate.Controllers
{
    public class MoviesController : Controller
    {
      //  private readonly MovieBateServices _movieServices;

        public MoviesController()
        {
     //       _movieServices = movieServices;
        }
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://www.omdbapi.com/?s=interstellar&apikey=7661d96a");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
             var json = await response.Content.ReadAsStringAsync();
            var myInstance = JsonConvert.DeserializeObject<MovieApiResponse>(json);


            return View();
        }
    }
}
