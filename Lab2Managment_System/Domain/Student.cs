namespace UniversityManagement.Domain;

public class Student
{
    public Guid Id { get; }
    public string FullName { get; }

    public Student(Guid id, string fullName)
    {
        if (id == Guid.Empty) throw new ArgumentException("ID учащегося не может быть пустым.");
        if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Введите имя студента.");

        Id = id;
        FullName = fullName;
    }
}
