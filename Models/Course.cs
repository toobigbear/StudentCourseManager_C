namespace StudentCourseManager.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeacherId { get; set; }      // 可能为 NULL
        public string TeacherName { get; set; }   // LEFT JOIN 得到
        public int Capacity { get; set; }
        public int Enrolled { get; set; }
    }
}