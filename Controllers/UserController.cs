using Desafio_Criptografia.Api.Dtos;
using Desafio_Criptografia.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Criptografia.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetById([FromRoute] long userId)
        {
            try
            {
                var result = await _userService.GetById(userId);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                var user = await _userService.Create(createUserDto);
                return Ok(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("{userId}")]
        public async Task<IActionResult> Patch([FromRoute] long userId, [FromBody] PatchUserDto patchUserDto)
        {
            try
            {
                var user = await _userService.Update(userId, patchUserDto);
                return Ok(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteById([FromRoute] long userId)
        {
            try
            {
                await _userService.Delete(userId);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}