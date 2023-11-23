using System.Windows;

namespace Menager
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new ListExamsPage(new ViewModel.ExamViewModel()) {
                Frame = frame
            });
        }
    }
}
