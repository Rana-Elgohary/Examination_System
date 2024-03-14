using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class StudentAnswer
    {
        [ForeignKey("Student")]
        public int Stud_Id { get; set; }
        [ForeignKey("Question")]
        public int Ques_ID { get; set; }
        [StringLength(500)]
        public string Student_Answer { get; set; }
        public bool If_Correct {  get; set; }
     
        public Student Student { get; set; }
        public Question Question { get; set; }
    }
}
