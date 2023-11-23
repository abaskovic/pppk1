using Menager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menager.Dal
{
    public interface IRepository
    {
        IList<Subject> GetSubjects();
        IList<Exam> GetExams();
        IList<Student> GetStudents();
        IList<Professor> GetProfessors();

        void AddExam(Exam exam);    
        void UpdateExam(Exam exam); 
        void DeleteExam(int idExam);
        Exam GetExam(int idExam);   
        

        void addStudent(Student student);
        void updateStudent(Student student);
        void deleteStudent(int idStudent);
        Student getStudent(int idStudent);

        void addProfessor(Professor proffesor);
        void updateProfessor(Professor proffesor);
        void deleteProfessor(int idProffesor);
        Professor getProfessor(int idProffesor);


    }
}
