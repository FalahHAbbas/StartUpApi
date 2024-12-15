using Microsoft.AspNetCore.Mvc;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Entities;
using StartUpApi.Models.Form;
using StartUpApi.Services;
using System.Reflection.Metadata.Ecma335;

namespace StartUpApi.Controllers;

[ApiController]
[Route("api/[controller]")]


public class DepartementController(IDepartementService departementService): ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<DepartementDto>> Add([FromBody]DepartementForm departementForm)
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

    [HttpGet]
    public async Task<ActionResult<DepartementDto>> GetAll()
    {
        var departements = await departementService.GetAll();
        return Ok(departements);
    }
    
}