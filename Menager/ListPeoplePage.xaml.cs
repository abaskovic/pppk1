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

    public partial class ListPeoplePage : FramePage
    {
        public ListPeoplePage(PersonViewModel personViewModel)
            :base(personViewModel) 
        {
            InitializeComponent();
            lvPeople.ItemsSource = personViewModel.People;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new EditPersonPage(PersonViewModel));

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvPeople.SelectedItem!=null) { 
            
            Frame?.Navigate(new EditPersonPage(PersonViewModel, lvPeople.SelectedItems as Person));
            }

        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lvPeople.SelectedItem != null)
            {
                PersonViewModel.People.Remove((lvPeople.SelectedItem as Person)!);
            }
        }
    }
}
