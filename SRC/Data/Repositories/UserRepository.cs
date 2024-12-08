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

    Task<(List<UserDto> data, int totalCount)> GetUsersAsync(IQueryable<User> query, int pageNumber, int pageSize);
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
        return await _context.Users.FindAsync(id);
        
    }

    public async Task<(List<UserDto> data, int totalCount)> GetUsersAsync(IQueryable<User> query, int pageNumber, int pageSize)
    {
        
        // Count the total number of users
        var totalCount = await query.CountAsync();

        // If pageSize is 0, return all users without pagination
        if (pageSize == 0)
        {
            var data = await query
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    
                    // Add other necessary mappings here
                })
                .ToListAsync();

            return (data, totalCount);
        }

        var pagedData = pageNumber == 0
            ? await query
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    // Add other necessary mappings here
                })
                .ToListAsync()
            : await query
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    // Add other necessary mappings here
                })
                .ToListAsync();

        return (pagedData, totalCount);
    }
}