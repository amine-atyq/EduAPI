namespace EduAPI.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Navigation property for the many-to-many relationship with Course
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
