using MySqlConnector;
using StudentCourseManager.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace StudentCourseManager
{
    public class DBHelper
    {
        // 连接字符串只存配置，不存连接对象
        private static readonly string connStr =
            "Server=localhost;Database=school_db_test;Uid=root;Pwd=root;Charset=utf8mb4;";

        /// <summary>
        /// 获取新连接（每次操作独立连接，避免冲突）
        /// </summary>
        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }

        // ========== 基础查询方法 ==========

        public static DataTable ExecuteQuery(string sql, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // ========== 学生管理 ==========

        /// <summary>
        /// 获取所有学生（MainForm 里调的是这个方法名）
        /// </summary>
        public static List<Student> GetStudents()
        {
            var list = new List<Student>();
            string sql = "SELECT id, name, age, major FROM student";
            DataTable dt = ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Student
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),
                    Age = Convert.ToInt32(row["age"]),
                    Major = row["major"].ToString()
                });
            }
            return list;
        }

        // 保留原来的方法名，作为别名
        public static List<Student> GetAllStudents() => GetStudents();

        /// <summary>
        /// 添加学生（接收 Student 对象，和 MainForm 配套）
        /// </summary>
        public static bool AddStudent(Student student)
        {
            string sql = "INSERT INTO student (id, name, age, major) VALUES (@id, @name, @age, @major)";
            return ExecuteNonQuery(sql,
                new MySqlParameter("@id", student.Id),
                new MySqlParameter("@name", student.Name),
                new MySqlParameter("@age", student.Age),
                new MySqlParameter("@major", student.Major)) > 0;
        }

        // 保留原来的参数版本，兼容旧代码
        public static bool AddStudent(string name, int age, string major)
        {
            string sql = "INSERT INTO student (name, age, major) VALUES (@name, @age, @major)";
            return ExecuteNonQuery(sql,
                new MySqlParameter("@name", name),
                new MySqlParameter("@age", age),
                new MySqlParameter("@major", major)) > 0;
        }

        /// <summary>
        /// 修改学生（接收 Student 对象）
        /// </summary>
        public static bool UpdateStudent(Student student)
        {
            string sql = "UPDATE student SET name=@name, age=@age, major=@major WHERE id=@id";
            return ExecuteNonQuery(sql,
                new MySqlParameter("@id", student.Id),
                new MySqlParameter("@name", student.Name),
                new MySqlParameter("@age", student.Age),
                new MySqlParameter("@major", student.Major)) > 0;
        }

        // 保留原来的参数版本
        public static bool UpdateStudent(int id, string name, int age, string major)
        {
            string sql = "UPDATE student SET name=@name, age=@age, major=@major WHERE id=@id";
            return ExecuteNonQuery(sql,
                new MySqlParameter("@id", id),
                new MySqlParameter("@name", name),
                new MySqlParameter("@age", age),
                new MySqlParameter("@major", major)) > 0;
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        public static bool DeleteStudent(int id)
        {
            string sql = "DELETE FROM student WHERE id=@id";
            return ExecuteNonQuery(sql, new MySqlParameter("@id", id)) > 0;
        }

        // ========== 教师管理 ==========

        public static List<Teacher> GetAllTeachers()
        {
            var list = new List<Teacher>();
            string sql = "SELECT id, name, title FROM teacher";
            DataTable dt = ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Teacher
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),
                    Title = row["title"].ToString()
                });
            }
            return list;
        }

        // ========== 课程管理 ==========

        public static List<Course> GetAllCourses()
        {
            var list = new List<Course>();
            string sql = @"
                SELECT c.id, c.name, c.teacher_id, t.name as teacher_name, c.capacity, c.enrolled 
                FROM course c 
                LEFT JOIN teacher t ON c.teacher_id = t.id";
            DataTable dt = ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Course
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),
                    TeacherId = row["teacher_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["teacher_id"]),
                    TeacherName = row["teacher_name"] == DBNull.Value ? "未分配" : row["teacher_name"].ToString(),
                    Capacity = Convert.ToInt32(row["capacity"]),
                    Enrolled = Convert.ToInt32(row["enrolled"])
                });
            }
            return list;
        }

        // ========== 选课与成绩 ==========

        public static List<SCRecord> GetAllSCRecords()
        {
            var list = new List<SCRecord>();
            string sql = @"
                SELECT s.id as student_id, s.name as student_name, 
                       c.id as course_id, c.name as course_name, 
                       t.name as teacher_name, sc.score
                FROM sc
                JOIN student s ON sc.student_id = s.id
                JOIN course c ON sc.course_id = c.id
                LEFT JOIN teacher t ON c.teacher_id = t.id";
            DataTable dt = ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SCRecord
                {
                    StudentId = Convert.ToInt32(row["student_id"]),
                    StudentName = row["student_name"].ToString(),
                    CourseId = Convert.ToInt32(row["course_id"]),
                    CourseName = row["course_name"].ToString(),
                    TeacherName = row["teacher_name"] == DBNull.Value ? "未分配" : row["teacher_name"].ToString(),
                    Score = row["score"] == DBNull.Value ? (double?)null : Convert.ToDouble(row["score"])
                });
            }
            return list;
        }

        public static List<SCRecord> GetScoresByStudentName(string name)
        {
            var list = new List<SCRecord>();
            string sql = @"
                SELECT s.id as student_id, s.name as student_name, 
                       c.id as course_id, c.name as course_name, 
                       t.name as teacher_name, sc.score
                FROM sc
                JOIN student s ON sc.student_id = s.id
                JOIN course c ON sc.course_id = c.id
                LEFT JOIN teacher t ON c.teacher_id = t.id
                WHERE s.name LIKE @name";
            DataTable dt = ExecuteQuery(sql, new MySqlParameter("@name", "%" + name + "%"));
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SCRecord
                {
                    StudentId = Convert.ToInt32(row["student_id"]),
                    StudentName = row["student_name"].ToString(),
                    CourseId = Convert.ToInt32(row["course_id"]),
                    CourseName = row["course_name"].ToString(),
                    TeacherName = row["teacher_name"] == DBNull.Value ? "未分配" : row["teacher_name"].ToString(),
                    Score = row["score"] == DBNull.Value ? (double?)null : Convert.ToDouble(row["score"])
                });
            }
            return list;
        }

        // ========== 选课（带事务）==========

        public static bool SelectCourse(int studentId, int courseId, out string errorMsg)
        {
            errorMsg = "";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 检查是否已选
                        using (var checkCmd = new MySqlCommand(
                            "SELECT 1 FROM sc WHERE student_id=@sid AND course_id=@cid", conn, trans))
                        {
                            checkCmd.Parameters.AddWithValue("@sid", studentId);
                            checkCmd.Parameters.AddWithValue("@cid", courseId);
                            if (checkCmd.ExecuteScalar() != null)
                            {
                                errorMsg = "该课程已选！";
                                trans.Rollback();
                                return false;
                            }
                        }

                        // 检查容量
                        int capacity = 0, enrolled = 0;
                        using (var capCmd = new MySqlCommand(
                            "SELECT capacity, enrolled FROM course WHERE id=@cid", conn, trans))
                        {
                            capCmd.Parameters.AddWithValue("@cid", courseId);
                            using (var reader = capCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    capacity = reader.GetInt32("capacity");
                                    enrolled = reader.GetInt32("enrolled");
                                }
                            }
                        }

                        if (enrolled >= capacity)
                        {
                            errorMsg = "课程已满！";
                            trans.Rollback();
                            return false;
                        }

                        // 插入选课记录
                        using (var insCmd = new MySqlCommand(
                            "INSERT INTO sc (student_id, course_id) VALUES (@sid, @cid)", conn, trans))
                        {
                            insCmd.Parameters.AddWithValue("@sid", studentId);
                            insCmd.Parameters.AddWithValue("@cid", courseId);
                            insCmd.ExecuteNonQuery();
                        }

                        // 更新已选人数
                        using (var updCmd = new MySqlCommand(
                            "UPDATE course SET enrolled = enrolled + 1 WHERE id=@cid", conn, trans))
                        {
                            updCmd.Parameters.AddWithValue("@cid", courseId);
                            updCmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        errorMsg = ex.Message;
                        return false;
                    }
                }
            }
        }

        // ========== 录入成绩 ==========

        public static bool UpdateScore(int studentId, int courseId, double score)
        {
            string sql = "UPDATE sc SET score=@score WHERE student_id=@sid AND course_id=@cid";
            return ExecuteNonQuery(sql,
                new MySqlParameter("@score", score),
                new MySqlParameter("@sid", studentId),
                new MySqlParameter("@cid", courseId)) > 0;
        }
    }
}