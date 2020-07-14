using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalmateSourceCode.EntityModel;
using TalmateSourceCode.UserService;

namespace TalmateSourceCode.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _userService.Authenticate(model.Username, model.Password);

            if (result == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(result);
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }
        [HttpGet]

        [Route("id")]
        public async Task<IActionResult> Get(int Id)
        {
            var users = await _userService.GetById(Id);
            return Ok(users);
        }

    }
}
