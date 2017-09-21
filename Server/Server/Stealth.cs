using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Server
{
    class Stealth
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        public Stealth(bool show)
        {
            
            if (show == true)
            {
                ShowME();
            }
            else
            {
                HideME();
            }
        }

        public void HideME()
        {
            // Hide
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

        }

        public void ShowME()
        {
            // Show
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_SHOW);

        }

    }
}
