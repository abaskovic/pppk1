using Menager.Models;
using Menager.ViewModel;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace Menager
{

    public partial class ListExamsPage : FramePage
    {

        private readonly ExamViewModel exams;
        public ListExamsPage(ExamViewModel examViewModel, ProfessorViewModel professorViewModel, StudentViewModel studentViewModel)
                  : base(examViewModel, professorViewModel, studentViewModel)

        {
            InitializeComponent();
            exams = examViewModel;
            lvExams.ItemsSource = exams.Exam;

            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;

            //if (section != null && !section.SectionInformation.IsProtected)
            //{
            //    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            //    config.Save(ConfigurationSaveMode.Modified);
            //    Debug.WriteLine("suc");
            //}
            //else
            //{
            //    Debug.WriteLine("not find");
            //}


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

        private void FramePage_Loaded(object sender, RoutedEventArgs e)
        {
            lvExams.ItemsSource = null;
            lvExams.ItemsSource = exams.Exam;
            Debug.WriteLine(exams.Exam[0].ProfessorName);

        }
    }
}
