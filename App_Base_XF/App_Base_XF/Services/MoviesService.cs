using System;
using System.Net.Http;
using System.Threading.Tasks;
using App_Base_XF.Model;
using Newtonsoft.Json;

namespace App_Base_XF.Services
{
    public class MoviesService : HttpClient
    {

        private HttpClient _Client = new HttpClient();

        public MoviesService() { }

        public async Task<MovieTopRated> GetMoviesTopRatedAsync()
        {

            string uri = $"{AppSettings.ApiUrl}{AppSettings.top_rated}?api_key={AppSettings.ApiKey}";
            var content = await _Client.GetStringAsync(uri);
            var movies = JsonConvert.DeserializeObject<MovieTopRated>(content);
            return movies;

        }

        public async Task<MovieUpComing> GetMoviesUpComingAsync()
        {
            string uri = $"{AppSettings.ApiUrl}{AppSettings.upcoming}?api_key={AppSettings.ApiKey}";
            var content = await _Client.GetStringAsync(uri);
            var movies = JsonConvert.DeserializeObject<MovieUpComing>(content);
            return movies;

        }

        public async Task<MoviePopular> GetMoviesPopularAsync()
        {
            string uri = $"{AppSettings.ApiUrl}{AppSettings.popular}?api_key={AppSettings.ApiKey}";
            var content = await _Client.GetStringAsync(uri);
            var movies = JsonConvert.DeserializeObject<MoviePopular>(content);
            return movies;

        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            string uri = $"{AppSettings.ApiUrl}{id}?api_key={AppSettings.ApiKey}";
            var content = await _Client.GetStringAsync(uri);
            var movies = JsonConvert.DeserializeObject<Movie>(content);
            return movies;

        }

        public async Task<Credit> GetCreditAsync(int id)
        {
            string uri = $"{AppSettings.ApiUrl}{id}{AppSettings.credit}?api_key={AppSettings.ApiKey}";
            var content = await _Client.GetStringAsync(uri);
            var movies = JsonConvert.DeserializeObject<Credit>(content);
            return movies;

        }
    }
}


