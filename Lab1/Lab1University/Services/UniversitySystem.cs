using System.Collections.Generic;
using Lab1University.Models;
using Lab1University.Interfaces;

namespace Lab1University.Services
{
    public class UniversitySystem
    {
        private List<ICourse> courses;

        public UniversitySystem()
        {
            courses = new List<ICourse>();
        }

        public void AddCourse(ICourse course)
        {
            courses.Add(course);
        }

        public void RemoveCourse(ICourse course)
        {
            courses.Remove(course);
        }

        public List<ICourse> GetAllCourses()
        {
            return courses;
        }

        public void AssignTeacherToCourse(ICourse course, Teacher teacher)
        {
            course.Teacher = teacher;
        }
        
        public List<ICourse> GetCoursesByTeacher(Teacher teacher)
        {
            List<ICourse> result = new List<ICourse>();

            foreach (ICourse course in courses)
            {
                if (course.Teacher == teacher)
                {
                    result.Add(course);
                }
            }

            return result;
        }
    }
}
