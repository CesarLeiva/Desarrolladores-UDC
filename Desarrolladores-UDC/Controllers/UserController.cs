using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DB;
using Microsoft.AspNetCore.Authorization;
using Desarrolladores_UDC.Curstom;
using Desarrolladores_UDC.DTOs;
using Microsoft.EntityFrameworkCore;
using Desarrolladores_UDC.Services;
using Desarrolladores_UDC.Validators;


namespace Desarrolladores_UDC.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]//Permite que ingresen sin estar autenticados
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Utilities _utilities;
        private readonly UserService _userService;  
        private readonly UserAddValidator _userAddValidator;
        private readonly UserLoginValidator _userLoginValidator;
        
        public UserController(Utilities utilities,
                                UserService userService,
                                UserAddValidator userAddValidator,
                                UserLoginValidator userLoginValidator)
        {
            _utilities = utilities;
            _userService = userService;
            _userAddValidator = userAddValidator;
            _userLoginValidator = userLoginValidator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Register(UserAddDto userAddDto)
        {
            var validationresult = await _userAddValidator.ValidateAsync(userAddDto);
            if (!validationresult.IsValid)
            {
                return BadRequest(validationresult.Errors);
            }
            var user = await _userService.CreateUser(userAddDto, _utilities);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var validationresult = await _userLoginValidator.ValidateAsync(userLoginDto);
            if (!validationresult.IsValid)
            {
                return BadRequest(validationresult.Errors);
            }
            var user = await _userService.Login(userLoginDto, _utilities);
            return user == null ? NotFound(new {msg = "Wrong User or Password", isSucces = false, token = ""})
                    : Ok(new {isSucces = true, token = _utilities.generateJWT(user) });
        }
    }
}
