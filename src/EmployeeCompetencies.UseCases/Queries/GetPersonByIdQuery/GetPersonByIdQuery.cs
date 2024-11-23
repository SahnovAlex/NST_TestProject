using MediatR;
using EmployeeCompetencies.Core.Models;

namespace EmployeeCompetencies.UseCases.Queries.GetPersonByIdQuery;

/// <summary>
/// Запрос на получение экземпляра 
/// сотрудника по уникальному идентификатору.
/// </summary>
/// <param name="Id"> Уникальный идентификатор 
/// сотрудника. </param>
public record GetPersonByIdQuery(long Id) 
    : IRequest<Person?>;
