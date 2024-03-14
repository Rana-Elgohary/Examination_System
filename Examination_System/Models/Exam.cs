using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Exam
    {
        [Key]
        public int Exam_ID { get; set; }
        public int Duration { get; set;}
        [ForeignKey("Course")]
        public int Course_ID { get; set;}

        public Course Course { get; set;}
        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();
    }
}
