using System.ComponentModel.DataAnnotations;

namespace StartUpApi.Models.Entities;

public class Departement
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
}