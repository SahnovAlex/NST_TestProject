using MediatR;
using AutoMapper;
using EmployeeCompetencies.Core.Models;
using EmployeeCompetencies.UseCases.Abstractions;

namespace EmployeeCompetencies.UseCases.Commands.UpdatePersonCommand;

/// <summary>
/// Обработчик команды редактирования данных сотрудника.
/// </summary>
public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, long?>
{
    public readonly IPersonRepository _repository;

    public readonly IMapper _mapper;

    public UpdatePersonCommandHandler(IPersonRepository repository,
                                      IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<long?> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var model = request.Model;
        var skillModels = model.Skills;

        var skills = _mapper.Map<List<Skill>>(skillModels);

        return await _repository.Update(request.Id,
                                              model.Name,
                                              model.DisplayedName,
                                              skills);
    }
}
