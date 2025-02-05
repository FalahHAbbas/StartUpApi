using Microsoft.EntityFrameworkCore;
using StartUpApi.Models.Entities;

namespace StartUpApi.Data.Repositories;

public interface IProjectRepository
{
    Task<Project> Create(Project project);
    Task<Project> Update(Project project);
    Task<Project> Delete(Guid id);
    Task<Project> GetProjectById(Guid id);
    Task<(List<Project> projects, int totalPages)> GetProjects(Guid id, int pageNumber, int pageSize);


}

public class ProjectRepository(StartupContext context) : IProjectRepository
{
    private readonly StartupContext _context = context;

    public async Task<Project> Create(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<Project> Update(Project project)
    {
        
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<Project> Delete(Guid id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null)
            throw new Exception("project not found");
        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<Project> GetProjectById(Guid id)
    {
        var project = _context.Projects.FindAsync(id);
        return await project;
    }

    public async Task<(List<Project> projects, int totalPages)> GetProjects(Guid id, int pageNumber, int pageSize)
    {
        var projects =  await _context.Projects
            .Where(p => p.Id == id)
            .Include(project => project.Departement)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var totalPages = await _context.Projects
            .Where(p => p.Id == id)
            .CountAsync();
        return (projects, totalPages);
    }
}