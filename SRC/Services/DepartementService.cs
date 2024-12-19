using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using StartUpApi.Data.Repositories;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Entities;
using StartUpApi.Models.Form;

namespace StartUpApi.Services;

public interface IDepartementService
{
    //TODO: Create Department Form And Dto then use them here
    Task<DepartementDto> Create(DepartementForm departementForm);
    Task<DepartementDto> Update(Guid id, DepartementForm departementForm);
    Task<DepartementDto> Delete(Guid id);
    Task<DepartementDto> GetById(Guid id);
    Task<(List<DepartementDto> data, int totalDepartements)> GetAll(int pageNumber, int pageSize);
    Task<(List<UserDto> data, int totalCount)> GetUsers(Guid id, int pageNumber, int pageSize);
}

public class DepartementService(IDepartementRepository departementRepository, IMapper mapper) : IDepartementService
{
    public async Task<DepartementDto> Create(DepartementForm departementForm)
    {
        var departement = mapper.Map<Departement>(departementForm);
        departement = await departementRepository.Create(departement);
        return mapper.Map<DepartementDto>(departement);
    }

    public async Task<DepartementDto> Update(Guid id, DepartementForm departementForm)
    {
        var department = mapper.Map<Departement>(await GetById(id));
        department = await departementRepository.Update(department);
        return mapper.Map<DepartementDto>(department);
    }


    public async Task<DepartementDto> Delete(Guid id)
    {
        var departement = mapper.Map<Departement>(await GetById(id));
        departement = await departementRepository.Delete(id);
        return mapper.Map<DepartementDto>(departement);
    }


    public async Task<(List<DepartementDto>data, int totalCount)> FindAll(int pageNumber, int pageSize)
    {
        var result = await departementRepository.GetAll(pageNumber, pageSize);
        var departementDtos = mapper.Map<List<DepartementDto>>(result.data);
        return (departementDtos, result.totalDepartements);
    }

    public async Task<DepartementDto> GetById(Guid id)
    {
        var departement = await departementRepository.FindById(id);
        return mapper.Map<DepartementDto>(departement);
    }

    public async Task<(List<DepartementDto> data, int totalDepartements)> GetAll(int pageNumber, int pageSize)
    {
        var result = await departementRepository.GetAll(pageNumber, pageSize);
        var userdepartements = mapper.Map<List<DepartementDto>>(result.data);
        return (userdepartements, result.totalDepartements);
    }

    public async Task<(List<UserDto> data, int totalCount)> GetUsers(Guid id, int pageNumber, int pageSize)
    {
        var result = await departementRepository.GetAllUsers(id, pageNumber, pageSize);

        var usersDtos = mapper.Map<List<UserDto>>(result.users);
        
        return (usersDtos, result.totalCount);
    }
}