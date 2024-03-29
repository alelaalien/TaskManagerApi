using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain.DTOs;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ActivityController : ControllerBase
    {
        private IActivityRepository _repository;
        private IMapper _mapper;

        public ActivityController(IActivityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await _repository.GetAll();
            var activitiesDto = _mapper.Map<IEnumerable<ActivityDto>>(activities);

            return Ok(activitiesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(int id)
        {
            var activity = await _repository.GetById(id);
            var activityDto = _mapper.Map<ActivityDto>(activity);
            return Ok(activityDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateActivity(ActivityDto activityDto)
        {
            var activity = _mapper.Map<Activity>(activityDto); 
            await _repository.Create(activity);
            return Ok(activity);
        }
    }
}
