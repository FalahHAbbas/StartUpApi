using System.ComponentModel.DataAnnotations;

namespace StartUpApi.Models.Entities;


public class Departement
{
    [Key]
    public Guid Id { get; set; }
    public string DepName {get; set;}
    public string Employee  {get; set;}
    
}