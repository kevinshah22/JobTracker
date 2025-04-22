using AutoMapper;
using JobTracker.Data.Models;
using JobTracker.Data.Repositories;
using JobTracker.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobTracker.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationModel registrationModel)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(registrationModel);

                int userId = await _userRepository.Create(user);

                if (userId > 0)
                {
                    return Ok("User created successfully");
                }
                else
                {
                    return StatusCode(500, "An error occurred while registering.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


    }
}
