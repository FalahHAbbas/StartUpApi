using Microsoft.EntityFrameworkCore;
using StartUpApi.Models.Entities;

namespace StartUpApi.Data;

public class StartupContext(DbContextOptions<StartupContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Departement> Departements { get; set; }
}