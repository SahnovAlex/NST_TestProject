using MediatR;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using EmployeeCompetencies.Core.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using EmployeeCompetencies.UseCases.Contracts;
using EmployeeCompetencies.UseCases.Commands.AddPersonCommand;
using EmployeeCompetencies.UseCases.Queries.GetPersonsQuery;
using EmployeeCompetencies.UseCases.Queries.GetPersonByIdQuery;
using EmployeeCompetencies.UseCases.Commands.UpdatePersonCommand;
using EmployeeCompetencies.UseCases.Commands.DeletePersonCommand;

namespace EmployeeCompetencies.API.Controllers;

/// <summary>
/// Предоставляет Rest API для работы с сотрудниками.
/// </summary>
[ApiController]
[Route("api/v1/persons")]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Получить список сотрудников.
    /// </summary>
    /// <returns> Список сотрудников либо пустой список, 
    /// если сотрудников нет. </returns>
    /// <responce code ="200"> Успешное выполнение запроса. 
    /// </responce>>
    /// <responce code ="500"> Серверная ошибка. </responce>>
    [HttpGet]
    [ProducesResponseType(typeof(List<Person>), 200)]
    [ProducesResponseType(typeof(List<string>), 500)]
    public async Task<IActionResult> GetList()
    {
        var result = await _mediator.Send(new GetPersonsQuery());
        return Ok(result);
    }

    /// <summary>
    /// Получить сотрудника по уникальному идентификатору.
    /// </summary>
    /// <param name="id"></param>
    /// <returns> Возвращает сотрудника из базы данных. 
    /// </returns>
    /// <responce code ="200"> Успешное выполнение запроса. 
    /// </responce>>
    /// <responce code ="404"> Сущность не найдена в системе.
    /// </responce>>
    /// <responce code ="500"> Серверная ошибка. </responce>>
    [HttpGet("id")]
    [ProducesResponseType(typeof(Person), 200)]
    [ProducesResponseType(typeof(List<string>), 404)]
    [ProducesResponseType(typeof(List<string>), 500)]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _mediator.Send(new GetPersonByIdQuery(id));

        if (result == null)
            return NotFound("Сущность не найдена");

        return Ok(result);
    }

    /// <summary>
    /// Создать нового пользователя и добавить в базу данных.
    /// </summary>
    /// <param name="model"> Модель данных пользователя. 
    /// </param>
    /// <param name="validator"> Валидатор данных пользователя. 
    /// </param>
    /// <responce code ="200"> Успешное выполнение запроса. 
    /// </responce>>
    /// <responce code ="400"> Неверный запрос. </responce>>
    /// <responce code ="500"> Серверная ошибка. </responce>>
    [HttpPost]
    [ProducesResponseType(typeof(Person), 200)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(typeof(List<string>), 500)]
    public async Task<IActionResult> Create([FromBody] PersonRequest model,
                                            [FromServices] IValidator<PersonRequest> validator)
    {
        var validationResult = validator.Validate(model);

        if (!validationResult.IsValid)
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var failure in validationResult.Errors)
            {
                modelStateDictionary.AddModelError(
                    failure.PropertyName,
                    failure.ErrorMessage);
            }

            return ValidationProblem(modelStateDictionary);
        }

        var result = await _mediator.Send(new CreatePersonCommand(model));
        return Ok(result);
    }

    /// <summary>
    /// Обновить данные пользователя.
    /// </summary>
    /// <param name="id"> Уникальный идентификатор пользователя. 
    /// </param>
    /// <param name="model"> Модель данных пользователя. 
    /// </param>
    /// <param name="validator"> Валидатор данных пользователя. 
    /// </param>
    /// <responce code ="200"> Успешное выполнение запроса. 
    /// </responce>>
    /// <responce code ="400"> Неверный запрос. </responce>>
    /// <responce code ="404"> Сущность не найдена в системе. 
    /// </responce>>
    /// <responce code ="500"> Серверная ошибка. </responce>>
    [HttpPut("id")]
    [ProducesResponseType(typeof(Person), 200)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(typeof(List<string>), 404)]
    [ProducesResponseType(typeof(List<string>), 500)]
    public async Task<IActionResult> Update(long id,
                                            [FromBody] PersonRequest model,
                                            [FromServices] IValidator<PersonRequest> validator)
    {
        var validationResult = validator.Validate(model);

        if (!validationResult.IsValid)
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var failure in validationResult.Errors)
            {
                modelStateDictionary.AddModelError(
                    failure.PropertyName,
                    failure.ErrorMessage);
            }

            return ValidationProblem(modelStateDictionary);
        }

        var result = await _mediator.Send(new UpdatePersonCommand(id, model));

        if (result == null)
            return NotFound("Сущность не найдена");

        return Ok(result);
    }

    /// <summary>
    /// Удалить пользователя с заданным уникальным
    /// идентификатором.
    /// </summary>
    /// <param name="id"> Уникальный идентификатор пользователя. 
    /// </param>
    /// <responce code ="200"> Успешное выполнение запроса. 
    /// </responce>>
    /// <responce code ="500"> Серверная ошибка. </responce>>
    [HttpDelete("id")]
    [ProducesResponseType(typeof(IActionResult),200)]
    [ProducesResponseType(typeof(List<string>), 500)]
    public async Task<IActionResult> Delete(long id)
    {
        await _mediator.Send(new DeletePersonCommand(id));
        return Ok();
    }
}
