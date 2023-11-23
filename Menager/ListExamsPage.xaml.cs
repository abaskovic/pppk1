using Menager.Models;
using Menager.ViewModel;
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
    /// <summary>
    /// Interaction logic for ListExamsPage.xaml
    /// </summary>
    public partial class ListExamsPage : FramePage
    {
        public ListExamsPage(ExamViewModel examViewModel)
            :base(examViewModel)    
        {
            InitializeComponent();
            lvExams.ItemsSource = examViewModel.Exam;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Frame?.Navigate(new EditPersonPage(PersonViewModel)
            //{
            //    Frame = Frame
            //});

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvExams.SelectedItem != null)
            {

                //Frame?.Navigate(new EditPersonPage(PersonViewModel, lvExams.SelectedItem as Person)
                //{
                //    Frame = Frame
                //});
            }

        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lvExams.SelectedItem != null)
            {
                //if (MessageBox.Show("Do You Want Delete ? ", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                //{
                //    PersonViewModel.People.Remove((lvExams.SelectedItem as Person)!);
                //}
            }


        }
    }
}
