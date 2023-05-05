using TodoREST.Data;
using TodoREST.Models;
using TodoREST.Services;

namespace TodoREST.Views
{
    public partial class TodoListPage : ContentPage
    {
        DvdItemDatabase _db;

        public TodoListPage(DvdItemDatabase db)
        {
            InitializeComponent();
            _db = db;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = _db.GetItems();
        }

        async void OnAddItemClicked(object sender, EventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(DvdItem), new DvdItem { id = Guid.NewGuid().ToString() } }
            };
            await Shell.Current.GoToAsync(nameof(DvdItemPage), navigationParameter);
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(DvdItem), e.CurrentSelection.FirstOrDefault() as DvdItem }
            };
            await Shell.Current.GoToAsync(nameof(DvdItemPage), navigationParameter);
        }
    }
}
