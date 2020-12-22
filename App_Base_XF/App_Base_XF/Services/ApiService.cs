
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using App_Base_XF.Model;
using Newtonsoft.Json;

namespace App_Base_XF.Services
{
    public class NativeHttpClient : HttpClient
    {
        private const string url_top_rated = "https://api.themoviedb.org/3/movie/top_rated?api_key=4009d1b11dedb5aee3f9b5617b8a42c2";
        private const string url_upcoming = "https://api.themoviedb.org/3/movie/upcoming?api_key=4009d1b11dedb5aee3f9b5617b8a42c2";
        private const string url_popular = "https://api.themoviedb.org/3/movie/popular?api_key=4009d1b11dedb5aee3f9b5617b8a42c2";

        private HttpClient _Client = new HttpClient();

        public NativeHttpClient() { }

        public async Task<MovieTopRated> GetMoviesTopRatedAsync() {

            var content = await _Client.GetStringAsync(url_top_rated);
            var movies =  JsonConvert.DeserializeObject<MovieTopRated>(content);
            return movies;

        }

        public async Task<MovieUpComing> GetMoviesUpComingAsync()
        {

            var content = await _Client.GetStringAsync(url_upcoming);
            var movies = JsonConvert.DeserializeObject<MovieUpComing>(content);
            return movies;

        }

        public async Task<MoviePopular> GetMoviesPopularAsync()
        {

            var content = await _Client.GetStringAsync(url_popular);
            var movies = JsonConvert.DeserializeObject<MoviePopular>(content);
            return movies;

        }
    }

}
