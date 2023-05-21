using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Business_Logic_Layer
{
    public class Business_Form1:Data_Access
    {
        //Select all the info of students
        public DataTable Select()
        {
            base.Link();
            string Query = "select * from Student";
            DataTable output=base.SelectData(Query);
            base.Unlink();
            return output;
        }
        // Add a new Student in Student_Management
        public void AddStudent(int id, string name, string family, DateTime dt)
        {
            base.Link();
            string Query = "INSERT INTO Student (StudentId, Name, Family, BirthDate) VALUES('" + id + "', '" + name + "', '" + family + "', '" + dt.ToString("yyyy-MM-dd") + "')";
            base.ExecuteQuery(Query);
            base.Unlink();
        }
        //Delete a student in Student_Management
        public void DeleteStudent(int id)
        {
            base.Link();
            string Query = "DELETE FROM Student WHERE StudentId=" + id;
            base.ExecuteQuery(Query);
            base.Unlink();
        }
        //Update a student in Student_Management
        public void UpdateStudent(int id, string name, string family, DateTime dt)
        {
            base.Link();
            string Query = "UPDATE Student SET Name='" + name + "', Family='" + family + "', BirthDate='" + dt.ToString("yyyy-MM-dd") + "' WHERE StudentId=" + id;
            base.ExecuteQuery(Query);
            base.Unlink();
        }

        //Search a student in table in Student_Management
        public DataTable Search(int id)
        {
            base.Link();
            string Query = "SELECT * FROM Student WHERE StudentId=" + id;
            DataTable dt = base.SelectData(Query);
            base.Unlink();
            return dt;
        }

       
        //Get all StudentId from students
        public DataTable GetAllStudentIds()
        {
            base.Link();
            string query = "SELECT StudentId FROM Student";
            DataTable dt = base.SelectData(query);
            base.Unlink();
            return dt;
        }

        //Select Distinct CoursName from course to load it in comboBox
        public DataTable GetAllGrades()
        {
            base.Link();
            string query = "SELECT DISTINCT CoursName FROM Course";
            DataTable dt = base.SelectData(query);
            base.Unlink();
            return dt;
        }
        // Get all the coursName for the corresponding Student
        public DataTable GetCourseByStudentId(int id)
        {
            Data_Access da = new Data_Access();
            da.Link();
            string query = $"SELECT Course.CoursName FROM Grade INNER JOIN Course ON Grade.CoursId = Course.CoursId WHERE Grade.StudentId = {id}";
            DataTable dt = da.SelectData(query);
            da.Unlink();
            return dt;
        }

        // Get a SINGLE Grade with CoursId and StudentId
        public DataTable GetGradeByStudentIdAndCourseName(int studentId, string courseName)
        {
            Data_Access da = new Data_Access();
            da.Link();
            string query = $"SELECT Grade FROM Grade INNER JOIN Course ON Grade.CoursId = Course.CoursId WHERE Grade.StudentId = {studentId} AND Course.CoursName = '{courseName}'";
            DataTable dt = da.SelectData(query);
            da.Unlink();
            return dt;
        }
        //Add a new Grade for a student in Grade Management
        public void AddGrade(int studentId, string coursName, double grade)
        {
            try
            {
                base.Link();
                string query = $"INSERT INTO Grade (StudentId, CoursId, Grade) VALUES ({studentId}, (SELECT CoursId FROM Course WHERE CoursName = '{coursName}'), {grade})";
                base.ExecuteQuery(query);
                base.Unlink();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Update a new Grade for a student in Grade Management
        public void UpdateGrade(int studentId, string coursName, int grade)
        {
            base.Link();
            // Récupérer l'ID du cours à partir de son nom
            string query = $"SELECT CoursId FROM Course WHERE CoursName = '{coursName}'";
            DataTable dt = base.SelectData(query);
            int coursId = int.Parse(dt.Rows[0]["CoursId"].ToString());

            // Mettre à jour la note
            query = $"UPDATE Grade SET Grade = '{grade}' WHERE StudentId = {studentId} AND CoursId = {coursId}";
            base.ExecuteQuery(query);
            base.Unlink();
        }
        // Select all the info of the tale Grade with StudentId
        public DataTable GetGradesByStudentId(int studentId)
        {
            Data_Access da = new Data_Access();
            da.Link();
            string query = "SELECT * FROM Grade WHERE StudentId=" + studentId;
            DataTable dt = da.SelectData(query);
            da.Unlink();
            return dt;
        }

        //Get all the grades of all studens with CoursName in Consultation
        public DataTable GetStudentGradesByCourseName(string courseName)
        {
            Data_Access da = new Data_Access();
            da.Link();
            string query = $"SELECT Student.StudentId, Student.Name, Student.Family, Grade.Grade FROM Grade INNER JOIN Student ON Grade.StudentId = Student.StudentId INNER JOIN Course ON Grade.CoursId = Course.CoursId WHERE Course.CoursName = '{courseName}'";
            DataTable dt = da.SelectData(query);
            da.Unlink();
            return dt;
        }





    }
}
