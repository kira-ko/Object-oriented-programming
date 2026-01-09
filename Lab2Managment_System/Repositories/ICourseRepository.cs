using UniversityManagement.Domain;

namespace UniversityManagement.Repositories;

public interface ICourseRepository
{
    void Add(Course course);
    void Remove(Guid courseId);
    Course? GetById(Guid courseId);
    IReadOnlyCollection<Course> GetAll();
}
