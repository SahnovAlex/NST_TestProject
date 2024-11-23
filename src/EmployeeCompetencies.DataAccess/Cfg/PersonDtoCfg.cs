using EmployeeCompetencies.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeCompetencies.DataAccess.Cfg;

/// <summary>
/// Конфигурация таблицы сотрудников.
/// </summary>
public class PersonDtoCfg : IEntityTypeConfiguration<PersonDto>
{
    public void Configure(EntityTypeBuilder<PersonDto> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany<SkillDto>()
            .WithOne()
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.DisplayName)
            .IsRequired();
    }
}
