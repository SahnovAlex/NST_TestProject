using FluentValidation;
using EmployeeCompetencies.UseCases.Contracts;

namespace EmployeeCompetencies.UseCases.Validators;

/// <summary>
/// Валидатор для модели данных сотрудника.
/// </summary>
public class PersonRequestValidator
    : AbstractValidator<PersonRequest>
{
    public PersonRequestValidator()
    {
        RuleFor(model => model.Name)
            .Must(name => !string.IsNullOrEmpty(name))
                .WithMessage("Person's name is required");
        RuleFor(model => model.DisplayedName)
            .Must(name => !string.IsNullOrEmpty(name))
                .WithMessage("Person's display name is required");
        RuleFor(model => model.Skills)
            .NotEmpty()
                .WithMessage("An employee's skill set cannot be empty");
        RuleForEach(model => model.Skills)
            .SetValidator(new ObjectValidatorFromList());
    }
}

/// <summary>
/// Валидатор модели данных компетенции сотрудника.
/// </summary>
public class ObjectValidatorFromList
    : AbstractValidator<SkillRequest>
{
    public ObjectValidatorFromList()
    {
        RuleFor(model => model.Name)
            .Must(name => !string.IsNullOrEmpty(name))
                .WithMessage("Skill's name is required");
        RuleFor(model => model.Level)
            .InclusiveBetween((byte)1, (byte)10)
                .WithMessage("Level must be between 1 and 10");
    }
}