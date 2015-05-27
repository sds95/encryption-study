using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

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

            //Second part of theory
            if (Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("ru-RU"))
            {
                switch (ComboEncryption.SelectedIndex)
                {
                    case 0: boxEncryptionAlgorithm.LoadFile("Ceasar Ru.rtf");
                    case 1: boxEncryptionAlgorithm.LoadFile("Ceasar Afine Ru.rtf");
                    case 2: boxEncryptionAlgorithm.LoadFile("Ceasar Keyword Ru.rtf");
                    case 3: boxEncryptionAlgorithm.LoadFile("Visioner Ru.rtf");
                    case 4: boxEncryptionAlgorithm.LoadFile("Playfer Ru.rtf");
                    case 5: boxEncryptionAlgorithm.LoadFile("Magical square Ru.rtf");
                    case 6: boxEncryptionAlgorithm.LoadFile("Encryption tables Ru.rtf");
                    case 7: boxEncryptionAlgorithm.LoadFile("DES Ru.rtf");
                    case 8: boxEncryptionAlgorithm.LoadFile("RSA Ru.rtf");
                }
            }
            else
            { 
                switch (ComboEncryption.SelectedIndex)
                {
                    case 0: boxEncryptionAlgorithm.LoadFile("Ceasar En.rtf");
                    case 1: boxEncryptionAlgorithm.LoadFile("Ceasar Afine En.rtf");
                    case 2: boxEncryptionAlgorithm.LoadFile("Ceasar Keyword En.rtf");
                    case 3: boxEncryptionAlgorithm.LoadFile("Visioner En.rtf");
                    case 4: boxEncryptionAlgorithm.LoadFile("Playfer En.rtf");
                    case 5: boxEncryptionAlgorithm.LoadFile("Magical square En.rtf");
                    case 6: boxEncryptionAlgorithm.LoadFile("Encryption tables En.rtf");
                    case 7: boxEncryptionAlgorithm.LoadFile("DES En.rtf");
                    case 8: boxEncryptionAlgorithm.LoadFile("RSA En.rtf");
                 }
            }

            //Tests
            string[] question = new string[20] {Tests.Question1 ,Tests.Question2, Tests.Question3, Tests.Question4, Tests.Question5, Tests.Question6, Tests.Question7, Tests.Question8, Tests.Question9, Tests.Question10,
            Tests.Question11, Tests.Question12, Tests.Question13, Tests.Question14, Tests.Question15, Tests.Question16, Tests.Question17, Tests.Question18, Tests.Question19, Tests.Question20};
            
            string[,] answers = new string[20,3] {{Tests.Answer1_1, Tests.Answer1_2, Tests.Answer1_3}, 
            {Tests.Answer2_1, Tests.Answer2_2, Tests.Answer2_3},
            {Tests.Answer3_1, Tests.Answer3_2, Tests.Answer3_3},
            {Tests.Answer4_1, Tests.Answer4_2, Tests.Answer4_3},
            {Tests.Answer5_1, Tests.Answer5_2, Tests.Answer5_3},
            {Tests.Answer6_1, Tests.Answer6_2, Tests.Answer6_3},
            {Tests.Answer7_1, Tests.Answer7_2, Tests.Answer7_3},
            {Tests.Answer8_1, Tests.Answer8_2, Tests.Answer8_3},
            {Tests.Answer9_1, Tests.Answer9_2, Tests.Answer9_3},
            {Tests.Answer10_1, Tests.Answer10_2, Tests.Answer10_3},
            {Tests.Answer11_1, Tests.Answer11_2, Tests.Answer11_3},
            {Tests.Answer12_1, Tests.Answer12_2, Tests.Answer12_3},
            {Tests.Answer13_1, Tests.Answer13_2, Tests.Answer13_3},
            {Tests.Answer14_1, Tests.Answer14_2, Tests.Answer14_3},
            {Tests.Answer15_1, Tests.Answer15_2, Tests.Answer15_3},
            {Tests.Answer16_1, Tests.Answer16_2, Tests.Answer16_3},
            {Tests.Answer17_1, Tests.Answer17_2, Tests.Answer17_3},
            {Tests.Answer18_1, Tests.Answer18_2, Tests.Answer18_3},
            {Tests.Answer19_1, Tests.Answer19_2, Tests.Answer19_3},
            {Tests.Answer20_1, Tests.Answer20_2, Tests.Answer20_3}};

            int count = 0, s = 10;
            bool[] boolarray = new bool[20];
            
            while (count < 10)
            {
                Random rand = new Random(1-20);
                if (!boolarray[s])
                {
                    addquestion(s);
                    boolarray[s] = true;
                    count++;
                }
            }
        }
        
           
        /*
        static HashSet<int> set = new HashSet<int>();
        static Random r = new Random();
        static int a = 20;

        public static void rnd(int a)
        {
            for (int i = 0; i < a; i++)
            {
               set.Add(r.Next(0, a));
            }
            if (set.ToArray<int>().Length < a) 
            { 
                rnd(a); 
            }
        }
        private void generationQuesting()
        {
            tabTest.Controls["lbQuestion1"].Text = Tests.["Question" + set.ElementAt(1)];
        }
        */

        private void comboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = comboLanguage.SelectedIndex;
            Properties.Settings.Default.Save();
            InitCaptions();
        }
    }
}
