using Menager.Models;
using Menager.Utils;
using Menager.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Menager
{

    public partial class EditPersonPage : FramePage
    {

        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";

        private readonly Person? person;
        public EditPersonPage(ExamViewModel examViewModel, Person? person = null)
            : base(examViewModel)
        {
            InitializeComponent();
            this.person = person ?? new Person();
            DataContext = person;

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

            Frame?.NavigationService.GoBack();

        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                person!.FirstName=tbFirstName.Text.Trim();
                person!.LastName=tbLastName.Text.Trim();
                person!.Age=int.Parse(tbAge.Text.Trim());
                person!.Email=tbEmail.Text.Trim();
                person!.Picture = ImageUtils.BitmapIMageToByteArray(picture.Source as BitmapImage);
                
                //if (person.IDPerson==0)
                //{
                //    ExamViewModel.Exam.Add(e);
                //}
                //else
                //{
                //    ExamViewModel.UpdateExam(person);   
                //}

                Frame?.NavigationService.GoBack();

            }
        }

        private bool FormValid()
        {
            bool ok = true;

            grid.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                e.Background = Brushes.White;
                if (string.IsNullOrEmpty(e.Text.Trim())
                 || "Int".Equals(e.Tag) && !int.TryParse(e.Text, out int r)
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

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = Filter };
            if (dialog.ShowDialog() == true)
            {
                picture.Source = new BitmapImage(new Uri(dialog.FileName));
            }

        }
    }
}
