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
            //boxBasics.LoadFile("Basics En.rtf");
        }

        private void InitCaptions()
        {
            // Load language.
            if (Properties.Settings.Default.Language == 0)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            }
            else
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
            
            // Load theory.
            if (Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("ru-RU"))
            {
                boxBasics.LoadFile("Exordium Ru.rtf");
                boxBasicsConcepts.LoadFile("Basic concepts Ru.rtf");
                boxBlockEncryption.LoadFile("Block encryption Ru.rtf");
                boxSymmetricEncryption.LoadFile("Symmetric encryption Ru.rtf");
                boxAsymmetricEncryption.LoadFile("Asymmetric encryption Ru.rtf");
            }
            else
            {
                boxBasics.LoadFile("Exordium En.rtf");
                boxBasicsConcepts.LoadFile("Basic concepts En.rtf");
                boxBlockEncryption.LoadFile("Block encryption En.rtf");
                boxSymmetricEncryption.LoadFile("Symmetric encryption En.rtf");
                boxAsymmetricEncryption.LoadFile("Asymmetric encryption En.rtf");
            }

            // Tabs for first part of theory.
            tabBasics.Text = Strings.CryptographyEssentials;
                tabBasicsBasics.Text = Strings.Exordium;
                tabBasicsConcepts.Text = Strings.BasicConcepts;
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
