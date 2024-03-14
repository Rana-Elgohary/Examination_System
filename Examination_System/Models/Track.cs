using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [ForeignKey("Instructor")]
        public int? Supervisor { get; set; }

        public Instructor? Instructor { get; set; }
        public ICollection<Track_Instructor> Track_Instructor { get; }=new HashSet<Track_Instructor>();
        public ICollection<Student> students { get; } = new HashSet<Student>();

    }
}
