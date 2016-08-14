using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Xml.Serialization;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using NMSConfig.Mxml;
using NMSConfig.Properties;

namespace NMSConfig.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private MxmlData _mxmlData;
        private string _selectedMxmlFile;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            this.SaveCommand = new RelayCommand(this.SaveCommandAction);

            this.BrowseForExeCommand = new RelayCommand(this.BrowseForExeCommandAction);

            this.ReloadMxmlFiles();
        }

        void ReloadSettings()
        {
            
        }

        private void BrowseForExeCommandAction()
        {
            MainWindow.BrowseForExe();

            this.ReloadMxmlFiles();
        }

        private void SaveCommandAction()
        {
            MxmlSerializer.Serialize(this.MxmlData, this.SelectedMxmlFile);
        }

        public ICommand BrowseForExeCommand { get; private set; }

        private void ReloadMxmlFiles()
        {
            this.SelectedMxmlFile = null;
            this.MxmlData = null;

            MxmlFiles.Clear();

            if (System.IO.File.Exists(Settings.Default.ExePath))
            {
                string directory = Path.GetDirectoryName(Settings.Default.ExePath);

                var settingsDirectory = Path.Combine(directory, "SETTINGS");

                var files = Directory.EnumerateFiles(settingsDirectory, "*.MXML", SearchOption.TopDirectoryOnly);

                foreach (string file in files)
                {
                    MxmlFiles.Add(file);
                }
            }

        }

        public MxmlData MxmlData
        {
            get { return _mxmlData; }
            set
            {
                _mxmlData = value; 
                this.RaisePropertyChanged();
            }
        }

        public ICommand SaveCommand { get; private set; }

        private void OpenMxmlFile(string path)
        {
            if (path != null)
            {
                if (File.Exists(path))
                {
                    this.MxmlData = MxmlSerializer.Deserialize(path);
                }
            }
        }

        public string SelectedMxmlFile
        {
            get { return _selectedMxmlFile; }
            set
            {
                _selectedMxmlFile = value;

                this.RaisePropertyChanged();

                OpenMxmlFile(value);
            }
        }

        public ObservableCollection<string> MxmlFiles { get; } = new ObservableCollection<string>();
    }

    
}