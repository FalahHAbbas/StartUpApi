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
    Task<List<DepartementDto>> GetAll();
}

public class DepartementService(IDepartementRepository departementRepository) : IDepartementService
{
    public async Task<DepartementDto> Create(DepartementForm departementForm)
    {
        
            var departement = new Departement()
            {
                Id = Guid.NewGuid(),
                Name = departementForm.Name,
                
            };
            
            departement = await departementRepository.Create(departement);


            return new DepartementDto
            {
                Id = departement.Id,
                Name = departement.Name
            };
    }


    public Task<DepartementDto> Update(Guid id, DepartementForm departementForm)
    {
        throw new NotImplementedException();
    }

    public Task<DepartementDto> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<DepartementDto> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<DepartementDto>> GetAll()
    {
        throw new NotImplementedException();
    }
}