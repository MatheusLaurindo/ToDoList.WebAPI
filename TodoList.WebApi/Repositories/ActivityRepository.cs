using Microsoft.EntityFrameworkCore;
using TodoList.WebApi.Context;
using TodoList.WebApi.Model;
using TodoList.WebApi.Repositories.Interface;

namespace TodoList.WebApi.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDbContext _context;

        public ActivityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Activity> CreateTask(Activity activity)
        {
            DateTime date = Convert.ToDateTime(activity.ExecutionDate);
            string dataConvertida = date.ToString("dd/MM/yyyy");

            activity.ExecutionDate = dataConvertida;
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
            return activity;
        }

        public async Task DeleteTask(int id)
        {
            var activity = await _context.Activities.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(activity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Activity>> GetFinishedTasks()
        {
            return await _context.Activities.Where(x => x.IsFinished).OrderByDescending(x => x.ExecutionDate).ToListAsync();
        }

        public async Task<Activity> GetTaskById(int id)
        {
            return await _context.Activities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Activity>> GetTasks()
        {
            return await _context.Activities.Where(x => x.IsFinished == false).ToListAsync();
        }

        public async Task SetFinished(int id)
        {
            var activity = await _context.Activities.FirstOrDefaultAsync(x => x.Id == id);
            activity.IsFinished = true;

            _context.Entry(activity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTask(int id, Activity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
