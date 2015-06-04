using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

using System.Resources;

namespace EncryptionStudy
{
    public partial class MainForm : Form
    {
        string locale = "En";
        public MainForm()
        {
            InitializeComponent();

            // Load language.
            comboLanguage.SelectedIndex = Properties.Settings.Default.Language;
            InitCaptions();
        }

        private void InitCaptions()
        {
            // Load language.
            if (Properties.Settings.Default.Language == 0)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
                locale = "En";
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
                locale = "Ru";
            }

            // Buttons.
            btnEncryptionStart.Text = Strings.BtnStart;
            btnCheck.Text = Strings.BtnCheck;

            // Labels.
            labelEncryptionKeyword.Text = Strings.LbKeyword;
            labelEncryptionText.Text = Strings.LbText;
            labelLanguage.Text = Strings.LbLanguage;

            // Tabs.
            tabAlgorythms.Text = Strings.EncryptionAlgorithms;
            tabBasics.Text = Strings.CryptographyEssentials;
            tabBasicsAssymetric.Text = Strings.AsymmetricEncryption;
            tabBasicsBasics.Text = Strings.Exordium;
            tabBasicsBlocks.Text = Strings.BlockEncryption;
            tabBasicsConcepts.Text = Strings.BasicConcepts;
            tabBasicsSymmetric.Text = Strings.SymmetricEncryption;
            tabSettings.Text = Strings.LanguageSettings;
            tabTest.Text = Strings.Tests;

            // Load the first part of the theory and test.
            LoadTheory();
            LoadTest();
        }

        //Load the first part of the theory
        private void LoadTheory()
        {
            boxBasics.LoadFile("Exordium " + locale + ".rtf");
            boxBasicsConcepts.LoadFile("Basic concepts " + locale + ".rtf");
            boxBlockEncryption.LoadFile("Block encryption " + locale + ".rtf");
            boxSymmetricEncryption.LoadFile("Symmetric encryption " + locale + ".rtf");
            boxAsymmetricEncryption.LoadFile("Asymmetric encryption " + locale + ".rtf");
        }

        //Load test
        private void LoadTest()
        {
            Label[] questions = { lbQuestion1, lbQuestion2, lbQuestion3, lbQuestion4, lbQuestion5, lbQuestion6, lbQuestion7, lbQuestion8, lbQuestion9, lbQuestion10 };
            RadioButton[,] answers = { {answer1_1, answer1_2, answer1_3},
                                       {answer2_1, answer2_2, answer2_3},
                                       {answer3_1, answer3_2, answer3_3},
                                       {answer4_1, answer4_2, answer4_3},
                                       {answer5_1, answer5_2, answer5_3},
                                       {answer6_1, answer6_2, answer6_3},
                                       {answer7_1, answer7_2, answer7_3},
                                       {answer8_1, answer8_2, answer8_3},
                                       {answer9_1, answer9_2, answer9_3},
                                       {answer10_1, answer10_2, answer10_3}};

            string[] questionStrings = new string[20] {Tests.Question1 ,Tests.Question2, Tests.Question3, Tests.Question4, Tests.Question5, Tests.Question6, Tests.Question7, Tests.Question8, Tests.Question9, Tests.Question10, Tests.Question11, Tests.Question12, Tests.Question13, Tests.Question14, Tests.Question15, Tests.Question16, Tests.Question17, Tests.Question18, Tests.Question19, Tests.Question20};
            
            string[,] answerStrings = new string[20,3]
                {{Tests.Answer1_1, Tests.Answer1_2, Tests.Answer1_3}, 
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

            int count = 0;
            bool[] boolarray = new bool[20];
            while (count < 10)
            {
                int rand = new Random().Next(0,19);
                if (!boolarray[rand])
                {
                    questions[count].Text = questionStrings[rand];
                    answers[count, 0].Text = answerStrings[rand, 0];
                    answers[count, 1].Text = answerStrings[rand, 1];
                    answers[count, 2].Text = answerStrings[rand, 2];
                    boolarray[rand] = true;
                    count++;
                }
            }
        }

        //Checking of test results
        private void CheckResult()
        {
            Label[] questions = { lbQuestion1, lbQuestion2, lbQuestion3, lbQuestion4, lbQuestion5, lbQuestion6, lbQuestion7, lbQuestion8, lbQuestion9, lbQuestion10 };
            RadioButton[,] answers = { {answer1_1, answer1_2, answer1_3},
                                       {answer2_1, answer2_2, answer2_3},
                                       {answer3_1, answer3_2, answer3_3},
                                       {answer4_1, answer4_2, answer4_3},
                                       {answer5_1, answer5_2, answer5_3},
                                       {answer6_1, answer6_2, answer6_3},
                                       {answer7_1, answer7_2, answer7_3},
                                       {answer8_1, answer8_2, answer8_3},
                                       {answer9_1, answer9_2, answer9_3},
                                       {answer10_1, answer10_2, answer10_3}};
            string[] rightAnswers = new string[10] { Tests.Question1Answer, Tests.Question2Answer, Tests.Question3Answer, Tests.Question4Answer, Tests.Question5Answer, Tests.Question6Answer, Tests.Question7Answer, Tests.Question8Answer, Tests.Question9Answer, Tests.Question10Answer };

            int points = 0;
            for (int i = 0; i < 10; i++)
            {
                if (answers[i, Convert.ToInt16(rightAnswers[i])].Checked)
                    points++;
            }

            if (locale == "Ru")
            {
                MessageBox.Show("Количество набранных баллов: " + points.ToString());
                if (points >= 8)
                    MessageBox.Show("Вы набрали необходимое количество баллов для перехода ко второй части обучения");
                else
                    MessageBox.Show("Вы не набрали необходимое количество баллов для перехода ко второй части обучения");
            }
            else
            { 
                MessageBox.Show("Number of points: " + points.ToString());
                if (points >= 8)
                    MessageBox.Show("You collect the necessary points to move to the second part of learning");
                else
                    MessageBox.Show("You did not collect the necessary points to move to the second part of learning");
            }
        }
        
        //Change the language
        private void comboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = comboLanguage.SelectedIndex;
            Properties.Settings.Default.Save();
            InitCaptions();
        }

