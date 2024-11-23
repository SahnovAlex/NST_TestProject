using MediatR;
using EmployeeCompetencies.Core.Models;

namespace EmployeeCompetencies.UseCases.Queries.GetPersonsQuery;

/// <summary>
/// Запрос на получение списка 
/// сотрудников, существующих в системе.
/// </summary>
public record GetPersonsQuery() 
    : IRequest<IEnumerable<Person>>;
