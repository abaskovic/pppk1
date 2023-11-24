using Menager.Models;
using Menager.Utils;
using Menager.ViewModel;
using Microsoft.Win32;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System;
using Menager.Dal;
using System.Diagnostics;
using System.Collections.Generic;

namespace Menager
{



    public partial class EditExamPage : FramePage
    {
        private readonly Exam? exam;
        private readonly List<Subject>? subjects;
        private readonly StudentViewModel? students;
        private readonly ProfessorViewModel profesors;

        public EditExamPage(ExamViewModel examViewModel, ProfessorViewModel professorViewModel, StudentViewModel studentViewModel, Exam? exam = null)
            : base(examViewModel, professorViewModel, studentViewModel)
        {
            InitializeComponent();
            this.exam = exam ?? new Exam();
            subjects = RepositoryFactory.GetRepository.GetSubjects().ToList();
            students = studentViewModel;
            profesors = professorViewModel;
            DataContext = exam;
            SetComboBoxes();
        }

        private void SetComboBoxes()
        {
            cbStudent.ItemsSource = students?.Student;
            cbProfessor.ItemsSource = profesors?.Professor;
            cbSubject.ItemsSource = subjects;


            if (exam != null)
            {
                cbProfessor.SelectedIndex = profesors.Professor.ToList().FindIndex(p => p.IdProfessor == exam.IdProfessor);
                cbStudent.SelectedIndex = students.Student.ToList().FindIndex(s => s.IdStudent == exam.IdStudent);
                cbSubject.SelectedIndex = subjects!.ToList().FindIndex(p => p.IdSubject == exam.IdSubject);
                picture.Source = students?.Student[students.Student.ToList()!.FindIndex(s => s.IdStudent == exam.IdStudent)].Image;
            }



        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var subjects = RepositoryFactory.GetRepository.GetSubjects();
            var selectedSubject = cbSubject.SelectedItem as Subject;
            var indexSubject = subjects.ToList().FindIndex(p => p.IdSubject == selectedSubject?.IdSubject);

            var selectedProfessor = cbProfessor.SelectedItem as Professor;
            var indexProfessor = profesors.Professor.ToList().FindIndex(p => p.IdProfessor == selectedProfessor?.IdProfessor);
            Student? selectedStudent = cbStudent.SelectedItem as Student;

            var indexStudent = students.Student.ToList().FindIndex(p => p.IdStudent == selectedStudent?.IdStudent);

            if (FormValid())
            {
                exam!.Mark = int.Parse(tbMark.Text.Trim());
                exam!.StudentName = cbStudent.SelectedItem.ToString();
                exam!.ProfessorName = cbProfessor.SelectedItem.ToString();
                exam!.SubjectName = cbSubject.SelectedItem.ToString();
                exam!.IdStudent = students.Student[indexStudent].IdStudent;
                exam!.IdProfessor = profesors.Professor[indexProfessor].IdProfessor;
                exam!.IdSubject = subjects[indexSubject].IdSubject;

                if (exam.IdExam == 0)
                {
                    ExamViewModel.Exam.Add(exam);
                }
                else
                {
                    ExamViewModel.UpdateExam(exam);
                }

                Frame?.NavigationService.GoBack();

            }




        }

        private bool FormValid()
        {
            bool ok = true;

            grid.Children.OfType<ComboBox>().ToList().ForEach(e =>
            {
                e.Foreground = Brushes.Black;
                if (e.SelectedIndex == -1)
                {
                    ok = false;
                    e.Text = "Select Item";
                    e.Foreground = Brushes.Red;
                }

            });

            tbMark.Background = Brushes.White;

            int.TryParse(tbMark.Text.Trim(), out int r);
            if (r<1 || r>5 )
            {
                ok = false;
                tbMark.Background = Brushes.Red;

            }


            return ok;

        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new EditStudentPage(ExamViewModel, ProfessorViewModel, StudentViewModel)
            {
                Frame = Frame
            });
        }

        private void BtmAddProfessor_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new EditProfesorPage(ExamViewModel, ProfessorViewModel, StudentViewModel)
            {
                Frame = Frame
            });
        }

        private void BtnEditStudent_Click(object sender, RoutedEventArgs e)
        {

            var selected = cbStudent.SelectedItem as Student;

            if (selected != null)
            {

                Frame?.Navigate(new EditStudentPage(ExamViewModel, ProfessorViewModel, StudentViewModel, selected)
                {
                    Frame = Frame
                });
            }

        }

        private void BtnEditProffesor_Click(object sender, RoutedEventArgs e)
        {
            var selected = cbProfessor.SelectedItem as Professor;
            Debug.WriteLine(selected);

            if (selected != null)
            {
                Frame?.Navigate(new EditProfesorPage(ExamViewModel, ProfessorViewModel, StudentViewModel, selected)
                {
                    Frame = Frame
                });
            }
        }

        private void CbStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = cbStudent.SelectedItem as Student;
            picture.Source = selected?.Image;

        }

        private void FramePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SetComboBoxes();
        }
    }
}
