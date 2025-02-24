using System.ComponentModel;

namespace DataFormatting.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [DisplayName("Name")]
        public string StudentName { get; set; }
        [DisplayName("Age")]
        public int StudentAge { get; set; }
        [DisplayName("GPA")]
        public double StudentGradePointAverage { get; set; }
        [DisplayName("Join Date")]
        public string StudentJoinDate { get; set; }
        [DisplayName("Active")]
        public Boolean StudentActive { get; set; }
    }
}
