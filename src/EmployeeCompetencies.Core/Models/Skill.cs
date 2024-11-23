namespace EmployeeCompetencies.Core.Models;

/// <summary>
/// Класс компетенции сотрудника.
/// </summary>
public class Skill
{
    /// <summary>
    /// Уникальный идентификатор компетенции.
    /// </summary>
    public long Id { get; set; } = Guid.NewGuid().GetHashCode();

    /// <summary>
    /// Название компетенции.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Уровень компетенции.
    /// Может принимать значения от 1 до 10.
    /// </summary>
    public byte Level { get; set; }

    public Skill(string name, byte level)
    {
        Name = name;
        Level = level;
    }
}
