using Microsoft.AspNetCore.Mvc;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Form;
using StartUpApi.Services;

namespace StartUpApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<UserDto>> Add([FromBody] UserForm userForm)
    {
        var user = await userService.Create(userForm);
        return Ok(user);
    }
}