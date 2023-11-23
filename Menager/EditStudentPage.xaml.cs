using Menager.Models;
using Menager.Utils;
using Menager.ViewModel;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Menager
{

    public partial class EditStudentPage : FramePage
    {

        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly Student? student;
        public EditStudentPage(ExamViewModel examViewModel ,ProfessorViewModel professorViewModel, StudentViewModel studentViewModel, Student? student= null)
                        : base(examViewModel, professorViewModel, studentViewModel)
        {
            InitializeComponent();

            this.student = student ?? new Student();
            DataContext = student;
        }

        private bool FormValid()
        {
            bool ok = true;

            grid.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                e.Background = Brushes.White;
                if (string.IsNullOrEmpty(e.Text.Trim())
                 || "OIB".Equals(e.Tag) && !int.TryParse(e.Text, out int r) && e.Text.Trim().Length != 11
                 || "Email".Equals(e.Tag) && !ValidationUtils.IsValidEmail(e.Text))
                {
                    ok = false;
                    e.Background = Brushes.LightCoral;
                }
            });

            pictureBorder.BorderBrush = Brushes.White;

            if (picture.Source == null)
            {
                ok = false;
                pictureBorder.BorderBrush = Brushes.LightCoral;
            }

            return ok;

        }
        private void BtnCommit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (FormValid())
            {
                student!.FirstName = tbFirstName.Text.Trim();
                student!.LastName = tbLastName.Text.Trim();
                student!.Oib = tbOib.Text.Trim();
                student!.Email = tbEmail.Text.Trim();
                student!.Picture = ImageUtils.BitmapIMageToByteArray(picture.Source as BitmapImage);

                if (student.IdStudent == 0)
                {
                    StudentViewModel.Student.Add(student);
                }
                else
                {
                    StudentViewModel.UpdateStudent(student);
                }

                Frame?.NavigationService.GoBack();

            }

        }

        private void BtnUpload_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = Filter };
            if (dialog.ShowDialog() == true)
            {
                picture.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }

        private void BtnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }
    }
}
