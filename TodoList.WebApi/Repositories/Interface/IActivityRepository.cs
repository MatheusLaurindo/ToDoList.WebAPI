using TodoList.WebApi.Model;

namespace TodoList.WebApi.Repositories.Interface
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetTasks();
        Task<Activity> GetTaskById(int id);
        Task<Activity> CreateTask(Activity activity);
        Task UpdateTask(int id, Activity activity);
        Task DeleteTask(int id);
        Task SetFinished(int id);
        Task<IEnumerable<Activity>> GetFinishedTasks();
    }
}
