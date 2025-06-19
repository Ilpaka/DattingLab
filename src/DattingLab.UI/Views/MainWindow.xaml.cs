using System.Windows;

namespace DattingLab.UI.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ProfilePage());
        }
    }
}
