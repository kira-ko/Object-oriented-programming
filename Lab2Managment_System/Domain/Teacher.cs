namespace UniversityManagement.Domain;

public class Teacher
{
    public Guid Id { get; }
    public string FullName { get; }

    public Teacher(Guid id, string fullName)
    {
        if (id == Guid.Empty) throw new ArgumentException("ID преподавателя не может быть пустым.");
        if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Укажите имя преподавателя.");

        Id = id;
        FullName = fullName;
    }
}
