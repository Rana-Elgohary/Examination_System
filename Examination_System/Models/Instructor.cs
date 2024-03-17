using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Instructor
    {
        [Key]
        public int Ins_Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(50)]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,}", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        public string Password { get; set; }
        [NotMapped] // ==> won't go to the DB
        [Compare("Password")]
        public required string ConfirmPassword { get; set; }
        public int Age { get; set; }
        public string? Img_Id { get; set; }
        public float Salary { get; set; }
        [DataType(DataType.Date)] 
        public DateTime HiringDate { get; set; }

        public  Track? Track { get; set; }
        public  ICollection<Track_Instructor> Track_Instructor { get; } = new HashSet<Track_Instructor>();
        public  ICollection<InstructorCourse> InstructorCourse { get; } = new HashSet<InstructorCourse>();
    }
}
