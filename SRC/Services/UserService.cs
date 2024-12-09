using Microsoft.EntityFrameworkCore;
using StartUpApi.Data.Repositories;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Entities;
using StartUpApi.Models.Form;

namespace StartUpApi.Services;

public interface IUserService
{
    Task<UserDto> Create(UserForm userForm);
    Task<UserDto> Update(Guid id, UserForm userForm);
    Task<UserDto> Delete(Guid id);
    Task<UserDto> GetById(Guid id);

    Task<(List<UserDto> data, int totalCount)> GetAll(int pageNumber, int pageSize, string name);
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
            PhoneNumber = userForm.PhoneNumber,
            Password = userForm.Password
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

    public async Task<UserDto> Delete(Guid id)
    {
        var user = await userRepository.Delete(id);

        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };
    }

    public async Task<(List<UserDto> data, int totalCount)> GetAll(int pageNumber, int pageSize, string name)
    {
        var result = await userRepository.GetUsers(pageNumber, pageSize, name);
        var userDtos = new List<UserDto>();
        foreach (var user in result.data)
        {
            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                createdAt = user.createdAt,
            };
            userDtos.Add(userDto);
        }

        return (userDtos, result.totalCount);
    }

    public async Task<UserDto> GetById(Guid id)
    {
        var user = await userRepository.FindById(id);
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            createdAt = user.createdAt,
        };
    }


    public async Task<UserDto> Update(Guid id, UserForm userForm)
    {
        var user = await userRepository.FindById(id);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        user.Username = userForm.Username;
        user.Email = userForm.Email;
        user.PhoneNumber = userForm.PhoneNumber;
        user.Password = userForm.Password;

        user = await userRepository.Update(user);
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };
    }
}