using TodoREST.Models;

namespace TodoREST.Services
{
    public class TodoService : ITodoService
    {
        IRestService _restService;

        public TodoService(IRestService service)
        {
            _restService = service;
        }

        public Task<List<DvdItem>> GetTasksAsync()
        {
            return _restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(DvdItem item, bool isNewItem = false)
        {
            return _restService.SaveTodoItemAsync(item, isNewItem);
        }

        public Task DeleteTaskAsync(DvdItem item)
        {
            return _restService.DeleteTodoItemAsync(item.id);
        }
        public Task<List<MovieItem>> SearchMoviesAsync(string search)
        {
            return _restService.SearchMoviesAsync(search);
        }
    }
}
