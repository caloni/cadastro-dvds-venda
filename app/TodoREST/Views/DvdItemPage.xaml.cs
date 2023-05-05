using TodoREST.Models;
using TodoREST.Services;

namespace TodoREST.Views
{
    [QueryProperty(nameof(DvdItem), "DvdItem")]
    public partial class DvdItemPage : ContentPage
    {
        ITodoService _todoService;
        DvdItem _dvdItem;
        bool _isNewItem;

        public DvdItem DvdItem
        {
            get => _dvdItem;
            set
            {
                _isNewItem = IsNewItem(value);
                _dvdItem = value;
                OnPropertyChanged();
            }
        }

        public DvdItemPage(ITodoService service)
        {
            InitializeComponent();
            _todoService = service;
            BindingContext = this;
        }

        bool IsNewItem(DvdItem todoItem)
        {
            if (string.IsNullOrWhiteSpace(todoItem.productTitle) && string.IsNullOrWhiteSpace(todoItem.movieTitle))
                return true;
            return false;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            await _todoService.SaveTaskAsync(_dvdItem, _isNewItem);
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            await _todoService.DeleteTaskAsync(_dvdItem);
            await Shell.Current.GoToAsync("..");
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        async private void OnSearchButtonClicked(object sender, EventArgs e)
        {
            if (searchText.Text != "")
            {
                var search = new MovieSearch();
                search.query = searchText.Text;
                searchResults.ItemsSource = await _todoService.SearchMoviesAsync(search);
            }
        }

        private void OnSearchTextChanged(object sender, EventArgs e)
        {
            if (searchText.Text == "")
            {
                searchResults.ItemsSource = null;
            }
        }

        async private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MovieSearchResult)e.SelectedItem;
            title.Text = "DVD " + item.title;
            searchResults.ItemsSource = null;
            movieTitle.Text = item.title;
            var search = new MovieSearch();
            search.id = item.id;
            var result = await _todoService.SearchMoviesAsync(search);
            var movie = result.FirstOrDefault();
            if( movie != null )
            {
                movieDirector.Text = movie.director;
                //TODO put the local name of the movie
            }
        }

        async void OnAddPhotoClicked(object sender, EventArgs e)
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    using Stream sourceStream = await photo.OpenReadAsync();
                    var result = await _todoService.SaveImageToCloud(sourceStream);
                    if( result != null )
                    {
                        string txt = dvdImages.Text != null ? dvdImages.Text : "";
                        string sep = txt.Length > 0 ? " " : "";
                        txt += sep + result.Data.Url;
                        dvdImages.Text = txt;
                    }
                }
            }
        }

        async void OnTakePhotoClicked(object sender, EventArgs e)
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    using Stream sourceStream = await photo.OpenReadAsync();
                    var result = await _todoService.SaveImageToCloud(sourceStream);
                    if( result != null )
                    {
                        string txt = dvdImages.Text != null ? dvdImages.Text : "";
                        string sep = txt.Length > 0 ? " " : "";
                        txt += sep + result.Data.Url;
                        dvdImages.Text = txt;
                    }
                }
            }
        }

    }
}
