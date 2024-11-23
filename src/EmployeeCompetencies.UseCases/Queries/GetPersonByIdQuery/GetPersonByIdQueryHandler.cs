using MediatR;
using EmployeeCompetencies.Core.Models;
using EmployeeCompetencies.UseCases.Abstractions;

namespace EmployeeCompetencies.UseCases.Queries.GetPersonByIdQuery;

/// <summary>
/// Обработчик запроса на получение данных о сотруднике по идентификатору.
/// </summary>
public class GetPersonByIdQueryHandler
    : IRequestHandler<GetPersonByIdQuery, Person?>
{
    private readonly IPersonRepository _repository;

    public GetPersonByIdQueryHandler(IPersonRepository repository)
    {
        _repository = repository 
            ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<Person?> Handle(GetPersonByIdQuery request,
                                      CancellationToken cancellationToken)
    {
        return await _repository.GetById(request.Id);
    }
}
