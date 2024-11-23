namespace EmployeeCompetencies.Core.Models;

/// <summary>
/// Класс сотрудника.
/// </summary>
public class Person
{
    /// <summary>
    /// Уникальный идентификатор сотрудника.
    /// </summary>
    public long Id { get; set; } = Guid.NewGuid().GetHashCode();

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
    public List<Skill> Skills { get; set; } = new List<Skill>();

    public Person(string name, string displayName)
    {
        Name = name;
        DisplayName = displayName;
    }
}
