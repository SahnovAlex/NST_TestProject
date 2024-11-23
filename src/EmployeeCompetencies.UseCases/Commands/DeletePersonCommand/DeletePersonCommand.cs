using MediatR;

namespace EmployeeCompetencies.UseCases.Commands.DeletePersonCommand;

/// <summary>
/// Команда удаления сотрудника из системы.
/// </summary>
public class DeletePersonCommand : IRequest
{
    /// <summary>
    /// Уникальный идентификатор сотрудника.
    /// </summary>
    public long Id { get; }

    public DeletePersonCommand(long id)
    {
        Id = id;
    }
}