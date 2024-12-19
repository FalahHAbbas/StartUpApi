using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartUpApi.Models.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime createdAt { get; set; } = DateTime.Now.ToUniversalTime();
    
    [ForeignKey(nameof(Departement))]
    public Guid? DepartementId { get; set; }
    public Departement? Departement { get; set; }
}