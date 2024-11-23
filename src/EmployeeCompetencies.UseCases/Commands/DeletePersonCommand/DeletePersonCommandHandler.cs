using MediatR;
using EmployeeCompetencies.UseCases.Abstractions;

namespace EmployeeCompetencies.UseCases.Commands.DeletePersonCommand;

/// <summary>
/// Обработчик команды удаления сотрудника.
/// </summary>
public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IPersonRepository _repository;

    public DeletePersonCommandHandler(IPersonRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        await _repository.Delete(request.Id);
    }
}
