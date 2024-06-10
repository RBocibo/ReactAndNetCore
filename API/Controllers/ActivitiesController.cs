using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ActivitiesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await _dataContext.Activities.ToListAsync();
            return new JsonResult(activities);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetActivity(Guid id)
        {
            var activity = await _dataContext.Activities.SingleOrDefaultAsync(x => x.Id == id);
            return new JsonResult(activity);
        }
    }
}
