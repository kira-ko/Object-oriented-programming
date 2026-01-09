using UniversityManagement.Domain;

namespace UniversityManagement.Repositories;

public interface ITeacherRepository
{
    void Add(Teacher teacher);
    Teacher? GetById(Guid teacherId);
    IReadOnlyCollection<Teacher> GetAll();
}
