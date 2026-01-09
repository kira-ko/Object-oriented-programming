using UniversityManagement.Domain;

namespace UniversityManagement.Repositories;

public class InMemoryTeacherRepository : ITeacherRepository
{
    private readonly Dictionary<Guid, Teacher> _teachers = new();

    public void Add(Teacher teacher)
    {
        if (teacher is null) throw new ArgumentNullException(nameof(teacher));

        if (_teachers.ContainsKey(teacher.Id))
            throw new InvalidOperationException("Преподаватель с таким ID уже существует.");

        _teachers[teacher.Id] = teacher;
    }

    public Teacher? GetById(Guid teacherId)
        => _teachers.TryGetValue(teacherId, out var teacher) ? teacher : null;

    public IReadOnlyCollection<Teacher> GetAll()
        => _teachers.Values.ToList().AsReadOnly();
}
