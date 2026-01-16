namespace Lab1University.Models
{
    public class OfflineCourse : Course
    {
        public string RoomNumber { get; set; }

        public OfflineCourse(string title, string roomNumber) : base(title)
        {
            RoomNumber = roomNumber;
        }
    }
}
