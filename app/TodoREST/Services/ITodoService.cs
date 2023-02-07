using TodoREST.Models;

namespace TodoREST.Services
{
    public interface ITodoService
    {
        Task<List<DvdItem>> GetTasksAsync();
        Task SaveTaskAsync(DvdItem item, bool isNewItem);
        Task DeleteTaskAsync(DvdItem item);
        Task<List<MovieItem>> SearchMoviesAsync(string search);
    }
}
