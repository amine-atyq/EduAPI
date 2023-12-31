using System.Collections.Generic;

namespace EduAPI.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StudyHours { get; set; }

        // Navigation property for the many-to-many relationship with Student
        public ICollection<StudentCourse> StudentCourses { get; set; }

        // Foreign key for Instructor (one-to-many relationship)
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }
    }
}
