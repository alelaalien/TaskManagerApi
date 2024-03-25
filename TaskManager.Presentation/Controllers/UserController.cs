
using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain.Interfaces;
using TaskManager.Infraestructure.Repositories;

namespace TaskManager.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _users;

        public UserController(IUserRepository repository)
        {
                _users = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var users = await _users.GetUsers();

            return Ok(users);
        }
    }
}
