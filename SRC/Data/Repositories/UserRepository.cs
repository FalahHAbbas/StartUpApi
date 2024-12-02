using StartUpApi.Models.Dto;
using StartUpApi.Models.Entities;
using StartUpApi.Models.Form;

namespace StartUpApi.Data.Repositories;

public interface IUserRepository
{
    Task<User> Create(User user);
    Task<User> Update(Guid id, User user);
    Task<User> Delete(Guid id);
    Task<User> FindById(Guid id);
    Task<List<User>> FindAll();
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

    public Task<User> Update(Guid id, User userForm)
    {
        throw new NotImplementedException();
    }

    public Task<User> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> FindAll()
    {
        throw new NotImplementedException();
    }
}