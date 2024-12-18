using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Entities;
using StartUpApi.Models.Form;

namespace StartUpApi.Data.Repositories;

public interface IUserRepository
{
    Task<User> Create(User user);
    Task<User> Update(User user);
    Task<User> Delete(Guid id);
    Task<User> FindById(Guid id);

    Task<(List<User> data, int totalCount)> GetUsers(int pageNumber, int pageSize, string name);
}

public class UserRepository(StartupContext context) : IUserRepository
{
    private readonly StartupContext _context = context;

    public async Task<User> Create(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Delete(Guid id)

    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            throw new Exception("user not found");
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> FindById(Guid id)

    {
        return await _context.Users
            .Include(user => user.Departement)
            .FirstOrDefaultAsync(user => user.Id == id);

    }

    public async Task<(List<User> data, int totalCount)> GetUsers(int pageNumber, int pageSize, string? name)
    {
        var users = await _context.Users
            .Where(user => name== null || user.Username.Contains(name))
            .Include(user => user.Departement)
            .OrderByDescending(user => user.createdAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalCount = await _context.Users
            .CountAsync();
        return (users, totalCount);
    }
}