using Microsoft.AspNetCore.Mvc;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Form;
using StartUpApi.Services;


namespace StartUpApi.Controllers;


[ApiController]
[Route("api/[controller]")]

public class ProjectController(IProjectService projectService) : ControllerBase
{
    [HttpPost]

    public async Task<ActionResult<ProjectDto>> CreateProject([FromBody] ProjectForm projectForm)
    {
        var project = await projectService.Create(projectForm);
        return Ok(project);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectDto>> GetProject(Guid id)
    {
        var project = await projectService.GetProjectById(id);
        return Ok(project);
    }

    [HttpGet]
    public async Task<ActionResult<ProjectDto>> GetAllProjects(int pageNumber, int pageSize)
    {
        var projects = await projectService.GetAllProjects(pageNumber, pageSize);
        return Ok(projects);
    }
    
    [HttpPut("{id}")]

    public async Task<ActionResult<ProjectDto>> Update(Guid id, ProjectForm projectForm)
    {
        var project = await projectService.Update(id, projectForm);
        return Ok(project);
    }

    [HttpDelete("{id}")]

    public async Task<ActionResult<ProjectDto>> DeleteProject(Guid id)
    {
        var project = await projectService.Delete(id);
        return Ok(project);
        
        
        
    }
    
    
    
        
    
    
    
    
    
    
    
    
}