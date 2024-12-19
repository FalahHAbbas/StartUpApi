using Microsoft.AspNetCore.Mvc;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Entities;
using StartUpApi.Models.Form;
using StartUpApi.Services;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StartUpApi.Migrations;

namespace StartUpApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartementController(IDepartementService departementService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<DepartementDto>> Add([FromBody] DepartementForm departementForm)
    {
        var departement = await departementService.Create(departementForm);
        return Ok(departement);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<DepartementDto>> update(Guid id, [FromBody] DepartementForm departementForm)
    {
        var departement = await departementService.Update(id, departementForm);
        return Ok(departement);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DepartementDto>> Delete(Guid id)
    {
        var departement = await departementService.Delete(id);
        return Ok(departement);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(Guid id)
    {
        var departement = await departementService.GetById(id);
        return Ok(departement);
    }

    [HttpGet]
    public async Task<ActionResult<Page<DepartementDto>>> GetAll(int pageNumber, int pageSize)
    {
        var departements = await departementService.GetAll(pageNumber, pageSize);
        var page = new Page<DepartementDto>(departements, pageSize, pageNumber);
        return Ok(page);
    }

    [HttpGet("{id}/users")]
    public async Task<ActionResult<Page<UserDto>>> GetUsersByDepartment(Guid id,int pageNumber=1, int pageSize=10)
    {
        var users = await departementService.GetUsers(id, pageNumber, pageSize);
        var page = new Page<UserDto>(users, pageSize, pageNumber);
        return Ok(page);
    }
}