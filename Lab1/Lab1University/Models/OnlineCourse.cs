namespace Lab1University.Models
{
    public class OnlineCourse : Course
    {
        public string PlatformUrl { get; set; }

        public OnlineCourse(string title, string platformUrl) : base(title)
        {
            PlatformUrl = platformUrl;
        }
    }
}
