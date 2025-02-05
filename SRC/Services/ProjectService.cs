using MapsterMapper;
using StartUpApi.Data.Repositories;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Entities;
using StartUpApi.Models.Form;

namespace StartUpApi.Services;

public interface IProjectService
{
    Task<ProjectDto> Create(ProjectForm projectForm);
    Task<ProjectDto> GetProjectById(Guid id);
    Task<ProjectDto> Delete(Guid id);
    Task<ProjectDto> Update(Guid id ,ProjectForm projectForm);
    Task<(List<ProjectDto> data, int totalPages)> GetAllProjects(Guid id, int pageNumber, int pageSize);


}

public class ProjectService(
    IProjectRepository projectRepository,
    IMapper mapper) : IProjectService
{
    public async Task<ProjectDto> Create(ProjectForm projectForm)
    {
        var project = mapper.Map<Project>(projectForm);
        project = await projectRepository.Create(project);
        return mapper.Map<ProjectDto>(project);
    }

    public async Task<ProjectDto> GetProjectById(Guid id)
    {
        var project = await projectRepository.GetProjectById(id);
        return mapper.Map<ProjectDto>(project);
    }
    

    public async Task<ProjectDto> Delete(Guid id)
    {
        var project = mapper.Map<Project>(await GetProjectById(id));
        project = await projectRepository.Delete(id);
        return mapper.Map<ProjectDto>(project);
    }

    public async Task<ProjectDto> Update(Guid id, ProjectForm projectForm)
    {
        var project = mapper.Map<Project>(await GetProjectById(id));
        project = await projectRepository.Update(project);
        return mapper.Map<ProjectDto>(project);
    }
    

    public async Task<(List<ProjectDto> data, int totalPages)> GetAllProjects(Guid id , int pageNumber, int pageSize)
    {
        var result = await projectRepository.GetProjects(id ,pageNumber, pageSize);
        var project = mapper.Map<List<ProjectDto>>(result.projects);
        return (project, result.totalPages);
    }
}