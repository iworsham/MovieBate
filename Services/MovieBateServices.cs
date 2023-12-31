﻿using MovieBate.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MovieBate.Services
{
    public class MovieBateServices
    {
        private static HttpClient _client;
        private readonly IConfiguration _configuration;

        public MovieBateServices(IConfiguration configuration)
        {
            _configuration = configuration;
         
        }

        public async Task<ApiResponse> GetMovies()
        {
            var apikey = _configuration["APIKey"];
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://www.omdbapi.com/?s=interstellar&apikey={apikey}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            //var url = "/";
            //var deserializedResponse = new MovieApiResponse();
            //var response = await _client.GetAsync(url);

            //if (response.IsSuccessStatusCode)
            //{

            //    var stringResponse = await response.Content.ReadAsStringAsync();
            //    deserializedResponse = JsonSerializer.Deserialize<MovieApiResponse>(stringResponse,new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            //}
            //else
            //{
            //    throw new HttpRequestException(response.ReasonPhrase);
            //}

            //return deserializedResponse;
            return new ApiResponse();
        }
    }
}
