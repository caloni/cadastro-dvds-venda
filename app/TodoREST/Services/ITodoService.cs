using TodoREST;

namespace TodoREST.Services
{
    public interface ITodoService
    {
        Task<List<Models.DvdItem>> GetTasksAsync();
        Task SaveTaskAsync(Models.DvdItem item, bool isNewItem);
        Task DeleteTaskAsync(Models.DvdItem item);
        Task<List<Models.MovieSearchResult>> SearchMoviesAsync(Models.MovieSearch search);
        Task<Models.ImageUploadResult> SaveImageToCloud(Stream image);
    }
}
