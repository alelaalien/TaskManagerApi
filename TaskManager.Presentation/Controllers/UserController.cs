
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManager.Domain.DTOs;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infraestructure.Repositories;

namespace TaskManager.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _users;
        private IMapper _mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
                _users = repository;
                _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var users = await _users.GetUsers();
            var usersDto = _mapper.Map<List<UserDto>>(users);

            return Ok(usersDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await _users.Create(user);
            var userDto = _mapper.Map<UserDto>(user); 
            return Ok(userDto);
        }
    }
}
