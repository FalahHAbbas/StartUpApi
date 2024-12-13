using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Entities;
using StartUpApi.Models.Form;

namespace StartUpApi.Data.Repositories;

public interface IDepartementRepository
{
    Task<Departement> Create(Departement departement);
    Task<Departement> Update(Departement departement);
    Task<Departement> Delete(Guid id);
    Task<Departement> FindById(Guid id);
    Task<List<Departement>> GetAll();
}

public class DepartementRepository(StartupContext context) : IDepartementRepository
{
    private readonly StartupContext _context = context;

    public async Task<Departement> Create(Departement departement)
    {
        await _context.Departements.AddAsync(departement);
        await _context.SaveChangesAsync();
        return departement;
    }

    public async Task<Departement> Update(Departement departement)
    {
        _context.Departements.Update(departement);
        await _context.SaveChangesAsync();
        return departement;
    }

    public async Task<Departement> Delete(Guid id)
    {
        var departement = await _context.Departements.FindAsync(id);
        if (departement == null)
            throw new Exception("Departement not found");
        _context.Departements.Remove(departement);
        await _context.SaveChangesAsync();  
        return departement;
        
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