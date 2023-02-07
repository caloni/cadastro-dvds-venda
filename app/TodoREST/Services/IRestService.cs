using TodoREST.Models;

namespace TodoREST.Services
{
    public interface IRestService
    {
        Task<List<DvdItem>> RefreshDataAsync();

        Task SaveTodoItemAsync(DvdItem item, bool isNewItem);

        Task DeleteTodoItemAsync(string id);

        Task<List<MovieSearchResult>> SearchMoviesAsync(MovieSearch search);
    }
}
