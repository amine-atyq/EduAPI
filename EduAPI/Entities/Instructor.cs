namespace EduAPI.Entities
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string OfficeNumber { get; set; }

        // Navigation property for the one-to-many relationship with Course
        public ICollection<Course> Courses { get; set; }
    }
}
