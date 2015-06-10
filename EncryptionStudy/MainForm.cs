﻿using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.Office.Interop.Word;

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
            btnDESSelect.Text = Strings.btnDesSelFile;
         
            // Labels.
            labelEncryptionKeyword.Text = Strings.LbKeyword;
            labelEncryptionText.Text = Strings.LbText;
            labelLanguage.Text = Strings.LbLanguage;
            labelStrEncryptionTables.Text = Strings.LbStrEncTables;
            labelStolbEncryptionTables.Text = Strings.LbStoEncTables;
            labelKey.Text = Strings.LbKey;

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
            /*Application application = new Application();
	        //Document document = application.Documents.Open("C:\\word.doc");
            int count = document.Words.Count;
	        for (int i = 1; i <= count; i++)
	        {
	            // Write the word.
	            string text = document.Words[i].Text;
                boxBasics.Text += text;
	        }
	        // Close word.
	        application.Quit();*/
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
            //Массив всех вопросов
            string[] questionStrings = new string[20] {Tests.Question1 ,Tests.Question2, Tests.Question3, Tests.Question4, Tests.Question5, Tests.Question6, Tests.Question7, Tests.Question8, Tests.Question9, Tests.Question10, Tests.Question11, Tests.Question12, Tests.Question13, Tests.Question14, Tests.Question15, Tests.Question16, Tests.Question17, Tests.Question18, Tests.Question19, Tests.Question20};
            //Массив всех ответов
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
            while (count < 10)//Вывод ответов на рандомные вопросы
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
            //Правильные ответы
            string[] rightAnswers = new string[10] { Tests.Question1Answer, Tests.Question2Answer, Tests.Question3Answer, Tests.Question4Answer, Tests.Question5Answer, Tests.Question6Answer, Tests.Question7Answer, Tests.Question8Answer, Tests.Question9Answer, Tests.Question10Answer };

            int points = 0;
            for (int i = 0; i < 10; i++)//Проверка правильного ответа
            {
                if (answers[i, Convert.ToInt16(rightAnswers[i])].Checked)
                    points++;
            }

            if (locale == "Ru")//Вывод результата
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
            switch (ComboEncryption.SelectedIndex)//Выбор теории
            {
                case 0:
                {
                    boxEncryptionAlgorithm.LoadFile("Ceasar " + locale + ".rtf");
                    settingsVisibleFalse();
                    labelEncryptionKeyword.Visible = true;
                    inputEncryptionKeyword.Visible = true;
                    comboEncryptionLanguage.Visible = true;
                    labelEncryptionText.Visible = true;
                    inputEncryptionText.Visible = true;
                    break;
                }
                case 1:
                {
                    boxEncryptionAlgorithm.LoadFile("Ceasar Afine " + locale + ".rtf");
                    settingsVisibleFalse();
                    labelEncryptionKeyword.Visible = true;
                    inputEncryptionKeyword.Visible = true;
                    comboEncryptionLanguage.Visible = true;
                    labelEncryptionText.Visible = true;
                    inputEncryptionText.Visible = true;
                    labelAkeyAfin.Visible = true;
                    inputAkeyKeyEncryption.Visible = true;
                    break;
                }
                case 2:
                {
                    boxEncryptionAlgorithm.LoadFile("Ceasar Keyword " + locale + ".rtf");
                    settingsVisibleFalse();
                    labelEncryptionKeyword.Visible = true;
                    inputEncryptionKeyword.Visible = true;
                    comboEncryptionLanguage.Visible = true;
                    labelEncryptionText.Visible = true;
                    inputEncryptionText.Visible = true;
                    labelKey.Visible = true;
                    inputAkeyKeyEncryption.Visible = true;
                    break;
                }
                case 3:
                {
                    boxEncryptionAlgorithm.LoadFile("Visioner " + locale + ".rtf");
                    settingsVisibleFalse();
                    labelEncryptionKeyword.Visible = true;
                    inputEncryptionKeyword.Visible = true;
                    comboEncryptionLanguage.Visible = true;
                    labelEncryptionText.Visible = true;
                    inputEncryptionText.Visible = true;
                    break;
                }
                case 4:
                {
                    boxEncryptionAlgorithm.LoadFile("Playfer " + locale + ".rtf");
                    settingsVisibleFalse();
                    comboEncryptionLanguage.Visible = true;
                    labelEncryptionText.Visible = true;
                    inputEncryptionText.Visible = true;
                    break;
                }
                case 5:
                {
                    boxEncryptionAlgorithm.LoadFile("Magical square " + locale + ".rtf");
                    settingsVisibleFalse();
                    comboEncryptionLanguage.Visible = true;
                    labelEncryptionText.Visible = true;
                    inputEncryptionText.Visible = true;
                    break;
                }
                case 6:
                {
                    boxEncryptionAlgorithm.LoadFile("Encryption tables " + locale + ".rtf");
                    settingsVisibleFalse();
                    comboEncryptionLanguage.Visible = true;
                    labelEncryptionText.Visible = true;
                    inputEncryptionText.Visible = true;
                    labelStrEncryptionTables.Visible = true;
                    labelStolbEncryptionTables.Visible = true;
                    boxStrEncryptionTables.Visible = true;
                    boxStolbEncryptionTables.Visible = true;
                    break;
                }
                case 7:
                {
                    boxEncryptionAlgorithm.LoadFile("DES " + locale + ".rtf");
                    settingsVisibleFalse();
                    comboEncryptionLanguage.Visible = true;
                    labelEncryptionText.Visible = true;
                    inputEncryptionText.Visible = true;
                    boxDESEncryption.Visible = true;
                    btnDESSelect.Visible = true;
                    break;
                }
                case 8:
                {
                    boxEncryptionAlgorithm.LoadFile("RSA " + locale + ".rtf");
                    settingsVisibleFalse();
                    comboEncryptionLanguage.Visible = true;
                    labelEncryptionText.Visible = true;
                    inputEncryptionText.Visible = true;
                    break;
                }
            }
        }
        
        //
        private void settingsVisibleFalse()
        {
            boxDESEncryption.Visible = false;
            btnDESSelect.Visible = false;
            labelKey.Visible = false;
            labelAkeyAfin.Visible = false;
            inputAkeyKeyEncryption.Visible = false;
            labelStrEncryptionTables.Visible = false;
            labelStolbEncryptionTables.Visible = false;
            boxStrEncryptionTables.Visible = false;
            boxStolbEncryptionTables.Visible = false;
            labelEncryptionKeyword.Visible = false;
            inputEncryptionKeyword.Visible = false;
            labelEncryptionText.Visible = false;
            inputEncryptionText.Visible = false;
            comboEncryptionLanguage.Visible = false;
                    
        }

        //Language for encryption examples
        string Alphabet;
        string [,] encriptionMatrix;
        private void comboEncryptionLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (comboEncryptionLanguage.SelectedIndex)//Выбор алфавита
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
        private void CeasarEncryption()//Шифр Цезаря
        {
            int s = 0, k = 0;
            try { k = Convert.ToInt32(inputEncryptionKeyword.Text); } //Ввод ключа и его проверка
            catch { MessageBox.Show("В ключе должно быть введено число!"); }

            for (int i = 0; i < inputEncryptionText.Text.Length; i++) 
            {
                if (inputEncryptionText.Text[i] != ' ')//Шифрование, пока не равно пробелу
                {
                    for (int j = 0; j < Alphabet.Length; j++)
                    {
                        if (Alphabet[j] == inputEncryptionText.Text[i])//Поиск совпадения и вывод результата
                        {
                            s = j + k;
                            s = s % Alphabet.Length;
                            boxExamplesEncryption.Text += Alphabet[s].ToString();
                        }
                    }
                }
            }
        }

        private void AfineCeasarEncryption()//Афинский шифр Цезаря
        {
            int s = 0, k = 0, a = 0, n =0;
            try //Ввод ключей и их проверка
            { 
                k = Convert.ToInt32(inputEncryptionKeyword.Text);
                a = Convert.ToInt32(inputAkeyKeyEncryption.Text);
            }
            catch { MessageBox.Show("В ключах должны быть введены числа!"); }

            if (comboEncryptionLanguage.SelectedIndex == 0)//Нумирация букв алфавита идет с нуля
                n = 25;
            else
                n = 31;
            
            for (int i = 0; i < inputEncryptionText.Text.Length; i++)
            {
                if (inputEncryptionText.Text[i] != ' ')//Шифрование, пока не равно пробелу
                {
                    for (int j = 0; j < Alphabet.Length; j++)
                    {
                        if (Alphabet[j] == inputEncryptionText.Text[i])//Поиск совпадения и вывод результата
                        {
                            s = j + k;
                            s = s % Alphabet.Length;
                            boxExamplesEncryption.Text += Alphabet[(a*s + k) % n].ToString();
                        }
                    }
                }
            }
        }

        private void CeasarKeywordEncryption()//Шифр Цезаря с ключевым словом
        {
            int key = 0, i = 0;
            string alf2 = "";
            string text;
            string keyWord = "";
            bool pro = false;

            text = inputEncryptionText.Text;

            while (pro == false)
            {
                try { key = Convert.ToInt32(inputAkeyKeyEncryption.Text); } //Ввод ключа и его проверка
                catch { MessageBox.Show("В данное поле должно быть введено число!"); }

                char let = 'а';
                for (int count = 0; count < key % 31; count++)
                {
                    alf2 += let;
                    let++;
                }

                try { keyWord = inputEncryptionKeyword.Text; }
                catch
                { MessageBox.Show("В данное поле должно быть введено слово!"); }

                    int k = alf2.Length;
                    while (k < Alphabet.Length)
                    {
                        i = 0;
                        while (i < keyWord.Length)
                        {
                            bool sym = true;
                            for (int j = 0; j < alf2.Length; j++)
                            {
                                if (alf2[j] == keyWord[i])
                                {
                                    sym = false;
                                    break;
                                }
                            }
                            if (sym)
                            {
                                alf2 += keyWord[i];
                                k++;
                            }
                            else
                            {
                                sym = true;
                                for (int j = 0; j < alf2.Length; j++)
                                {
                                    if (alf2[j] == let)
                                    {
                                        sym = false;
                                        break;
                                    }
                                }
                                if (sym)
                                {
                                    alf2 += let;
                                }
                                let++;
                                k++;
                            }
                            i++;
                        }
                    }
                    pro = true;
                }

                text = text.ToLower();

                for (i = 0; i < text.Length; i++)
                {
                    if (text[i] != ' ')
                    {
                        for (int j = 0; j < Alphabet.Length; j++)
                        {
                            if (Alphabet[j] == text[i])
                            {
                                boxExamplesEncryption.Text += alf2[j];
                            }
                        }
                    }
                }
            }

        private void VisionerEncryption()//Шифр Вижинера
        { 
            string s = ""; //Строка, к которой применяется шифрования
            string result = ""; //Строка - результат шифрования
            string key = ""; //Строка - ключ шифра
            string key_on_s = ""; //Ключ длиной строки
            int x = 0, y = 0; //Координаты нового символа из таблицы Виженера
            int registr = 0; //Регистр символа
            char dublicat; //Дубликат прописной буквы

            //Формирование таблицы Виженера
            int shift = 0;
            char[,] tabula_recta = new char[Alphabet.Length, Alphabet.Length]; //Таблица Виженера
            //Формирование таблицы
            for (int i = 0; i < Alphabet.Length; i++)
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    shift = j + i;
                    if (shift >= Alphabet.Length) shift = shift % Alphabet.Length;
                    tabula_recta[i, j] = Alphabet[shift];
                }
            //Объявление флага, для считывания ключа
            bool flag = false;
            //Пока не будет введен ключ из разрешенных символов (прописные и строчные буквы кирилицы)
            while (flag != true)
            {
                flag = true;
                //Считывание строки
                key = inputEncryptionKeyword.Text;
                //Цикл по каждому элементу ключа
                for (int i = 0; i < key.Length; i++)
                {
                    //Если элемент ключа не принадлежит алфавиту кирилицы, изменить флаг
                    if ((Convert.ToInt16(key[i]) < 1072) || (Convert.ToInt16(key[i]) > 1103))
                        flag = false;
                }
                //Если ключ имеет запрещенные символы, то сообщение об ошибке
                if (flag == false)
                    MessageBox.Show("Ключ имеет запрещенные символы, повторите ввод");
            }
                //Считывание строки
                s = inputEncryptionText.Text;
                //Выполение шифрования
                //Формирование строки, длиной шифруемой, состоящей из повторений ключа
                for (int i = 0; i < s.Length; i++)
                {
                    key_on_s += key[i % key.Length];
                }
                //Шифрование при помощи таблицы
                for (int i = 0; i < s.Length; i++)
                {
                    //Если не кириллица
                    if (((int)(s[i]) < 1040) || ((int)(s[i]) > 1103))
                        result += s[i];
                    else
                    {
                        //Поиск в первом столбце строки, начинающейся с символа ключа
                        int l = 0;
                        flag = false;
                        //Пока не найден символ
                        while ((l < Alphabet.Length) && (flag == false))
                        {
                            //Если символ найден
                            if (key_on_s[i] == tabula_recta[l, 0])
                            {
                                //Запоминаем в х номер строки
                                x = l;
                                flag = true;
                            }
                            l++;
                        }
                        //Уменьшаем временно регистр прописной буквы
                        if ((Convert.ToInt16(s[i]) < 1072) && (Convert.ToInt16(s[i]) >= 1040))
                        {
                            dublicat = Convert.ToChar(Convert.ToInt16(s[i]) + Alphabet.Length);
                            registr = 1;
                        }
                        else
                        {
                            registr = 0;
                            dublicat = s[i];
                        }
                        l = 0;
                        flag = false;
                        //Пока не найден столбец в первой строке с символом строки
                        while ((l < Alphabet.Length) && (flag == false))
                        {
                            //Проверка совпадения
                            if (dublicat == tabula_recta[0, l])
                            {
                                //Запоминаем номер столбца
                                y = l;
                                flag = true;
                            }
                            l++;
                        }
                        //Увеличиваем регистр буквы до прописной
                        if (registr == 1)
                        {
                            //Изменяем символ на первоначальный регистр
                            dublicat = Convert.ToChar(Convert.ToInt16(tabula_recta[x, y]) - Alphabet.Length);
                            result += dublicat;
                        }
                        else
                            result += tabula_recta[x, y];
                        }
                //Вывод на экран зашифрованной строки
                boxExamplesEncryption.Text = result; //Вывод результа
            } 
        }

        private void PlayferEncryption()//Шифр Плейфера
        { 
            //матрица алфавита шифрования
            string[,] encriptionMatrix =
                                         {
                                         {"А", "Ч", "Б", "М", "Ц", "В"}, 
                                         {"Ь", "Г", "Н", "Ш", "Д", "О"}, 
                                         {"Е", "Щ", ",", "Х", "У", "П"}, 
                                         {".", "З", "Ъ", "Р", "И", "Й"}, 
                                         {"С", "-", "К", "Э", "Т", "Л"}, 
                                         {"Ю", "Я", " ", "Ы", "Ф", "Ж"}  
                                         };
            
            string text = ""; //исходный текст для шифрования
            int i_first = 0, j_first = 0;  //координаты первого символа 
            int i_second = 0, j_second = 0;//координаты второго символа 
            string  s1 = "", s2 = ""; //строки для хранения зашифрованного символа 
            string encodetString = ""; //зашифрованая строка
         
            text = Convert.ToString(inputEncryptionText.Text).ToUpper();
            int t = text.Length; //длина входного слова
                int i, j;
                //проверяем, четное ли число символов в строке
                int temp = t % 2;
                if (temp != 0) //если нет
                {               //то добавляем в конец строки символ " " 
                    text = text.PadRight((t + 1), ' ');
                } 

                 int len = text.Length / 2; /*длина нового массива -
                                                равная половине длины входного слова
                                                 т.к. в новом масиве каждый элемент будет
                                                   содержать 2 элемента из старого массива*/

            string[] str = new string[len]; //новый массив

            int l = -1; //служебная переменная

            for (i = 0; i < t; i += 2) //в старом массиве шаг равен 2
            {
                l++; //индексы для нового массива
                if (l < len)
                {
                    //Элемент_нового_массива[i] =  Элемент_старого_массива[i] +  Элемент_старого_массива[i+1]
                    str[l] = Convert.ToString(text[i]) + Convert.ToString(text[i + 1]);
                }

            }

            //координаты очередного найденного символа из каждой пары

            foreach (string both in str)
            {
                for (i = 0; i < 6; i++)
                {
                    for (j = 0; j < 6; j++)
                    {
                        //координаты первого символа пары в исходной матрице
                        if (both[0] == Convert.ToChar(encriptionMatrix[i, j]))
                        {
                            i_first = i;
                            j_first = j;
                           
                        }

                        //координаты второго символа пары в исходной матрице
                        if (both[1] == Convert.ToChar(encriptionMatrix[i, j]))
                        {
                            i_second = i;
                            j_second = j;
                           
                        }
                    }
                }

                //если пара символов находится в одной строке
                if (i_first == i_second)
                {
                    if (j_first == 5) /*если символ последний в строке,
                                       кодируем его первым символом из матрицы*/
                    {
                        s1 = Convert.ToString(encriptionMatrix[i_first, 0]);
                    }
                    //если символ не последний, кодируем его стоящим справа от него
                    else
                    {
                        s1 = Convert.ToString(encriptionMatrix[i_first, j_first + 1]);
                    }

                    if (j_second == 5) /*если символ последний в строке
                                       кодируем его первым символом из матрицы*/
                    {
                        s2 = Convert.ToString(encriptionMatrix[i_second, 0]);
                    }
                    //если символ не последний, кодируем его стоящим справа от него
                    else
                    {
                        s2 = Convert.ToString(encriptionMatrix[i_second, j_second + 1]);
                    }

                }

                //если пара символов находится в одном столбце
                if (j_first == j_second)
                {
                    if (i_first == 5)
                    {
                        s1 = Convert.ToString(encriptionMatrix[0, j_first]);
                    }
                    else
                    {
                        s1 = Convert.ToString(encriptionMatrix[i_first + 1, j_first]);
                    }

                    if (i_second == 5)
                    {
                        s2 = Convert.ToString(encriptionMatrix[0, j_second]);
                    }

                    else
                    {
                        s2 = Convert.ToString(encriptionMatrix[i_second + 1, j_second]);
                    }
                }

                //если пара символов находиться в разных столбцах и строках
                if (i_first != i_second && j_first != j_second)
                {

                    s1 = Convert.ToString(encriptionMatrix[i_first, j_second]);
                    s2 = Convert.ToString(encriptionMatrix[i_second, j_first]);
                }

                if (s1 == s2)
                {
                    encodetString = encodetString + s1 + "=" + s2;
                }
                else
                {

                    //записыавем результат кодирования
                    encodetString = encodetString + s1 + s2;
                }
                //Выодим результат
                boxExamplesEncryption.Text = encodetString.ToLower();
            }
        }

        private void MagicalSquareEncryption()//Шифрование магическим квадратом
        { 
            string a = "";  //Переменная в которую вводится текст, и в которую затем записывается результат
            string[,] b = new string[4, 4];     
            int[,] c = new int[4, 4];   //Магический квадрат
            string[] d = new string[16];    
            string[] g = new string[16];    
            int i = 0, j = 0, k = 0, l = 0;
            
            a = inputEncryptionText.Text;
            
            //Массив каждой ячейке которого присвоен свой номер
            c[0, 0] = 16; c[0, 1] = 3; c[0, 2] = 2; c[0, 3] = 13;
            c[1, 0] = 5; c[1, 1] = 10; c[1, 2] = 11; c[1, 3] = 8;
            c[2, 0] = 9; c[2, 1] = 6; c[2, 2] = 7; c[2, 3] = 12;
            c[3, 0] = 4; c[3, 1] = 15; c[3, 2] = 14; c[3, 3] = 1;

            while(a.Length < 16)    //Если букв меньше чем элементов в массиве 
            {
                a = a + " "; //то оставшиеся элементы массива заполняем пустыми значениями
            }

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    k = c[i, j];
                    g[k - 1] = a.Substring(l, 1);
                    l++;
                }
            }
            k = 0; 
            a = "";
            
            for(i = 0; i < 16; i++)
            {
                a = a + g[i];
            }
            boxExamplesEncryption.Text = a;
        }

        private void EncryptionTables()//Шифрование таблицей
        { 
            int a, b, i, j, k;
            string c;
            string[,] d = new string[50, 50];
            //Ввод кол-во строк, столбцов и текста
            a = Convert.ToInt32(boxStrEncryptionTables.Text);
            b = Convert.ToInt32(boxStolbEncryptionTables.Text);
            c = inputEncryptionText.Text;

            k = a * b;//Кол-во элементов массива
           
            while (c.Length < k)//Создание массива
            {
                c = c + " ";
            }

            //Заполнение массива
            k = 0;
            for (i = 0; i < a; i++)
            {
                for (j = 0; j < b; j++)
                {
                    d[j, i] = c.Substring(k, 1);
                    k++;
                }
            }

            c = "";
            
            //Вывод результата в строку
            for (i = 0; i < a; i++)
            {
                for (j = 0; j < b; j++)
                {
                    c = c + d[i, j];
                }
            }
            boxExamplesEncryption.Text = c;//Вывод результата на экран
        }

        private void DesEncryption()//DES
        { 
            //После выбора где сохранить файл с ключем
            if (saveKeyFile.ShowDialog() == DialogResult.OK)
            {
                //И после выбора куда сохранить файл
                if (saveEncFile.ShowDialog() == DialogResult.OK)
                {
                    FileStream fsFileOut = File.Create(saveEncFile.FileName);
                    // The chryptographic service provider we're going to use
                    DESCryptoServiceProvider cryptAlgorithm = new DESCryptoServiceProvider();
                    // Этот объект связывает потоки данных в криптографические значения
                    CryptoStream csEncrypt = new CryptoStream(fsFileOut, cryptAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
                    // This stream writer will write the new file
                    StreamWriter swEncStream = new StreamWriter(csEncrypt);
                    // This stream reader will read the file to encrypt
                    StreamReader srFile = new StreamReader(boxDESEncryption.Text);
                    // Loop through the file to encrypt, line by line
                    string currLine = srFile.ReadLine();
                    while (currLine != null)
                    {
                        // Write to the encryption stream
                        swEncStream.Write(currLine);
                        currLine = srFile.ReadLine();
                    }
                    // Wrap things up
                    srFile.Close();
                    swEncStream.Flush();
                    swEncStream.Close();

                    // Create the key file
                    FileStream fsFileKey = File.Create(saveKeyFile.FileName);
                    BinaryWriter bwFile = new BinaryWriter(fsFileKey);
                    bwFile.Write(cryptAlgorithm.Key);
                    bwFile.Write(cryptAlgorithm.IV);
                    bwFile.Flush();
                    bwFile.Close();
                }
            }
        }

        private void btnDESSelect_Click(object sender, EventArgs e)//Сохранение файла с зашифрованым текстом методом DES
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                boxDESEncryption.Text = openFile.FileName;
            }
        }        

        private void RsaEncryption()//RSA
        {
            try
            { 
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                byte[] dataToEncrypt = ByteConverter.GetBytes(inputEncryptionText.Text);
                byte[] encryptedData;

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Шифрование провалилось!");
            }
        }

        public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKeyInfo);
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch(CryptographicException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        //Load examples of encryptions
        private void btnEncryptionStart_Click(object sender, EventArgs e)//Обращение к методам шифрования
        {
            if (locale == "RU")//В зависимости от выбранного языка выбирается язык вывода сообщения об ошибке
            {
                if (inputEncryptionKeyword.MaxLength > 20 && inputEncryptionText.MaxLength > 50)//Ограничения на ввод текста и ключа
                    MessageBox.Show("Вы ввели слишком много символом в текст или ключ");
            }
            else
            {
                if (inputEncryptionKeyword.MaxLength > 20 && inputEncryptionText.MaxLength > 50)
                    MessageBox.Show("You entered too many characters in text or in key");
            }

           //Вызов метода шифрования
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