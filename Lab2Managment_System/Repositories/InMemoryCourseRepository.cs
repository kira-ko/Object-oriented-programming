using UniversityManagement.Domain;

namespace UniversityManagement.Repositories;

public class InMemoryCourseRepository : ICourseRepository
{
    private readonly Dictionary<Guid, Course> _courses = new();

    public void Add(Course course)
    {
        if (course is null) throw new ArgumentNullException(nameof(course));

        if (_courses.ContainsKey(course.Id))
            throw new InvalidOperationException("Курс с таким ID уже существует.");

        _courses[course.Id] = course;
    }

    public void Remove(Guid courseId)
    {
        if (!_courses.Remove(courseId))
            throw new InvalidOperationException("Курс не найден.");
    }

    public Course? GetById(Guid courseId)
        => _courses.TryGetValue(courseId, out var course) ? course : null;

    public IReadOnlyCollection<Course> GetAll()
        => _courses.Values.ToList().AsReadOnly();
}
