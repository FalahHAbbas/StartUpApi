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


    public async Task<DepartementDto> Delete(Guid id)
    {
        var departement = await departementRepository.Delete(id);

        return new DepartementDto()
        {
            Id = departement.Id,
            Name = departement.Name,
        };
    }
    
    
    public async Task<List<DepartementDto>> FindAll()
    { 
            var departements = await departementRepository.GetAll();
            var departementDtos = new List<DepartementDto>();

            foreach (var departement in departements)
            {
                var d = new DepartementDto()
                {
                    Id = departement.Id,
                    Name = departement.Name,

                };
                departementDtos.Add(d);
            }
            return (departementDtos);

    }

    public async Task<DepartementDto> GetById(Guid id)
    {
        var user = await departementRepository.FindById(id);
        return new DepartementDto
        {
            Id = user.Id,
            Name = user.Name,
        };
    }

    public Task<List<DepartementDto>> GetAll()
    {
        throw new NotImplementedException();
    }
}