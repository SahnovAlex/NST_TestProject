using MediatR;
using EmployeeCompetencies.Core.Models;
using EmployeeCompetencies.UseCases.Abstractions;

namespace EmployeeCompetencies.UseCases.Queries.GetPersonsQuery;

/// <summary>
/// Обработчик запроса получения списка сотрудников.
/// </summary>
public class GetPersonsQueryHandler 
    : IRequestHandler<GetPersonsQuery, IEnumerable<Person>>
{
    private readonly IPersonRepository _repository;

    public GetPersonsQueryHandler(IPersonRepository repository)
    {
        _repository = repository ?? 
            throw new ArgumentNullException(nameof(repository));
    }

    public async Task<IEnumerable<Person>> Handle(GetPersonsQuery request,
                                                  CancellationToken cancellationToken)
    {
        return await _repository.GetList();
    }
}
