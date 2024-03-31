﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain.DTOs;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Presentation.Responses;

namespace TaskManager.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ActivityController : ControllerBase
    {
        private IActivityService _service;
        private IMapper _mapper;

        public ActivityController(IActivityService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await _service.GetAll();
            var activitiesDto = _mapper.Map<IEnumerable<ActivityDto>>(activities);
             
            var response = new ApiResponses<IEnumerable<ActivityDto>>(activitiesDto);
            return Ok(response);
        }

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
