using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using NMSConfig.Properties;
using Squirrel;

namespace NMSConfig
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }

            Task.Run(Update);
        }

        
        private async Task Update()
        {
            using (var mgr = new UpdateManager("https://nmsconfig.blob.core.windows.net/software"))
            {
                await mgr.UpdateApp();
            }
        }
    }
}
