using Menager.Models;
using Menager.ViewModel;
using System.Windows;

namespace Menager
{

    public partial class ListExamsPage : FramePage
    {
        public ListExamsPage(ExamViewModel examViewModel, ProfessorViewModel professorViewModel, StudentViewModel studentViewModel)
                  : base(examViewModel, professorViewModel, studentViewModel)

        {
            InitializeComponent();
            lvExams.ItemsSource = examViewModel.Exam;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new EditExamPage(ExamViewModel, ProfessorViewModel, StudentViewModel)
            {
                Frame = Frame
            });

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvExams.SelectedItem != null)
            {

                Frame?.Navigate(new EditExamPage(ExamViewModel, ProfessorViewModel, StudentViewModel, lvExams.SelectedItem as Exam)
                {
                    Frame = Frame
                });
            }

        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lvExams.SelectedItem != null)
            {
                if (MessageBox.Show("Do You Want Delete ? ", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ExamViewModel.Exam.Remove((lvExams.SelectedItem as Exam)!);
                }
            }


        }
    }
}
