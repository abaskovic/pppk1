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

    public partial class EditPersonPage : FramePage
    {
        private readonly Person? person;
        public EditPersonPage(PersonViewModel personViewModel, Person? person = null)
            :base(personViewModel)
        {
            InitializeComponent();
            this.person = person?? new Person();
        }
    }
}
