using System.Collections.Generic;
using Lab1University.Models;
using Lab1University.Services;
using Lab1University.Interfaces;
using Xunit;

namespace Lab1University.Tests.Tests
{
    public class UniversitySystemTests
    {
        [Fact]
        public void AddCourse_WhenCourseAdded_CourseAppearsInList()
        {
            // Arrange
            UniversitySystem system = new UniversitySystem();
            Course course = new OnlineCourse("C# Basics", "https://example.com");

            // Act
            system.AddCourse(course);
            List<ICourse> allCourses = system.GetAllCourses();

            // Assert
            Assert.Single(allCourses);
        }
        
        [Fact]
        public void RemoveCourse_WhenCourseRemoved_ListBecomesEmpty()
        {
            // Arrange
            UniversitySystem system = new UniversitySystem();
            Course course = new OnlineCourse("C# Basics", "https://example.com");
            system.AddCourse(course);

            // Act
            system.RemoveCourse(course);
            List<ICourse> allCourses = system.GetAllCourses();

            // Assert
            Assert.Equal(0, allCourses.Count);
        }

        [Fact]
        public void AssignTeacherToCourse_WhenAssigned_CourseHasTeacher()
        {
            // Arrange
            UniversitySystem system = new UniversitySystem();
            ICourse course = new OnlineCourse("C# Basics", "https://example.com");
            Teacher teacher = new Teacher(1, "John Smith");

            // Act
            system.AssignTeacherToCourse(course, teacher);

            // Assert
            Assert.Equal(teacher, course.Teacher);
        }


        [Fact]
        public void GetCoursesByTeacher_WhenTeacherHasCourses_ReturnsOnlyThoseCourses()
        {
            // Arrange
            UniversitySystem system = new UniversitySystem();

            Teacher teacher1 = new Teacher(1, "Teacher One");
            Teacher teacher2 = new Teacher(2, "Teacher Two");

            ICourse course1 = new OnlineCourse("Course 1", "https://example.com/1");
            ICourse course2 = new OfflineCourse("Course 2", "101A");
            ICourse course3 = new OnlineCourse("Course 3", "https://example.com/3");

            system.AddCourse(course1);
            system.AddCourse(course2);
            system.AddCourse(course3);

            system.AssignTeacherToCourse(course1, teacher1);
            system.AssignTeacherToCourse(course2, teacher1);
            system.AssignTeacherToCourse(course3, teacher2);

            // Act
            List<ICourse> result = system.GetCoursesByTeacher(teacher1);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(course1, result);
            Assert.Contains(course2, result);
        }


        [Fact]
        public void AddStudent_WhenStudentAdded_StudentAppearsInCourse()
        {
            // Arrange
            ICourse course = new OnlineCourse("C# Basics", "https://example.com");
            Student student = new Student(1, "Kira");

            // Act
            course.AddStudent(student);
            List<Student> students = course.GetStudents();

            // Assert
            Assert.Single(students);
            Assert.Contains(student, students);
        }

    }
}
