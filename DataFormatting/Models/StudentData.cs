namespace DataFormatting.Models
{
    public class StudentData
    {
        public List<Student> ActiveStudents { get; set; }
        public double AverageActiveAge { get; set; }
        public double AverageActiveGPA { get; set; }
        public List<Student> InactiveStudents { get; set; }
        public double AverageInactiveAge { get; set; }
        public double AverageInactiveGPA { get; set; }
    }
}
