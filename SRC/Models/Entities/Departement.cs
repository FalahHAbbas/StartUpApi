﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StartUpApi.Models.Dto;

namespace StartUpApi.Models.Entities;

public class Departement
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public Guid DepartmentId { get; set; }
    
    

    

}