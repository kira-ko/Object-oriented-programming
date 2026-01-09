namespace UniversityManagement.Domain;

public class OnlineCourse : Course
{
    public string Platform { get; private set; }

    public OnlineCourse(Guid id, string title, string platform)
        : base(id, title)
    {
        if (string.IsNullOrWhiteSpace(platform)) throw new ArgumentException("Необходимо ввести платформу.");
        Platform = platform;
    }

    public void ChangePlatform(string platform)
    {
        if (string.IsNullOrWhiteSpace(platform)) throw new ArgumentException("Необходимо ввести платформу.");
        Platform = platform;
    }

    public override string GetCourseDetails()
        => $"Online course '{Title}' on platform: {Platform}";
}
