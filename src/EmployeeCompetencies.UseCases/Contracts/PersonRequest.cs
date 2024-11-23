namespace EmployeeCompetencies.UseCases.Contracts;

/// <summary>
/// Модель данных сотрудника.
/// </summary>
/// <param name="Name"> Имя сотрудника. </param>
/// <param name="DisplayedName"> Отображаемое 
/// имя сотрудника. </param>
/// <param name="Skills"> Список компетенций
/// сотрудника. </param>
public record PersonRequest(
    string Name,
    string DisplayedName,
    List<SkillRequest> Skills
    );
