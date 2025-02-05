using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using StartUpApi.Data.Repositories;
using StartUpApi.Migrations;
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
    Task<UserDto?> SetDepartment(Guid id, Guid departmentId);
    Task<UserDto?> GetAdminById(Guid id);
    
}

public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
{
    public async Task<UserDto> Create(UserForm userForm)
    {
        var user = mapper.Map<User>(userForm);
        user = await userRepository.Create(user);
        return mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> Delete(Guid id)
    {
        var user = mapper.Map<User>(await GetById(id));
        user = await userRepository.Delete(id);
        return mapper.Map<UserDto>(user);
    }

    public async Task<(List<UserDto> data, int totalCount)> GetAll(int pageNumber, int pageSize, string name)
    {
        var result = await userRepository.GetUsers(pageNumber, pageSize, name);
        var userDtos = mapper.Map<List<UserDto>>(result.data);
        return (userDtos, result.totalCount);
    }

    public async Task<UserDto?> SetDepartment(Guid id, Guid departmentId)
    {
        var user = await userRepository.FindById(id);
        user.DepartementId = departmentId;
        await userRepository.Update(user);
        return mapper.Map<UserDto>(user);
    }

    public async Task<UserDto?> GetAdminById(Guid id)
    {
        var user = await userRepository.FindById(id);
        var adminId = user.Departement!.AdminId!;
        var admin = await userRepository.FindById(adminId.Value);
        return mapper.Map<UserDto>(admin);


    }

    public async Task<UserDto> GetById(Guid id)
    {
        var user = await userRepository.FindById(id);
        return mapper.Map<UserDto>(user);
    }


    public async Task<UserDto> Update(Guid id, UserForm userForm)
    {
        var user = await userRepository.FindById(id);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        user = mapper.Map(userForm, user);
        user = await userRepository.Update(user);
        return mapper.Map<UserDto>(user);
    }
}