using MediatR;
using EmployeeCompetencies.Core.Models;
using EmployeeCompetencies.UseCases.Abstractions;
using AutoMapper;

namespace EmployeeCompetencies.UseCases.Commands.AddPersonCommand;

/// <summary>
/// Обработчик команды создания сотрудника.
/// </summary>
public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, long>
{
    private readonly IPersonRepository _repository;

    private readonly IMapper _mapper;

    public CreatePersonCommandHandler(IPersonRepository repository,
                                      IMapper mapper)
    {
        _repository = repository 
            ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper 
            ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<long> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var model = request.Model;

        var person = new Person(model.Name, model.DisplayedName);
        
        var skills = _mapper.Map<List<Skill>>(model.Skills);
        
        person.Skills = skills;

        return await _repository.Create(person);
    }
}
