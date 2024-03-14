using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class StudentCourse
    {
        [ForeignKey("Course")]
        public int CrsId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set;}

        public float? Grade { get; set; }

        
        public Student student { get; set; }
        public Course course { get; set; }
    }
}
