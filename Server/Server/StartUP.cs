using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    class StartUP
    {
        // The path to the key where Windows looks for startup applications
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public StartUP()
        {
        }

        public void setAsStartup(bool value)
        {

            //check if application already runs on startup
            bool running = false;
            if (rkApp.GetValue("ControlServer") != null)
            {
                running = true;
            }
        
            //apply the settings in the registry
            if (value == true && running == false)
            {
                rkApp.SetValue("ControlServer", Application.ExecutablePath);
            }
            else if(value == false && running == true)
            {
                rkApp.DeleteValue("ControlServer", false);
            }


        }

   

    }
}