        //Test button 
        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckResult();
        }

        //Load the second part of the theory.
        private void ComboEncryption_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboEncryption.SelectedIndex)
            {
                case 0:
                {
                    boxEncryptionAlgorithm.LoadFile("Ceasar " + locale + ".rtf");
                    break;
                }
                case 1:
                {
                    boxEncryptionAlgorithm.LoadFile("Ceasar Afine " + locale + ".rtf");
                    break;
                }
                case 2:
                {
                    boxEncryptionAlgorithm.LoadFile("Ceasar Keyword " + locale + ".rtf");
                    break;
                }
                case 3:
                {
                    boxEncryptionAlgorithm.LoadFile("Visioner " + locale + ".rtf");
                    break;
                }
                case 4:
                {
                    boxEncryptionAlgorithm.LoadFile("Playfer " + locale + ".rtf");
                    break;
                }
                case 5:
                {
                    boxEncryptionAlgorithm.LoadFile("Magical square " + locale + ".rtf");
                    break;
                }
                case 6:
                {
                    boxEncryptionAlgorithm.LoadFile("Encryption tables " + locale + ".rtf");
                    break;
                }
                case 7:
                {
                    boxEncryptionAlgorithm.LoadFile("DES " + locale + ".rtf");
                    break;
                }
                case 8:
                {
                    boxEncryptionAlgorithm.LoadFile("RSA " + locale + ".rtf");
                    break;
                }
            }
        }
        
        //Language for encryption examples
        string Alphabet;
        private void comboEncryptionLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (comboEncryptionLanguage.SelectedIndex)
            {
            case 0: 
                { 
                    Alphabet = "abcdefghijklmnopqrstuvwxyz";
                    break; 
                }
            case 1: 
                { 
                    Alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
                    break; 
                }
            }
        }

        //Encryption algorithms
        private void CeasarEncryption()
        {
            int s = 0, k = 0;
            try { k = Convert.ToInt32(inputEncryptionKeyword); }
            catch { MessageBox.Show("В ключе должно быть введено число!"); }

            for (int i = 0; i < inputEncryptionText.Text.Length; i++)
            {
                if (inputEncryptionText.Text[i] != ' ')
                {
                    for (int j = 0; j < Alphabet.Length; j++)
                    {
                        if (Alphabet[j] == inputEncryptionText.Text[i])
                        {
                            s = j + k;
                            s = s % Alphabet.Length;
                            boxExamplesEncryption.Text = Alphabet[s];
                        }
                    }
                }
            }
        }

        private void AfineCeasarEncryption()
        {
            int s = 0, k = 0, a = 0, n =0;
            try 
            { 
                k = Convert.ToInt32(inputEncryptionKeyword);
                a = Convert.ToInt32(inputAkeyAfinEncryption);
            }
            catch { MessageBox.Show("В ключах должны быть введены числа!"); }

            if (comboEncryptionLanguage.SelectedIndex == 0)
                n = 25;
            else
                n = 31;
            
            for (int i = 0; i < inputEncryptionText.Text.Length; i++)
            {
                if (inputEncryptionText.Text[i] != ' ')
                {
                    for (int j = 0; j < Alphabet.Length; j++)
                    {
                        if (Alphabet[j] == inputEncryptionText.Text[i])
                        {
                            s = j + k;
                            s = s % Alphabet.Length;
                            boxExamplesEncryption.Text = Alphabet[(a*s + k) % n];
                        }
                    }
                }
            }
        }

        private void CeasarKeywordEncryption()
        {
            
        }

        private void VisionerEncryption()
        { 
        
        }

        private void PlayferEncryption()
        { 
        
        }

        private void MagicalSquareEncryption()
        { 
        
        }

        private void EncryptionTables()
        { 
        
        }

        private void DesEncryption()
        { 
        
        }

        private void RsaEncryption()
        { 
        
        }

        //Load examples of encryptions
        private void btnEncryptionStart_Click(object sender, EventArgs e)
        {
            if (locale == "RU")
            {
                if (inputEncryptionKeyword.MaxLength > 20 && inputEncryptionText.MaxLength > 30)
                    MessageBox.Show("Вы ввели слишком много символом в текст или ключ");
            }
            else
            {
                if (inputEncryptionKeyword.MaxLength > 20 && inputEncryptionText.MaxLength > 30)
                    MessageBox.Show("You entered too many characters in text or in key");
            }
           
            switch (ComboEncryption.SelectedIndex)
            {
                case 0:
                {
                    CeasarEncryption();
                    break;
                }
                case 1:
                {
                    AfineCeasarEncryption();
                    lbAkeyAfin.Visible = true;
                    inputAkeyAfinEncryption.Visible = true;
                    break;
                }
                case 2:
                {
                    CeasarKeywordEncryption();
                    break;
                }
                case 3:
                {
                    VisionerEncryption();
                    break;
                }
                case 4:
                {
                    PlayferEncryption();
                    break;
                }
                case 5:
                {
                    MagicalSquareEncryption();
                    break;
                }
                case 6:
                {
                    EncryptionTables();
                    break;
                }
                case 7:
                {
                    DesEncryption();
                    break;
                }
                case 8:
                {
                    RsaEncryption();
                    break;
                }
            }
        }
    }
}
