using Microsoft.AspNetCore.Mvc;
using TodoList.WebApi.Model;
using TodoList.WebApi.Repositories.Interface;

namespace TodoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Activity>> GetActivities()
        {
            return await _activityRepository.GetTasks();
        }

        [HttpGet("Finished")]
        public async Task<IEnumerable<Activity>> GetFinishedActivities()
        {
            return await _activityRepository.GetFinishedTasks();
        }

        [HttpPost]
        public async Task<ActionResult<Activity>> PostActivity([FromBody] Activity activity)
        {
            var newTask = await _activityRepository.CreateTask(activity);
            if (newTask == null)
                return BadRequest();

            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult<Activity>> PutActivity(int id, [FromBody] Activity activity)
        {
            if (activity == null)
                return BadRequest();

            await _activityRepository.UpdateTask(id, activity);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<Activity>> DeleteActivity(int id)
        {
            var activity = await _activityRepository.GetTaskById(id);
            if (activity == null)
            {
                return NotFound();
            }

            await _activityRepository.DeleteTask(activity.Id);
            return Ok();
        }

        [HttpPut("SetFinished")]
        public async Task<ActionResult<Activity>> SetActivityFinished(int id)
        {
            await _activityRepository.SetFinished(id);
            return Ok();
        }
    }
}
