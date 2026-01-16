using System.Collections.Generic;
using Lab1University.Models;

namespace Lab1University.Interfaces
{
    public interface ICourse
    {
        string Title { get; set; }
        Teacher? Teacher { get; set; }

        void AddStudent(Student student);
        List<Student> GetStudents();
    }
}
