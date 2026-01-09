using UniversityManagement.Domain;
using UniversityManagement.Repositories;

namespace UniversityManagement.Services;

public class UniversityService
{
    private readonly ICourseRepository _courses;
    private readonly ITeacherRepository _teachers;

    public UniversityService(ICourseRepository courses, ITeacherRepository teachers)
    {
        _courses = courses ?? throw new ArgumentNullException(nameof(courses));
        _teachers = teachers ?? throw new ArgumentNullException(nameof(teachers));
    }

    // 1) Добавлять курс
    public void AddCourse(Course course)
    {
        _courses.Add(course);
    }

    // 1) Удалять курс
    public void RemoveCourse(Guid courseId)
    {
        _courses.Remove(courseId);
    }

    // Добавлять преподавателя 
    public void AddTeacher(Teacher teacher)
    {
        _teachers.Add(teacher);
    }

    // 1) Назначать преподавателя на курс
    public void AssignTeacherToCourse(Guid courseId, Guid teacherId)
    {
        var course = _courses.GetById(courseId)
            ?? throw new InvalidOperationException("Курс не найден.");

        var teacher = _teachers.GetById(teacherId)
            ?? throw new InvalidOperationException("Преподаватель не найден.");

        course.AssignTeacher(teacher);
    }

    // 1) Записать студента на курс
    public void EnrollStudentToCourse(Guid courseId, Student student)
    {
        var course = _courses.GetById(courseId)
            ?? throw new InvalidOperationException("Курс не найден.");

        course.EnrollStudent(student);
    }

    // 1) Получить список студентов курса
    public IReadOnlyCollection<Student> GetStudentsOfCourse(Guid courseId)
    {
        var course = _courses.GetById(courseId)
            ?? throw new InvalidOperationException("Курс не найден.");

        return course.Students;
    }

    // 3) Получить все курсы преподавателя
    public IReadOnlyCollection<Course> GetCoursesOfTeacher(Guid teacherId)
    {
        // Явная проверка существования преподавателя, чтобы ошибка была понятной
        if (_teachers.GetById(teacherId) is null)
            throw new InvalidOperationException("Преподаватель не найден.");

        return _courses.GetAll()
            .Where(c => c.Teacher is not null && c.Teacher.Id == teacherId)
            .ToList()
            .AsReadOnly();
    }
}
