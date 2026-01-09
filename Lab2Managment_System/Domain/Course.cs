namespace UniversityManagement.Domain;

public abstract class Course
{
    private readonly List<Student> _students = new();

    public Guid Id { get; }
    public string Title { get; private set; }
    public Teacher? Teacher { get; private set; }

    public IReadOnlyCollection<Student> Students => _students.AsReadOnly();

    protected Course(Guid id, string title)
    {
        if (id == Guid.Empty) throw new ArgumentException("ID курса не может быть пустым.");
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Введите имя курса.");

        Id = id;
        Title = title;
    }

    public void Rename(string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle)) throw new ArgumentException("Введите имя курса.");
        Title = newTitle;
    }

    public void AssignTeacher(Teacher teacher)
    {
        Teacher = teacher ?? throw new ArgumentNullException(nameof(teacher));
    }

    public void EnrollStudent(Student student)
    {
        if (student is null) throw new ArgumentNullException(nameof(student));

        if (_students.Any(s => s.Id == student.Id))
            throw new InvalidOperationException("Студент уже записался на этот курс.");

        _students.Add(student);
    }

    public void RemoveStudent(Guid studentId)
    {
        var existing = _students.FirstOrDefault(s => s.Id == studentId);
        if (existing is null)
            throw new InvalidOperationException("Студент еще не записался на этот курс.");

        _students.Remove(existing);
    }

    public abstract string GetCourseDetails();
}