using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EmployeeCompetencies.Core.Models;
using EmployeeCompetencies.UseCases.Abstractions;
using EmployeeCompetencies.DataAccess.Entities;

namespace EmployeeCompetencies.DataAccess.Repositories;

/// <summary>
/// Реализация <see cref="IPersonRepository"/>.
/// </summary>
public class PersonRepository : IPersonRepository
{
    private readonly Context _context;

    private readonly IMapper _mapper;

    public PersonRepository(Context context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <inheritdoc/>
    public async Task<List<Person>> GetList()
    {
        var entities = await _context.Persons
            .AsNoTracking()
            .Include(s => s.Skills)
            .ToListAsync();

        return _mapper.Map<List<Person>>(entities);
    }

    /// <inheritdoc/>
    public async Task<Person?> GetById(long id)
    {
        var entity = await _context.Persons
            .Include(s => s.Skills)
            .FirstOrDefaultAsync(x => x.Id == id);

        return _mapper.Map<Person>(entity);
    }

    /// <inheritdoc/>
    public async Task<long> Create(Person person)
    {
        var entities = _mapper.Map<PersonDto>(person);
        await _context.Persons.AddAsync(entities);

        await _context.SaveChangesAsync();

        return person.Id;
    }

    /// <inheritdoc/>
    public async Task<long?> Update(long id,
                             string name,
                             string displayName,
                             List<Skill> skills)
    {
        var entity = await _context.Persons
            .Include(s => s.Skills)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            return null;

        var newSkills = _mapper.Map<List<SkillDto>>(skills);
        foreach (var skill in newSkills)
        {
            skill.OwnerId = id;
        }

        entity.Name = name;
        entity.DisplayName = displayName;

        _context.Skills.RemoveRange(entity.Skills);
        await _context.Skills.AddRangeAsync(newSkills);

        await _context.SaveChangesAsync();

        return entity.Id;
    }

    /// <inheritdoc/>
    public async Task Delete(long id)
    {
        await _context.Persons
            .Where(x => x.Id == id)
            .Include(s => s.Skills)
            .ExecuteDeleteAsync();
    }
}
