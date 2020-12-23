using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App_Base_XF.Bases;
using App_Base_XF.Helpers;
using App_Base_XF.Services;
using Xamarin.Forms;
using System.Linq;
using App_Base_XF.Model;

namespace App_Base_XF.ViewModel.MovieViewModel
{
    public class MovieDetailViewModel : ModelBase
    {
        MoviesService apiService;
        public int _id;

        #region Propiedades

        private Movie _selectItemMovie;
        public Movie SelectItemMovie
        {
            get { return _selectItemMovie; }
            set { SetProperty(ref _selectItemMovie, value, nameof(SelectItemMovie)); }
        }

        #endregion


        #region Listas

        private ObservableCollection<Cast> _ltsCast;
        public ObservableCollection<Cast> LtsCast
        {
            get { return _ltsCast; }
            set { SetProperty(ref _ltsCast, value, nameof(LtsCast)); }
        }


        #endregion

        #region Commandos

        public ICommand TapBackCommand => new Command(() => Application.Current.MainPage.Navigation.PopModalAsync());

        #endregion

        #region Metodos



        public async Task loadListAsync()
        {

            Credit credit = await apiService.GetCreditAsync(_id);
            var cast = credit.cast.Take(10).ToList(); //.OrderByDescending(x => x.popularity).ToList();
            cast.ForEach(x => {
                x.profile_path = string.Concat(AppSettings.PosterImageUrl, x.profile_path);

            });
            LtsCast = new ObservableCollection<Cast>(cast);

            Movie movie = await apiService.GetMovieAsync(_id);
            string namePath = string.Concat(AppSettings.PosterImageUrl, movie.poster_path);
            movie.poster_path = namePath;
            int total = (int)movie.vote_average / 2;
            movie.favorite1 = 1 <= total;
            movie.favorite2 = 2 <= total;
            movie.favorite3 = 3 <= total;
            movie.favorite4 = 4 <= total;
            movie.favorite5 = 5 <= total;
            string genres = String.Join(", ", movie.genres.Select(x => x.name));
            movie.genre = genres;
            string studio = String.Join(", ", movie.production_companies.Select(x => x.name));
            movie.studio = studio;
            string iDate = movie.release_date;
            DateTime oDate = DateTime.Parse(iDate);
            string year = oDate.ToString("yyyy");
            movie.release_date = year;
            SelectItemMovie = movie;

        }

        #endregion

        #region Contructor

        public MovieDetailViewModel(int id)
        {
            _id = id;
            apiService = new MoviesService();
            Task.Run(() => loadListAsync());

        }

        #endregion

    }


}
