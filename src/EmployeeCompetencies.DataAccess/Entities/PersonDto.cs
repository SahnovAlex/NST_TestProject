using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCompetencies.DataAccess.Entities;

/// <summary>
/// Сущность таблицы сотрудников.
/// </summary>
public class PersonDto
{
    /// <summary>
    /// Уникальный идентификатор.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Имя сотрудника.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Отображаемое имя сотрудника.
    /// </summary>
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Список компетенций сотрудника.
    /// </summary>
    [ForeignKey("OwnerId")]
    public List<SkillDto> Skills { get; set; } = new List<SkillDto>();
}
