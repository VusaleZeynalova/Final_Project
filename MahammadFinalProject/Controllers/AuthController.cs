using BLL.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahammadFinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto userRegisterDto)
        {
            var registerResult = _authService.Register(userRegisterDto, userRegisterDto.Password);
            if (registerResult.Success)
            {
                return Ok(registerResult.Message);
            }
            return BadRequest(registerResult.Message);
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var loginResult = _authService.Login(userLoginDto);
            if (loginResult.Success)
            {
                return Ok(loginResult.Message);
            }
            return BadRequest(loginResult.Message);
        }
    }
}