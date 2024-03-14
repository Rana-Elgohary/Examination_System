using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Track_Instructor
    {
        [ForeignKey("Track")]
        public int TrackId { get; set; }
        [ForeignKey("Instructor")]
        public int Ins_Id { get; set; }

        public Instructor instructor { get; set; }
        public Track   Track { get; set; }
    }
}
