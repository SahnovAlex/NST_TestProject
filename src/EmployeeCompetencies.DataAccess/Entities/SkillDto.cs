namespace EmployeeCompetencies.DataAccess.Entities;

/// <summary>
/// Сущность таблицы компетенций сотрудников.
/// </summary>
public class SkillDto
{
    /// <summary>
    /// Уникальный идентификатор компетенции.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Уникальный идентификатор владельца компетенции.
    /// </summary>
    public long OwnerId {  get; set; }

    /// <summary>
    /// Название компетенции.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Уровень компетенции.
    /// </summary>
    public byte Level { get; set; }
}
