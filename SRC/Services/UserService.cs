using StartUpApi.Data.Repositories;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Entities;
using StartUpApi.Models.Form;

namespace StartUpApi.Services;

public interface IUserService
{
    Task<UserDto> Create(UserForm userForm);
}

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<UserDto> Create(UserForm userForm)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = userForm.Username,
            Email = userForm.Email,
            PhoneNumber = userForm.PhoneNumber
        };

        user = await userRepository.Create(user);

        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };
    }
}