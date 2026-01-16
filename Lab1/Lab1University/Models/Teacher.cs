namespace Lab1University.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Teacher(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
