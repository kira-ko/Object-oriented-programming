using System.Collections.Generic;
using Lab1University.Interfaces;

namespace Lab1University.Models
{
    public abstract class Course : ICourse
    {
        public string Title { get; set; }
        public Teacher? Teacher { get; set; }

        protected List<Student> students;

        // конструктор
        public Course(string title)
        {
            Title = title;
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetStudents() // возвращаем список, а не копию
        {
            return students;
        }
    }
}
