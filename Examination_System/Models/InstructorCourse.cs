using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class InstructorCourse
    {
        [ForeignKey("Course")]
        public int CrsId{ get; set; }
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }

        public Course Course { get; set; }
        public Instructor instructor { get; set; }
    }
}
