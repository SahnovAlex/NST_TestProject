namespace EmployeeCompetencies.UseCases.Contracts;

/// <summary>
/// Модель данных компетенции сотрудника.
/// </summary>
/// <param name="Name"> Наименование компетенции.
/// </param>
/// <param name="Level"> Уровень компетенции. 
/// </param>
public record SkillRequest(
    string Name,
    byte Level);
