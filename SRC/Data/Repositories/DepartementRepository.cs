using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Entities;
using StartUpApi.Models.Form;

namespace StartUpApi.Data.Repositories;

public interface IDepartementRepository
{
    Task<Departement> Create(Departement user);
    Task<Departement> Update(Departement user);
    Task<Departement> Delete(Guid id);
    Task<Departement> FindById(Guid id);
    Task<List<Departement>> GetAll();
}

public class DepartementRepository(StartupContext context) : IDepartementRepository
{
    private readonly StartupContext _context;

    public async Task<Departement> Create(Departement entity)
    {
        await _context.Departements.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public Task<Departement> Update(Departement user)
    {
        throw new NotImplementedException();
    }

    public Task<Departement> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Departement> FindById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Departement>> GetAll()
    {
        throw new NotImplementedException();
    }
}