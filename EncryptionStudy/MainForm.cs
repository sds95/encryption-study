using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace EncryptionStudy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Load language.
            comboLanguage.SelectedIndex = Properties.Settings.Default.Language;

            // Initialize components.
            InitCaptions();

            // Load text files.
            boxBasics.LoadFile("test.rtf");
        }

        private void InitCaptions()
        {
            // Load language.
            if (Properties.Settings.Default.Language == 0)
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            else
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");

            // Tabs.
            tabBasics.Text = Strings.CryptographyEssentials;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Language = comboLanguage.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void comboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = comboLanguage.SelectedIndex;
            InitCaptions();
        }

        /*private void btnStartEncryption_Click(object sender, EventArgs e)
        {
            switch (comboEncryption.SelectedIndex)
            { 
    
            }
        }*/
    }
}
