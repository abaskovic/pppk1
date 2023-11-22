using Menager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Menager
{
    public class FramePage:Page
    {
        public FramePage(PersonViewModel personViewModel)
        {
           PersonViewModel = personViewModel;
        }

        public PersonViewModel PersonViewModel { get; }
        public Frame? Frame { get; set; }
    }
}
