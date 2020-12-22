
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

namespace App_Base_XF.ViewModel.LoginViewModel
{
    public class MovieViewModel: ModelBase
    {
        NativeHttpClient apiService;
        #region Propiedades 
        private string _isTitle_View;
        public string Title_View
        {
            get { return _isTitle_View; }
            set { SetProperty(ref _isTitle_View, value, nameof(Title_View)); }
        }

        private string _title_1;
        public string Title_1
        {
            get { return _title_1; }
            set { SetProperty(ref _title_1, value, nameof(Title_1)); }
        }

        private string _title_2;
        public string Title_2
        {
            get { return _title_2; }
            set { SetProperty(ref _title_2, value, nameof(Title_2)); }
        }

        private string _title_3;
        public string Title_3
        {
            get { return _title_3; }
            set { SetProperty(ref _title_3, value, nameof(Title_3)); }
        }

        #endregion


        #region Propiedades 
        private ObservableCollection<TopRated> _ltsTopRated;
        public ObservableCollection<TopRated> LtsTopRated
        {
            get { return _ltsTopRated; }
            set { SetProperty(ref _ltsTopRated, value, nameof(LtsTopRated)); }
        }

        private ObservableCollection<UpComing> _ltsUpComming;
        public ObservableCollection<UpComing> LtsUpComming
        {
            get { return _ltsUpComming; }
            set { SetProperty(ref _ltsUpComming, value, nameof(LtsUpComming)); }
        }

        private ObservableCollection<Popular> _ltsPopular;
        public ObservableCollection<Popular> LtsPopular
        {
            get { return _ltsPopular; }
            set { SetProperty(ref _ltsPopular, value, nameof(LtsPopular)); }
        }


        #endregion

        #region Commandos


        #endregion

        #region Metodos

        public async Task loadListAsync() {

            MovieTopRated movieTopRated = await apiService.GetMoviesTopRatedAsync();
            List<TopRated> topRated = movieTopRated.results.Take(10).ToList();
            topRated.ForEach(x => {

                string namePath = string.Concat("https://image.tmdb.org/t/p/original", x.poster_path);
                x.poster_path = namePath;

            });

             LtsTopRated = new ObservableCollection<TopRated>(topRated);


            MovieUpComing movieUpComing = await apiService.GetMoviesUpComingAsync();
            List<UpComing> upComing = movieUpComing.results.Take(10).ToList();
            upComing.ForEach(x => {

                string namePath = string.Concat("https://image.tmdb.org/t/p/original", x.poster_path);
                x.poster_path = namePath;

            });

            LtsUpComming = new ObservableCollection<UpComing>(upComing);


            MoviePopular moviePopular = await apiService.GetMoviesPopularAsync();
            List<Popular> popular = moviePopular.results.Take(10).ToList();
            popular.ForEach(x => {

                string namePath = string.Concat("https://image.tmdb.org/t/p/original", x.poster_path);
                x.poster_path = namePath;

            });

            LtsPopular = new ObservableCollection<Popular>(popular);


        }

        #endregion

        #region Contructor
        public MovieViewModel()
        {
            Title_View = "Hello, what do you \nwant to watch ?";
            Title_1 = "RECOMMENDED FOR YOU";
            Title_2 = "TOP RATED";
            Title_3 = "UPCOMING";
            //LtsTopRated = new ObservableCollection<TopRated>();

            apiService = new NativeHttpClient();

            Task.Run(() => loadListAsync());

        }

        #endregion




    }

    
}