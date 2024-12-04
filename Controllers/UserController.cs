using Microsoft.AspNetCore.Mvc;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Entities;
using StartUpApi.Models.Form;
using StartUpApi.Services;
using System.Reflection.Metadata.Ecma335;

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

    [HttpPut("{id}")]

    public async Task<ActionResult<UserDto>> Update(Guid id, [FromBody] UserForm userForm)
    {
        var user = await userService.Update(id, userForm);
        return Ok(user);
    }
    [HttpDelete]
    public async Task<ActionResult<UserDto>> Delete(Guid id)
    {
        var user = await userService.Delete(id);
        return Ok(user);
    }
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll()
    {
        var user = await userService.GetAll();
        return Ok(user);

    }
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(Guid id)
    {
        var user = await userService.GetById(id);
        return Ok(user);
    }


}   