using Microsoft.EntityFrameworkCore;
using EmployeeCompetencies.DataAccess.Entities;

namespace EmployeeCompetencies.DataAccess;

/// <summary>
/// Контекст базы данных.
/// </summary>
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) :base(options) 
    {
        
    }

    public DbSet<PersonDto> Persons { get; set; }

    public DbSet<SkillDto> Skills { get; set; }
}
