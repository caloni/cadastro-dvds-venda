using TodoREST;

namespace TodoREST.Services
{
    public interface IRestService
    {
        Task<List<Models.DvdItem>> RefreshDataAsync();

        Task SaveTodoItemAsync(Models.DvdItem item, bool isNewItem);

        Task DeleteTodoItemAsync(string id);

        Task<List<Models.MovieSearchResult>> SearchMoviesAsync(Models.MovieSearch search);

        Task<Models.ImageUploadResult> SaveImageToCloud(Stream image);
    }
}
