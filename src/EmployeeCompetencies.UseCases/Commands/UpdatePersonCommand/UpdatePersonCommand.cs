using MediatR;
using EmployeeCompetencies.UseCases.Contracts;

namespace EmployeeCompetencies.UseCases.Commands.UpdatePersonCommand;

/// <summary>
/// Команда редактирования данных сотрудника.
/// </summary>
public class UpdatePersonCommand : IRequest<long?>
{
    /// <summary>
    /// Уникальный идентификатор сотрудника.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Модель данных запроса.
    /// </summary>
    public PersonRequest Model { get; }

    public UpdatePersonCommand(long id, PersonRequest model)
    {
        Id = id;
        Model = model;
    }
}
