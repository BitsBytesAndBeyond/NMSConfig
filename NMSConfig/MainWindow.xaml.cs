using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Microsoft.Practices.ServiceLocation;
using Microsoft.Win32;
using NMSConfig.Properties;
using NMSConfig.ViewModel;
using Path = System.IO.Path;

namespace NMSConfig
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var asm = Assembly.GetAssembly(typeof(MainWindow));

            this.Title += $" {asm.GetName().Version}";
        }

        public static void BrowseForExe()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "No Man's Sky (NMS.exe)|NMS.exe";

            if (openFileDialog.ShowDialog() == true)
            {
                Settings.Default.ExePath = openFileDialog.FileName;
                Settings.Default.Save();
            }
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Settings.Default.ExePath) || !File.Exists(Settings.Default.ExePath))
            {
                var t = MessageBox.Show(this, "NMS.exe Not Found", "The path to NMS.exe need to be set do it now?", MessageBoxButton.YesNo);

                if (t == MessageBoxResult.Yes)
                {
                    ServiceLocator.Current.GetInstance<MainViewModel>().BrowseForExeCommand.Execute(null);
                }

            }
        }
    }
}
