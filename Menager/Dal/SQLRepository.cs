using Menager.Models;
using Menager.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace Menager.Dal
{
    internal class SQLRepository : IRepository


    {

        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;


        public IList<Subject> GetSubjects()
        {
            IList<Subject> list = new List<Subject>();
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Subject
                {
                    IdSubject = (int)reader[nameof(Subject.IdSubject)],
                    Name = reader[nameof(Subject.Name)].ToString()
                });
            }
            return list;
        }



        public IList<Exam> GetExams()
        {
            IList<Exam> list = new List<Exam>();
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;



            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(ReadExam(reader));
            }
            return list;
        }

        private Exam ReadExam(SqlDataReader reader) => new Exam
        {

            IdExam = (int)reader[nameof(Exam.IdExam)],
            Mark = (int)reader[nameof(Exam.Mark)],
            IdProfessor = (int)reader[nameof(Exam.IdProfessor)],
            IdStudent = (int)reader[nameof(Exam.IdStudent)],
            StudentName = getStudent((int)reader[nameof(Exam.IdStudent)]).ToString(),
            ProfessorName = getProfessor((int)reader[nameof(Exam.IdProfessor)]).ToString(),
            IdSubject = (int)reader[nameof(Exam.IdSubject)],
            SubjectName = reader[nameof(Exam.SubjectName)].ToString()

        };

        public IList<Student> GetStudents()
        {
            IList<Student> list = new List<Student>();
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;



            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(ReadStudent(reader));
            }
            return list;
        }

        private Student ReadStudent(SqlDataReader reader) => new Student
        {

            IdStudent = (int)reader[nameof(Student.IdStudent)],
            FirstName = reader[nameof(Student.FirstName)].ToString(),
            LastName = reader[nameof(Student.LastName)].ToString(),
            Oib = reader[nameof(Student.Oib)].ToString(),
            Email = reader[nameof(Student.Email)].ToString(),
            Picture = ImageUtils.ByteArrayToBitmapIMage(reader, nameof(Student.Picture).ToString())
        };

        public IList<Professor> GetProfessors()
        {
            IList<Professor> list = new List<Professor>();
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(ReadProffesor(reader));
            }
            return list;
        }

        private Professor ReadProffesor(SqlDataReader reader) => new Professor
        {

            IdProfessor = (int)reader[nameof(Professor.IdProfessor)],
            FirstName = reader[nameof(Professor.FirstName)].ToString(),
            LastName = reader[nameof(Professor.LastName)].ToString(),
            Oib = reader[nameof(Professor.Oib)].ToString(),
            Email = reader[nameof(Professor.Email)].ToString(),
        };

        public void AddExam(Exam exam)
        {

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Exam.IdSubject), exam.IdSubject);
            cmd.Parameters.AddWithValue(nameof(Exam.IdStudent), exam.IdStudent);
            cmd.Parameters.AddWithValue(nameof(Exam.IdProfessor), exam.IdProfessor);
            cmd.Parameters.AddWithValue(nameof(Exam.Mark), exam.Mark);

            var id = new SqlParameter(nameof(Exam.IdExam), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            Debug.WriteLine(cmd.Parameters);
            cmd.ExecuteNonQuery();
            exam.IdExam = (int)id.Value;
        }

        public void UpdateExam(Exam exam)
        {

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Exam.IdSubject), exam.IdSubject);
            cmd.Parameters.AddWithValue(nameof(Exam.IdStudent), exam.IdStudent);
            cmd.Parameters.AddWithValue(nameof(Exam.IdProfessor), exam.IdProfessor);
            cmd.Parameters.AddWithValue(nameof(Exam.Mark), exam.Mark);
            cmd.Parameters.AddWithValue(nameof(Exam.IdExam), exam.IdExam);
            Debug.WriteLine(cmd.CommandText);

            cmd.ExecuteNonQuery();

        }

        public void DeleteExam(int idExam)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Exam.IdExam), idExam);
            cmd.ExecuteNonQuery();

        }



        public Exam GetExam(int idExam)
        {

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue(nameof(Exam.IdExam), idExam);

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return ReadExam(reader);
            }
            throw new ArgumentException("wrong id");
        }

        public void addStudent(Student student)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Student.Email), student.Email);
            cmd.Parameters.AddWithValue(nameof(Student.Oib), student.Oib);
            cmd.Parameters.AddWithValue(nameof(Student.FirstName), student.FirstName);
            cmd.Parameters.AddWithValue(nameof(Student.LastName), student.LastName);

            cmd.Parameters.Add(
               new SqlParameter(nameof(Student.Picture), System.Data.SqlDbType.Binary, student.Picture!.Length)
               {
                   Value = student.Picture
               });

            var id = new SqlParameter(nameof(Student.IdStudent), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            student.IdStudent = (int)id.Value;
        }

        public void updateStudent(Student student)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Student.Email), student.Email);
            cmd.Parameters.AddWithValue(nameof(Student.Oib), student.Oib);
            cmd.Parameters.AddWithValue(nameof(Student.FirstName), student.FirstName);
            cmd.Parameters.AddWithValue(nameof(Student.LastName), student.LastName);
            cmd.Parameters.AddWithValue(nameof(Student.IdStudent), student.IdStudent);

            cmd.Parameters.Add(
               new SqlParameter(nameof(Student.Picture), System.Data.SqlDbType.Binary, student.Picture!.Length)
               {
                   Value = student.Picture
               });
            cmd.ExecuteNonQuery();
        }

        public void deleteStudent(int idStudent)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Student.IdStudent), idStudent);
            cmd.ExecuteNonQuery();

        }



        public void addProfessor(Professor professor)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Professor.Email), professor.Email);
            cmd.Parameters.AddWithValue(nameof(Professor.Oib), professor.Oib);
            cmd.Parameters.AddWithValue(nameof(Professor.FirstName), professor.FirstName);
            cmd.Parameters.AddWithValue(nameof(Professor.LastName), professor.LastName);

            var id = new SqlParameter(nameof(Professor.IdProfessor), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            professor.IdProfessor = (int)id.Value;
        }

        public void updateProfessor(Professor professor)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Professor.Email), professor.Email);
            cmd.Parameters.AddWithValue(nameof(Professor.Oib), professor.Oib);
            cmd.Parameters.AddWithValue(nameof(Professor.FirstName), professor.FirstName);
            cmd.Parameters.AddWithValue(nameof(Professor.LastName), professor.LastName);
            cmd.Parameters.AddWithValue(nameof(Professor.IdProfessor), professor.IdProfessor);
            cmd.ExecuteNonQuery();
        }

        public void deleteProfessor(int idProffesor)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Professor.IdProfessor), idProffesor);
            cmd.ExecuteNonQuery();


        }

        public Student getStudent(int idStudent)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue(nameof(Student.IdStudent), idStudent);

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return ReadStudent(reader);
            }
            throw new ArgumentException("wrong id");
        }

        public Professor getProfessor(int idProffesor)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue(nameof(Professor.IdProfessor), idProffesor);

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return ReadProffesor(reader);
            }
            throw new ArgumentException("wrong id");
        }
    }
}
