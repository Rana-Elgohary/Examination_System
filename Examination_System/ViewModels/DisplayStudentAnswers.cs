namespace Examination_System.ViewModels
{
    public class DisplayStudentAnswers
    {
        public int Ques_ID { get; set; }
        public string Quest { get; set; }
        public string Corr_Answer { get; set; }
        public string OPt1_Answer { get; set; }
        public string OPt2_Answer { get; set; }
        public string OPt3_Answer { get; set; }
        public string Student_Answer { get; set; }
        public string type { get; set; }
        public bool If_Correct { get; set; }
    }
}
