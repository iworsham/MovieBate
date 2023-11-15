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
        private readonly IConfiguration _configuration;

        public MoviesController(IConfiguration configuration)
        {
            _configuration = configuration;

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

            return View(myInstance);
        }
    }
}
