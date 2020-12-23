
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
using App_Base_XF.Views.MoviePage;
using App_Base_XF.ViewModel.MovieViewModel;

namespace App_Base_XF.ViewModel.LoginViewModel
{
    public class MovieViewModel: ModelBase
    {
        MoviesService apiService;

        #region Propiedades

        public string Title_View => "Hello, what do you \nwant to watch ?";

        public string Title_1 => "RECOMMENDED FOR YOU";

        public string Title_2 => "TOP RATED";

        public string Title_3 => "UPCOMING";

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value, nameof(SearchText)); }
        }

        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value, nameof(IsVisible)); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value, nameof(IsBusy)); }
        }

        private int _heightViewTopRated;
        public int HeightViewTopRated
        {
            get { return _heightViewTopRated; }
            set { SetProperty(ref _heightViewTopRated, value, nameof(HeightViewTopRated)); }
        }

        private int _heightViewUpComming;
        public int HeightViewUpComming
        {
            get { return _heightViewUpComming; }
            set { SetProperty(ref _heightViewUpComming, value, nameof(HeightViewUpComming)); }
        }

        private int _heightViewPopular;
        public int HeightViewPopular
        {
            get { return _heightViewPopular; }
            set { SetProperty(ref _heightViewPopular, value, nameof(HeightViewPopular));}
        }

        private TopRated _selectItemTopRated;
        public TopRated SelectItemTopRated
        {
            get { return _selectItemTopRated; }
            set {

                SetProperty(ref _selectItemTopRated, value, nameof(SelectItemTopRated));
            }
        }

        private UpComing _selectItemUpComing;
        public UpComing SelectItemUpComing
        {
            get { return _selectItemUpComing; }
            set {
                SetProperty(ref _selectItemUpComing, value, nameof(SelectItemUpComing));
            }
        }

        private Popular _selectItemPopular;
        public Popular SelectItemPopular
        {
            get { return _selectItemPopular; }
            set {
                SetProperty(ref _selectItemPopular, value, nameof(SelectItemPopular));
            }
        }

        #endregion


        #region Listas

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

        public ICommand TapImageCommand =>  new Command(() =>  ClearSearchTextAsync());
        public ICommand SearchCommand => new Command(() => ActionSearchText());
        public ICommand ItemSelectedTopRatedCommand => new Command(async () => await ActionSelectItemAsync(SelectItemTopRated.id));
        public ICommand ItemSelectedUpComingCommand => new Command(async () => await ActionSelectItemAsync(SelectItemUpComing.id));
        public ICommand ItemSelectedPopularCommand => new Command(async () => await ActionSelectItemAsync(SelectItemPopular.id));

        #endregion

        #region Metodos

        async Task ActionSelectItemAsync(int id) {

            var movieDetailPage = new MovieDetailPage();
            movieDetailPage.BindingContext = new MovieDetailViewModel(id);
            await Application.Current.MainPage.Navigation.PushModalAsync(movieDetailPage);

        }

        public async Task loadListAsync() {

            MovieTopRated movieTopRated = await apiService.GetMoviesTopRatedAsync();
            List<TopRated> topRated = movieTopRated.results.OrderByDescending(x => x.vote_average).Take(10).ToList();
            topRated.ForEach(x => {

                string namePath = string.Concat(AppSettings.PosterImageUrl, x.poster_path);
                x.poster_path = namePath;
                int total = (int)x.vote_average / 2;
                x.favorite1 = 1 <= total;
                x.favorite2 = 2 <= total;
                x.favorite3 = 3 <= total;
                x.favorite4 = 4 <= total;
                x.favorite5 = 5 <= total;

            });

            HeightViewTopRated = topRated.Count > 0 ? 270 : 0;
            LtsTopRated = new ObservableCollection<TopRated>(topRated);


            MovieUpComing movieUpComing = await apiService.GetMoviesUpComingAsync();
            List<UpComing> upComing = movieUpComing.results.OrderByDescending(x => x.vote_average).Take(10).ToList();
            upComing.ForEach(x => {

                string namePath = string.Concat(AppSettings.PosterImageUrl, x.poster_path);
                x.poster_path = namePath;
                int total = (int)x.vote_average / 2;
                x.favorite1 = 1 <= total;
                x.favorite2 = 2 <= total;
                x.favorite3 = 3 <= total;
                x.favorite4 = 4 <= total;
                x.favorite5 = 5 <= total;

            });
            HeightViewUpComming = upComing.Count > 0 ? 270 : 0;
            LtsUpComming = new ObservableCollection<UpComing>(upComing);


            MoviePopular moviePopular = await apiService.GetMoviesPopularAsync();
            List<Popular> popular = moviePopular.results.OrderByDescending(x => x.vote_average).Take(10).ToList();
            popular.ForEach(x => {

                string namePath = string.Concat(AppSettings.PosterImageUrl, x.poster_path);
                x.poster_path = namePath;
                int total = (int)x.vote_average / 2;
                x.favorite1 = 1 <= total;
                x.favorite2 = 2 <= total;
                x.favorite3 = 3 <= total;
                x.favorite4 = 4 <= total;
                x.favorite5 = 5 <= total;

            });
            HeightViewPopular = popular.Count > 0 ? 270 : 0;
            LtsPopular = new ObservableCollection<Popular>(popular);

            IsBusy = false;
        }

        public async void ClearSearchTextAsync() {

            SearchText = "";
            IsBusy = true;
            await loadListAsync();

        }

        public void ActionSearchText() {

            List<TopRated> ltsTopRated = LtsTopRated.ToList().Where(x => x.title.ToUpper().Contains(SearchText.ToUpper())).ToList();
            HeightViewTopRated = ltsTopRated.Count > 0 ? 270 : 0;
            LtsTopRated = new ObservableCollection<TopRated>(ltsTopRated);

            List<UpComing> ltsUpComming = LtsUpComming.ToList().Where(x => x.title.ToUpper().Contains(SearchText.ToUpper())).ToList();
            HeightViewUpComming = ltsUpComming.Count > 0 ? 270 : 0;
            LtsUpComming = new ObservableCollection<UpComing>(ltsUpComming);

            List<Popular> ltsPopular = LtsPopular.ToList().Where(x => x.title.ToUpper().Contains(SearchText.ToUpper())).ToList();
            HeightViewPopular = ltsPopular.Count > 0 ? 270 : 0;
            LtsPopular = new ObservableCollection<Popular>(ltsPopular);

        }

        #endregion

        #region Contructor

        public MovieViewModel()
        {
            IsVisible = false;
            apiService = new MoviesService();
            SelectItemTopRated = new TopRated();
            SelectItemUpComing = new UpComing();
            SelectItemPopular = new Popular();
            HeightViewTopRated = 0;
            HeightViewUpComming = 0;
            HeightViewPopular = 0;
            IsBusy = true;
            Task.Run(() => loadListAsync());

        }

        #endregion

    }

    
}