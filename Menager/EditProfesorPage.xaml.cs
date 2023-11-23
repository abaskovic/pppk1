using Menager.Models;
using Menager.Utils;
using Menager.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Menager
{

    public partial class EditProfesorPage : FramePage
    {

        private readonly Professor? professor;

        public EditProfesorPage(ExamViewModel examViewModel, ProfessorViewModel professorViewModel, StudentViewModel studentViewModel, Professor? professor = null)
                  : base(examViewModel, professorViewModel, studentViewModel)
        {
            InitializeComponent();
            this.professor = professor ?? new Professor();
            DataContext = professor;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                professor!.FirstName = tbFirstName.Text.Trim();
                professor!.LastName = tbLastName.Text.Trim();
                professor!.Oib = tbOib.Text.Trim();
                professor!.Email = tbEmail.Text.Trim();

                if (professor.IdProfessor == 0)
                {
                    ProfessorViewModel.Professor.Add(professor);
                }
                else
                {
                    ProfessorViewModel.UpdateProfessor(professor);
                }

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
                 || "OIB".Equals(e.Tag) && !int.TryParse(e.Text, out int r) && e.Text.Trim().Length != 11
                 || "Email".Equals(e.Tag) && !ValidationUtils.IsValidEmail(e.Text))
                {
                    ok = false;
                    e.Background = Brushes.LightCoral;
                }
            });



            return ok;

        }
    }
}
