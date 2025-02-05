using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartUpApi.Models.Entities;

public class Project
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid? DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))] 
    public Departement? Departement { get; set; }
    
    public List<User> Users { get; set; }
}