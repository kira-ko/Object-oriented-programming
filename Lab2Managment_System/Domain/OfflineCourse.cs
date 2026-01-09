namespace UniversityManagement.Domain;

public class OfflineCourse : Course
{
    public string Room { get; private set; }

    public OfflineCourse(Guid id, string title, string room)
        : base(id, title)
    {
        if (string.IsNullOrWhiteSpace(room)) throw new ArgumentException("Требуется ввести комнтау.");
        Room = room;
    }

    public void ChangeRoom(string room)
    {
        if (string.IsNullOrWhiteSpace(room)) throw new ArgumentException("Требуется ввести комнтау.");
        Room = room;
    }

    public override string GetCourseDetails()
        => $"Offline course '{Title}' in room: {Room}";
}
