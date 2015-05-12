using System;               // STAThread.
using System.Windows.Forms; // For Form.

namespace EncryptionStudy
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}