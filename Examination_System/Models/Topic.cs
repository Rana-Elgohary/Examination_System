using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Topic
    {
        [Key]
        public int Topic_ID { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        [ForeignKey("Course")]
        public int Course_ID { get; set; }
        //public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public Course Course { get; set; }

    }
}
