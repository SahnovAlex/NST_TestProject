using MediatR;
using EmployeeCompetencies.UseCases.Contracts;

namespace EmployeeCompetencies.UseCases.Commands.AddPersonCommand;

/// <summary>
/// Команда создания сотрудника в системе.
/// </summary>
public record CreatePersonCommand : IRequest<long>
{
    /// <summary>
    /// Модель данных запроса.
    /// </summary>
    public PersonRequest Model { get; }

    public CreatePersonCommand(PersonRequest model)
    {
        Model = model;
    }
}
