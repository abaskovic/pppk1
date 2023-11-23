using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Menager.Models
{
    public class Exam
    {
        public int IdExam { get; set; }
        public int IdStudent { get; set; }
        public string? StudentName { get; set; }
        public int IdProfessor { get; set; }
        public string? ProfessorName { get; set; }
        public int Mark { get; set; }
        public int IdSubject { get; set; }
        public string? SubjectName { get; set; }


        public override string? ToString() => IdExam.ToString();

    }
}
