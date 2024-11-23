using EmployeeCompetencies.Core.Models;

namespace EmployeeCompetencies.UseCases.Abstractions;

/// <summary>
/// Репозиторий обработки данных сотрудников.
/// </summary>
public interface IPersonRepository
{
    /// <summary>
    /// Создать экземпляр класса <see cref="Person"/>
    /// </summary>
    /// <param name="person"></param>
    /// <returns> Возвращает уникальный идентификатор 
    /// созданного сотрудника. </returns>
    Task<long> Create(Person person);

    /// <summary>
    /// Удалить из системы сотрудника с заданным идентификатором. 
    /// </summary>
    /// <param name="id"> Идентификатор сотрудника. </param>
    Task Delete(long id);

    /// <summary>
    /// Найти сотрудника в системе по 
    /// его уникальному идентификатору.
    /// </summary>
    /// <param name="id"> Уникальный идентификатор 
    /// сотрудника. </param>
    /// <returns> Возвращает объект класса 
    /// <see cref="Person"/> или null, 
    /// если сотрудника нет в системе.</returns>
    Task<Person?> GetById(long id);

    /// <summary>
    /// Получить список существующих в системе 
    /// сотрудников и их компетенций.
    /// </summary>
    /// <returns> Возвращает список существущих 
    /// в системе сотрудников. </returns>
    Task<List<Person>> GetList();

    /// <summary>
    /// Редактировать данные сотрудника.
    /// </summary>
    /// <param name="id"> Уникальный идентификатор 
    /// сотрудника. </param>
    /// <param name="name"> Имя сотрудника. </param>
    /// <param name="displayName">Отображаемое имя сотрудника. 
    /// </param>
    /// <param name="skills"> Список компетенций сотрудника. 
    /// </param>
    /// <returns> Возвращает уникальный идентификатор 
    /// сотрудника или null, если сотрудника
    /// не существует в системе. </returns>
    Task<long?> Update(long id,
                string name,
                string displayName,
                List<Skill> skills);
}