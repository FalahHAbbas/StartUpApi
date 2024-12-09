using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Entities;
using StartUpApi.Models.Form;

namespace StartUpApi.Data.Repositories;

public interface DepartementRepository
{
    Task<Departement> Create(User user);
    Task<Departement> Update(User user);
    Task<Departement> Delete(Guid id);
    Task<Departement> FindById(Guid id);
    Task<List<Departement>> GetAll();
    Task<List<Departement>> GetAllByUserId(Guid userId);
    
    
}

public class DepartementRepository(StartupContext context) : DepartementRepository
{
    private readonly StartupContext _context ;

    public async Task<Departement> Create(Departement entity)
    {
        await _context.Departement.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
