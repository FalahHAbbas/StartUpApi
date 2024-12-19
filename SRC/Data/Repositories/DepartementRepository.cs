using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
    Task<(List<Departement> data, int totalDepartements)> GetAll(int pageSize, int pageNumber);
    Task<(List<User> users, int totalCount)> GetAllUsers(Guid id,int  pageNumber, int pageSize);
    
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

    public async Task<Departement> FindById(Guid id)
    {
        var department = await _context.Departements.FindAsync(id);
        return department;
    }
    

    public async Task<(List<Departement> data , int totalDepartements)> GetAll(int pageNumber, int pageSize)
    {
        var departments = await _context.Departements
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var totalDepartements = await _context.Departements.CountAsync();
    
        return (departments, totalDepartements);
    }

    
    public async Task<(List<User> users, int totalCount)> GetAllUsers(Guid id, int  pageNumber, int pageSize)
    {
        var users= await _context.Users
            .Where(u => u.DepartementId == id)
            .Include(user => user.Departement)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var totalUsers = await _context.Users
            .Where(u => u.DepartementId == id)
            .CountAsync();
        
        return (users, totalUsers);

    }
}