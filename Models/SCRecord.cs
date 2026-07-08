namespace StudentCourseManager.Models
{
    public class SCRecord
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public double? Score { get; set; }   // 可能为 NULL（未评分）
    }
}