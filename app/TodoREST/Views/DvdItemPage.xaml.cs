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
                searchResults.ItemsSource = await _todoService.SearchMoviesAsync(searchText.Text);
            }
        }

        private void OnSearchTextChanged(object sender, EventArgs e)
        {
            if (searchText.Text == "")
            {
                searchResults.ItemsSource = null;
            }
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MovieItem)e.SelectedItem;
            title.Text = "DVD " + item.title;
            movieTitle.Text = item.title;
            movieDirector.Text = item.director;
            searchResults.ItemsSource = null;
        }
    }
}
