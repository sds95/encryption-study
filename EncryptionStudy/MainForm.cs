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

            // Load RTF resources.
            // All RTF resources should be put inside resx files or so.
            // Also, while loading, cool logo image should display as "loading program image".
            //boxBasics.LoadFile("Basics.rtf");
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

        private void comboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = comboLanguage.SelectedIndex;
            Properties.Settings.Default.Save();
            InitCaptions();
        }
    }
}
