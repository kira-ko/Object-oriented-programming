using UniversityManagement.Domain;
using UniversityManagement.Repositories;
using UniversityManagement.Services;
using Xunit;

namespace UniversityManagement.Tests;

public class UniversityServiceTests
{
    // Helper: создаём сервис с in-memory репозиториями.
    // Так каждый тест изолирован и не зависит от других тестов.
    private static UniversityService CreateService(
        out InMemoryCourseRepository courseRepo,
        out InMemoryTeacherRepository teacherRepo)
    {
        courseRepo = new InMemoryCourseRepository();
        teacherRepo = new InMemoryTeacherRepository();
        return new UniversityService(courseRepo, teacherRepo);
    }

    [Fact]
    public void AssignTeacherToCourse_ShouldSetTeacher()
    {
        // Arrange
        var service = CreateService(out var courses, out var teachers);

        var course = new OnlineCourse(Guid.NewGuid(), "OOP", "Zoom");
        var teacher = new Teacher(Guid.NewGuid(), "Dr. Smith");

        service.AddCourse(course);
        service.AddTeacher(teacher);

        // Act
        service.AssignTeacherToCourse(course.Id, teacher.Id);

        // Assert
        var stored = courses.GetById(course.Id)!;
        Assert.NotNull(stored.Teacher);
        Assert.Equal(teacher.Id, stored.Teacher!.Id);
    }

    [Fact]
    public void EnrollStudentToCourse_ShouldAddStudent()
    {
        // Arrange
        var service = CreateService(out _, out _);

        var course = new OfflineCourse(Guid.NewGuid(), "Math", "Room 101");
        service.AddCourse(course);

        var student = new Student(Guid.NewGuid(), "Kira");

        // Act
        service.EnrollStudentToCourse(course.Id, student);

        // Assert
        var students = service.GetStudentsOfCourse(course.Id);
        Assert.Single(students);
        Assert.Equal(student.Id, students.First().Id);
    }

    [Fact]
    public void EnrollStudentToCourse_SameStudentTwice_ShouldThrow()
    {
        // Arrange
        var service = CreateService(out _, out _);

        var course = new OfflineCourse(Guid.NewGuid(), "Physics", "Room 202");
        service.AddCourse(course);

        var student = new Student(Guid.NewGuid(), "Kira");

        service.EnrollStudentToCourse(course.Id, student);

        // Act + Assert
        Assert.Throws<InvalidOperationException>(() =>
            service.EnrollStudentToCourse(course.Id, student));
    }

    [Fact]
    public void GetStudentsOfCourse_ShouldReturnStudents()
    {
        // Arrange
        var service = CreateService(out _, out _);

        var course = new OnlineCourse(Guid.NewGuid(), "English", "Teams");
        service.AddCourse(course);

        var s1 = new Student(Guid.NewGuid(), "Student One");
        var s2 = new Student(Guid.NewGuid(), "Student Two");

        service.EnrollStudentToCourse(course.Id, s1);
        service.EnrollStudentToCourse(course.Id, s2);

        // Act
        var students = service.GetStudentsOfCourse(course.Id);

        // Assert
        Assert.Equal(2, students.Count);
        Assert.Contains(students, s => s.Id == s1.Id);
        Assert.Contains(students, s => s.Id == s2.Id);
    }

    [Fact]
    public void GetCoursesOfTeacher_ShouldReturnOnlyTeachersCourses()
    {
        // Arrange
        var service = CreateService(out _, out _);

        var t1 = new Teacher(Guid.NewGuid(), "Teacher One");
        var t2 = new Teacher(Guid.NewGuid(), "Teacher Two");

        service.AddTeacher(t1);
        service.AddTeacher(t2);

        var c1 = new OnlineCourse(Guid.NewGuid(), "OOP", "Teams");
        var c2 = new OfflineCourse(Guid.NewGuid(), "Algebra", "Room 12");
        var c3 = new OnlineCourse(Guid.NewGuid(), "English", "Zoom");

        service.AddCourse(c1);
        service.AddCourse(c2);
        service.AddCourse(c3);

        service.AssignTeacherToCourse(c1.Id, t1.Id);
        service.AssignTeacherToCourse(c2.Id, t1.Id);
        service.AssignTeacherToCourse(c3.Id, t2.Id);

        // Act
        var t1Courses = service.GetCoursesOfTeacher(t1.Id);

        // Assert
        Assert.Equal(2, t1Courses.Count);
        Assert.All(t1Courses, c => Assert.NotNull(c.Teacher));
        Assert.All(t1Courses, c => Assert.Equal(t1.Id, c.Teacher!.Id));
    }

    [Fact]
    public void RemoveCourse_NotExisting_ShouldThrow()
    {
        // Arrange
        var service = CreateService(out _, out _);

        // Act + Assert
        Assert.Throws<InvalidOperationException>(() =>
            service.RemoveCourse(Guid.NewGuid()));
    }

    [Fact]
    public void GetCoursesOfTeacher_TeacherNotFound_ShouldThrow()
    {
        // Arrange
        var service = CreateService(out _, out _);

        // Act + Assert
        Assert.Throws<InvalidOperationException>(() =>
            service.GetCoursesOfTeacher(Guid.NewGuid()));
    }
}
