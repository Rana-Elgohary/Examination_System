using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Course
    {
        [Key]
        public int Course_ID { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        public int Hours { get; set; }
        //[ForeignKey("Topic")]
        //public int Topic_ID { get; set; }

        public Exam Exam { get; set; }
        //public Topic Topic { get; set; }
        public ICollection<Topic> Topics { get; set; } = new HashSet<Topic>();
        public ICollection<StudentCourse> studentCourses { get; } = new HashSet<StudentCourse>();
        public ICollection<InstructorCourse> InstructorCourses { get; } = new HashSet<InstructorCourse>();
    }
}
