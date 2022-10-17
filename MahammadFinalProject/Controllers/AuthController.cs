using BLL.Abstract;
using BLL.Contants;
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
            try
            {
                var registerResult = _authService.Register(userRegisterDto, userRegisterDto.Password);
                var result = _authService.CreateAccessToken(registerResult.Result);

                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            try
            {
                var loginResult = _authService.Login(userLoginDto);
                return Ok(Messages.SuccessfulLogin);

            }
            catch (Exception)
            {
                return BadRequest(Messages.UserNotFound);
            }

        }
    }
}