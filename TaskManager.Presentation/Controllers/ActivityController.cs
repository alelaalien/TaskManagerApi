using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManager.Domain.CustomEntities;
using TaskManager.Domain.DTOs;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain.QueryFilters;
using TaskManager.Infraestructure.Interfaces;
using TaskManager.Presentation.Responses;

namespace TaskManager.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityService _service;
        private IMapper _mapper;
        private IUriService _uri;

        public ActivityController(IActivityService service, IMapper mapper, IUriService uri)
        {
            _service = service;
            _mapper = mapper;
            _uri = uri;
        }

        [HttpGet(Name = nameof(GetActivities))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponses<IEnumerable<ActivityDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetActivities([FromQuery]ActivityQueryFilter filter)
        {
            var activities =  _service.GetAll(filter); 
            var activitiesDto = _mapper.Map<IEnumerable<ActivityDto>>(activities);

            var metadata = new Metadata
            {
                TotalCount = activities.TotalCount,
                TotalPages = activities.TotalPages,
                CurrentPage = activities.CurrentPage,
                HasNextPage = activities.HasNextPage,
                HasPreviousPage = activities.HasPreviousPage,
                PageNumber = activities.PageNumber,
                PageSize = activities.PageSize,
               // NextPageUrl = _uri.GestActivitiesPaginationUri(filter, nameof(GetActivities)).ToString(),
                //PreviousPageUrl = _uri.GestActivitiesPaginationUri(filter, nameof(GetActivities)).ToString()

            };
            var response = new ApiResponses<IEnumerable<ActivityDto>>(activitiesDto) 
            {
                Metadata = metadata
            };
       
            return Ok(response);
        }
        /// <summary>
        /// Return a specific activity by its id
        /// </summary>
        /// <param name="id"> int id </param>
        /// <returns>Activity object</returns>
        [HttpGet("{id}")]
        //api/activity/n
        public async Task<IActionResult> GetActivity(int id)
        {
            var activity = await _service.GetById(id);
            var activityDto = _mapper.Map<ActivityDto>(activity);
            var response = new ApiResponses<ActivityDto>(activityDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateActivity(ActivityDto activityDto)
        {
            var activity = _mapper.Map<Activity>(activityDto); 
            //activity.UpdatedAt = DateTime.Now;
            await _service.Create(activity);
            var newActivityDto = _mapper.Map<ActivityDto>(activity);
            newActivityDto.Id = activity.Id;
            var response = new ApiResponses<ActivityDto>(newActivityDto);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateActivity(int id, ActivityDto activityDto)
        {
            var activity = _mapper.Map<Activity>(activityDto);
            activity.Id = id; 
            var result = await _service.Update(activity);
            var response = new ApiResponses<bool>(result);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteActivity(int id)
        { 
            var result = await _service.Delete(id);
            var response = new ApiResponses<bool>(result);
            return Ok(response);
        }
    }
}
