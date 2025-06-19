using System;
using System.Windows;

namespace DattingLab.UI
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            var mainWindow = app.Services.GetService(typeof(Views.MainWindow)) as Views.MainWindow;
            app.Run(mainWindow);
        }
    }
}
