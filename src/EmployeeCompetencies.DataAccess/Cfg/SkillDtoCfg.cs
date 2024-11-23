using EmployeeCompetencies.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeCompetencies.DataAccess.Cfg;

/// <summary>
/// Конфигурация таблицы компетенций сотрудников.
/// </summary>
public class SkillDtoCfg : IEntityTypeConfiguration<SkillDto>
{
    public void Configure(EntityTypeBuilder<SkillDto> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.Level)
            .IsRequired();
    }
}
