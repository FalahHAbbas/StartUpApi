﻿using Microsoft.EntityFrameworkCore;
using StartUpApi.Data.Repositories;
using StartUpApi.Models.Dto;
using StartUpApi.Models.Entities;
using StartUpApi.Models.Form;

namespace StartUpApi.Services;

public interface IDepartementService
{
    //TODO: Create Department Form And Dto then use them here
    Task<Departement> Create(UserForm userForm);
    Task<Departement> Update(Guid id);
    Task<Departement> Delete(Guid id);
    Task<Departement> GetById(Guid id);
    Task<List<Departement>> GetAll();
}

public class DepartementService(IUserRepository userRepository) : IDepartementService
{
}