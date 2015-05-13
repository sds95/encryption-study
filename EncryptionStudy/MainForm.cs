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

            // Tabs for first part of theory.
            tabBasics.Text = Strings.CryptographyEssentials;
                tabBasicsBasics.Text = Strings.BasicConcepts;
                tabBasicsBlocks.Text = Strings.BlockEncryption;
                tabBasicsSymmetric.Text = Strings.SymmetricEncryption;
                tabBasicsAssymetric.Text = Strings.AsymmetricEncryption;
            // Tab for test.
            tabTest.Text = Strings.Tests;
            // Tabs for second part of theory.
            tabAlgorythms.Text = Strings.EncryptionAlgorithms;
                labelEncryptionText.Text = Strings.LbText;
                labelEncryptionKeyword.Text = Strings.LbKeyword;
                btnEncryptionStart.Text = Strings.BtnStart;
            // Tabs for settings.
            tabSettings.Text = Strings.LanguageSettings;
                labelLanguage.Text = Strings.LbLanguage;
        }
        
        private void comboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = comboLanguage.SelectedIndex;
            Properties.Settings.Default.Save();
            InitCaptions();
        }
    }
}
