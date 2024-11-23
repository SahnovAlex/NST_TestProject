using AutoMapper;
using EmployeeCompetencies.Core.Models;
using EmployeeCompetencies.UseCases.Contracts;
using EmployeeCompetencies.DataAccess.Entities;

namespace EmployeeCompetencies.DataAccess;

/// <summary>
/// Конфигурация маппера.
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PersonDto, Person>()
            .ReverseMap();

        CreateMap<SkillDto, Skill>()
            .ReverseMap();

        CreateMap<SkillRequest, Skill>()
            .ConstructUsing(x => new Skill(x.Name, x.Level));
    }
}
