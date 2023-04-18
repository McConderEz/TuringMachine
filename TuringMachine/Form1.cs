using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringMachine
{
    public partial class StartButton : Form
    {
        List<string> outOMT = new List<string>();
        List<string> outMMT = new List<string>();
        List<string> listOfGenWords = new List<string>();
        List<string> listOfOMTresult = new List<string>();
        List<(string,string)> listOfMMTresult = new List<(string,string)>();
        List<(int, int)> listGraphOMT = new List<(int, int)>();
        List<(int, int)> listGraphMMT = new List<(int, int)>();
        int countOMT = 0;
        int countMMT = 0;
        int maxOMT = 0;
        int maxMMT = 0;
        StringBuilder word;
        StringBuilder word2;
        bool locker = false;
        int indexTemp;
        List<int> indexesTemp = new List<int>();
        double a, b, h;
        double x, y;
        public StartButton()
        {
            InitializeComponent();
        }

        private void StartButton_Load(object sender, EventArgs e)
        {

        }

        private void InputButton_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OutPutBox.Clear();
            Regex regex = new Regex(@"[0-1]?[c][0-1]?");
            word = new StringBuilder("_"+InputWordBox.Text+"_");
            if (!regex.IsMatch(word.ToString()))
            {
                MessageBox.Show("Неверный формат строки!");
                return;
            }
            //else
            //{
            //    StartSingleTapeMT(word);
            //}
            StartSingleTapeMT(word);
        }

        private void StartSingleTapeMT(StringBuilder word)
        {
            outOMT.Clear();
            Qstart1(word, 1);
            outOMT.Add("Qz:" + word);
            for (int i = 0;i < outOMT.Count; i++)
            {
                OutPutBox.Text += outOMT[i] + Environment.NewLine;
            }
            
            Thread.Sleep(2000);
            using (var sr = new StreamWriter(File.Create("logOMT.txt")))
            {
                sr.WriteAsync(OutPutBox.Text);
            }

        }

        private void StartManyTapeMT(StringBuilder word,StringBuilder word2)
        {
            outMMT.Clear();
            MQ1(word,word2,1, 1);
            if(locker)
                MQ7(word, word2, indexesTemp[0], indexesTemp[1]);
            outMMT.Add("Qz l1:" + word);
            outMMT.Add("Qz l2:" + word2);
            for (int i = 0;i < outMMT.Count; i++)
            {
                OutPutManyBox.Text += outMMT[i] + Environment.NewLine;
            }
            
            Thread.Sleep(2000);
            using (var sr = new StreamWriter(File.Create("logMMT.txt")))
            {
                sr.WriteAsync(OutPutManyBox.Text);
            }


        }

        #region ОМТ
        private void Qstart1(StringBuilder word,int index)
        {
            outOMT.Add("Q26:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    index++;
                    Qstart1(word, index);
                    break;
                case '1':
                    index++;
                    Qstart1(word, index);
                    break;
                case 'c':
                    index++;
                    Qstart2(word, index);
                    break;
                case '_':
                    word.Clear();
                    word = new StringBuilder(new string('_', 7));
                    word[word.Length / 2] = '0';
                    outOMT.Add("Qz:" + word + Environment.NewLine);
                    return;

            }
        }

        private void Qstart2(StringBuilder word, int index)
        {
            outOMT.Add("Q27:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    index = 1;
                    Q1(word, index);
                    break;
                case '1':
                    index = 1;
                    Q1(word, index);
                    break;
                case 'c':
                    word.Clear();
                    word = new StringBuilder(new string('_', 7));
                    word[word.Length / 2] = '0';
                    outOMT.Add("Qz:" + word + Environment.NewLine);
                    return;
                case '_':
                    index=1;
                    Q1(word, index);
                    break;


            }
        }

        private void Qstart3(StringBuilder word, int index)
        {
            outOMT.Add("Q28:" + word);
            countOMT++;
            switch (word[index])
            {
                case 'c':
                    index++;
                    Qstart4(word, index);
                    break;
                case '_':
                    word.Clear();
                    word = new StringBuilder(new string('_', 7));
                    word[word.Length / 2] = '0';
                    outOMT.Add("Qz:" + word + Environment.NewLine);
                    return;


            }
        }
        private void Qstart4(StringBuilder word, int index)
        {
            outOMT.Add("Q29:" + word);
            countOMT++;
            switch (word[index])
            {
                case 'c':
                    word.Clear();
                    word = new StringBuilder(new string('_', 7));
                    word[word.Length / 2] = '0';
                    outOMT.Add("Qz:" + word + Environment.NewLine);
                    return;
                case '_':
                    index = 1;
                    Q1(word, index);
                    return;


            }
        }

        private void Q1(StringBuilder word,int index)
        {
            outOMT.Add("Q1:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    word[index] = '#';
                    index++;
                    Q2(word, index);
                    break;
                case '1':
                    word[index] = 'X';
                    index++;
                    Q2(word, index);
                    break;
                case 'c':
                    index++;
                    Q6(word, index);
                    break;
                case '_':
                    word[index] = '1';
                    index++;
                    Q2(word, index);
                    break;
            }
        }

        private void Q2(StringBuilder word,int index)
        {
            outOMT.Add("Q2:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    index++;
                    Q2(word, index);
                    break;
                case '1':
                    index++;
                    Q2(word, index);
                    break;
                case 'c':
                    index++;
                    Q3(word, index);
                    break;
            }
        }

        private void Q3(StringBuilder word, int index)
        {
            outOMT.Add("Q3:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    word[index] = '#';
                    index--;
                    Q4(word, index);
                    break;
                case '1':
                    word[index] = 'X';
                    index--;
                    Q4(word, index);
                    break;
                case 'X':
                    index++;
                    Q3(word, index);
                    break;
                case '#':                    
                    index++;
                    Q3(word, index);
                    break;
                case '_':
                    index--;
                    Q10(word, index);
                    break;
            }
        }

        private void Q4(StringBuilder word, int index)
        {
            outOMT.Add("Q4:" + word);
            countOMT++;
            switch (word[index])
            {
                case 'c':
                    index--;
                    Q5(word, index);
                    break;
                case 'X':
                    index--;
                    Q4(word, index);
                    break;
                case '#':
                    index--;
                    Q4(word, index);
                    break;
            }
        }

        private void Q5(StringBuilder word, int index)
        {
            outOMT.Add("Q5:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    index--;
                    Q5(word, index);
                    break;
                case '1':
                    index--;
                    Q5(word, index);
                    break;
                case 'X':
                    index++;
                    Q1(word, index);
                    break;
                case '#':
                    index++;
                    Q1(word, index);
                    break;
                case '_':
                    index--;
                    Q25(word, index);
                    break;
            }
        }

        private void Q6(StringBuilder word, int index)
        {
            outOMT.Add("Q6:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    index++;
                    Q7(word, index);
                    break;
                case '1':
                    index++;
                    Q7(word, index);
                    break;
                case 'X':
                    index++;
                    Q6(word, index);
                    break;
                case '#':
                    index++;
                    Q6(word, index);
                    break;
                case '_':
                    Q7(word, index);
                    break;
            }
        }

        private void Q7(StringBuilder word, int index)
        {
            outOMT.Add("Q7:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    index--;
                    Q10(word, index);
                    break;
                case '1':
                    index--;
                    Q10(word, index);
                    break;                
                case '_':
                    index--;
                    Q8(word, index);
                    break;
            }
        }

        private void Q8(StringBuilder word, int index)
        {
            outOMT.Add("Q8:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    word[index] = '_';
                    index--;
                    Q8(word, index);
                    break;
                case '1':
                    word[index] = '_';
                    index--;
                    Q8(word, index);
                    break;
                case 'c':
                    index--;
                    Q8(word, index);
                    break;
                case 'X':
                    word[index] = '_';
                    index--;
                    Q8(word, index);
                    break;
                case '#':
                    word[index] = '_';
                    index--;
                    Q8(word, index);
                    break;
                case '_':
                    index++;
                    Q9(word, index);
                    break;
            }
        }

        private void Q9(StringBuilder word, int index)
        {
            outOMT.Add("Q9:" + word);
            countOMT++;
            switch (word[index])
            {
                case 'c':
                    word[index] = '0';
                    return;
                case '_':
                    index++;
                    Q9(word, index);
                    break;
            }
        }

        private void Q10(StringBuilder word, int index)
        {
            outOMT.Add("Q10:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    index--;
                    Q10(word, index);
                    break;
                case '1':
                    index--;
                    Q10(word, index);
                    break;
                case 'c':
                    index--;
                    Q10(word, index);
                    break;
                case 'X':
                    word[index] = '1';
                    index--;
                    Q10(word, index);
                    break;
                case '#':
                    word[index] = '0';
                    index--;
                    Q10(word, index);
                    break;
                case '_':
                    index++;
                    Q11(word, index);
                    break;
            }
        }

        private void Q11(StringBuilder word, int index)
        {
            outOMT.Add("Q11:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    word[index] = 'X';
                    index++;
                    Q12(word, index);
                    break;
                case '1':
                    word[index] = 'X';
                    index++;
                    Q12(word, index);
                    break;
                case 'c':
                    index--;
                    Q13(word, index);
                    break;
                case 'X':
                    word[index] = '_';
                    index++;
                    Q11(word, index);
                    break;
                case '_':
                    word[index] = '1';
                    index++;
                    Q14(word, index);
                    break;
            }
        }

        private void Q12(StringBuilder word, int index)
        {
            outOMT.Add("Q12:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    word[index] = 'X';
                    index--;
                    Q11(word, index);
                    break;
                case '1':
                    word[index] = 'X';
                    index--;
                    Q11(word, index);
                    break;
                case 'c':
                    index--;
                    Q13(word, index);
                    break;              
            }
        }

        private void Q13(StringBuilder word, int index)
        {
            outOMT.Add("Q13:" + word);
            countOMT++;
            switch (word[index])
            {               
                case 'X':
                    word[index] = '0';
                    index++;
                    Q14(word, index);
                    break;
                case '_':
                    word[index] = '1';
                    index++;
                    Q14(word, index);
                    break;
            }
        }

        private void Q14(StringBuilder word, int index)
        {
            outOMT.Add("Q14:" + word);
            countOMT++;
            switch (word[index])
            {               
                case 'c':
                    index++;
                    Q15(word, index);
                    break;                
            }
        }

        private void Q15(StringBuilder word, int index)
        {
            outOMT.Add("Q15:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    index++;
                    Q15(word, index);
                    break;
                case '1':
                    index++;
                    Q15(word, index);
                    break;
                case '_':
                    index--;
                    Q16(word, index);
                    break;
            }
        }

        private void Q16(StringBuilder word, int index)
        {
            outOMT.Add("Q16:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    word[index] = 'X';
                    index--;
                    Q17(word, index);
                    break;
                case '1':
                    word[index] = 'X';
                    index--;
                    Q17(word, index);
                    break;
                case 'c':
                    index++;
                    Q18(word, index);
                    break;
                case 'X':
                    word[index] = '_';
                    index--;
                    Q16(word, index);
                    break;
            }
        }

        private void Q17(StringBuilder word, int index)
        {
            outOMT.Add("Q17:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    word[index] = 'X';
                    index++;
                    Q16(word, index);
                    break;
                case '1':
                    word[index] = 'X';
                    index++;
                    Q16(word, index);
                    break;
                case 'c':
                    index++;
                    Q18(word, index);
                    break;                
            }
        }

        private void Q18(StringBuilder word, int index)
        {
            outOMT.Add("Q18:" + word);
            countOMT++;
            switch (word[index])
            {                
                case 'X':
                    word[index] = '0';
                    index--;
                    Q19(word, index);
                    break;
                case '_':
                    word[index] = '1';
                    index--;
                    Q19(word, index);
                    break;
            }
        }

        private void Q19(StringBuilder word, int index)
        {
            outOMT.Add("Q19:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    word[index] = '_';
                    index++;
                    Q22(word, index);
                    break;
                case '1':
                    word[index] = '_';
                    index++;
                    Q20(word, index);
                    break;
                case 'c':
                    index--;
                    Q19(word, index);
                    break;
            }
        }

        private void Q20(StringBuilder word, int index)
        {
            outOMT.Add("Q20:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    word[index] = '_';
                    index--;
                    Q21(word, index);
                    break;
                case '1':
                    word[index] = '_';
                    index--;
                    Q24(word, index);
                    break;
                case 'c':
                    index++;
                    Q20(word, index);
                    break;
            }
        }

        private void Q21(StringBuilder word, int index)
        {
            outOMT.Add("Q21:" + word);
            countOMT++;
            switch (word[index])
            {                
                case 'c':
                    word[index] = '1';
                    return;
            }
        }

        private void Q22(StringBuilder word, int index)
        {
            outOMT.Add("Q22:" + word);
            switch (word[index])
            {
                case 'c':
                    index++;
                    Q23(word, index);
                    break;
            }
        }

        private void Q23(StringBuilder word, int index)
        {
            outOMT.Add("Q23:" + word);
            countOMT++;
            switch (word[index])
            {
                case '0':
                    word[index] = '_';
                    index--;
                    Q24(word, index);
                    break;
                case '1':
                    word[index] = '_';
                    index--;
                    Q24(word, index);
                    break;
            }
        }

        private void Q24(StringBuilder word, int index)
        {
            outOMT.Add("Q24:" + word);
            countOMT++;
            switch (word[index])
            {
                case 'c':
                    word[index] = '0';
                    return;
            }
        }

        private void Q25(StringBuilder word, int index)
        {
            outOMT.Add("Q25:" + word);
            countOMT++;
            switch (word[index])
            {
                case '1':
                    index++;
                    Q25(word, index);
                    break;
                case 'c':
                    index--;
                    Q24(word, index);
                    break;
                case 'X':
                    index--;
                    Q17(word, index);
                    break;
            }
        }
        #endregion

        #region ММТ

        //private void MQstart1(StringBuilder word, StringBuilder word2, int index1, int index2)
        //{
        //    OutPutManyBox.Text += "Q8 l1:" + word + Environment.NewLine;
        //    OutPutManyBox.Text += "Q8 l2:" + word2 + Environment.NewLine;
        //    switch (word[index1])
        //    {
        //        case '0':
        //            index1++;
        //            MQstart1(word, word2, index1, index2);
        //            break;
        //        case '1':
        //            index1++;
        //            MQstart1(word, word2, index1, index2);
        //            break;
        //        case 'c':
        //            index1++;
        //            MQstart2(word, word2, index1, index2);
        //            break;
        //        case '_':
        //            word.Clear();
        //            word = new StringBuilder(new string('_', 7));
        //            word[word.Length / 2] = '0';
        //            OutPutManyBox.Text += "Qz:" + word + Environment.NewLine;
        //            return;

        //    }
        //}

        //private void MQstart2(StringBuilder word, StringBuilder word2, int index1, int index2)
        //{
        //    OutPutManyBox.Text += "Q9 l1:" + word + Environment.NewLine;
        //    OutPutManyBox.Text += "Q9 l2:" + word2 + Environment.NewLine;
        //    switch (word[index1])
        //    {
        //        case '0':
        //            index1 = 1;
        //            MQ1(word, word2, index1, index2);
        //            break;
        //        case '1':
        //            index1 = 1;
        //            MQ1(word, word2, index1, index2);
        //            break;
        //        case 'c':
        //            word.Clear();
        //            word = new StringBuilder(new string('_', 15));
        //            word[word.Length / 2] = '0';
        //            OutPutManyBox.Text += "Qz l1:" + word + Environment.NewLine;
        //            return;
        //        case '_':
        //            index1 = 1;
        //            MQ1(word, word2, index1, index2);
        //            break;


        //    }
        //}
        private void MQ1(StringBuilder word,StringBuilder word2,int index1,int index2)
        {
            outMMT.Add("Q1 l1:" + word);
            outMMT.Add("Q1 l2:" + word2);
            countMMT++;
            switch (word[index1])
            {
                case '0':
                    word2[index2] = word[index1];
                    word[index1] = '_';
                    index1++;
                    index2++;
                    MQ1(word, word2, index1, index2);
                    break;
                case '1':
                    word2[index2] = word[index1];
                    word[index1] = '_';
                    index1++;
                    index2++;
                    MQ1(word, word2, index1, index2);
                    break;
                case 'c':
                    word[index1] = '_';
                    index1++;
                    indexTemp = index1;
                    index2 = 1;
                    MQ2(word, word2, index1, index2);
                    break;
            }
        }
        
        private void MQ2(StringBuilder word, StringBuilder word2, int index1, int index2)
        {
            outMMT.Add("Q2 l1:" + word);
            outMMT.Add("Q2 l2:" + word2);
            countMMT++;
            if ((word[index1] == '1' || word[index1] == '0') && (word2[index2] == '1' || word2[index2] == '0'))
            {
                index1++;
                index2++;
                MQ2(word, word2, index1, index2);
            }
            else if (word2[index2] == '_' && (word[index1] == '1' || word[index1] == '0')) 
            {
                index1++;
                MQ3(word, word2, index1, index2);
            }
            else
            {
                //index1 = indexTemp;
                //index2 = 1;
                locker = true;
                MQ8(word, word2, index1, index2);
                //MQ5(word, index1, 1);
                //MQ5(word2, index2, 2);
            }
        }
        
        private void MQ3(StringBuilder word,StringBuilder word2,int index1,int index2)
        {
            outMMT.Add("Q3 l1:" + word);
            outMMT.Add("Q3 l2:" + word2);
            countMMT++;
            switch (word[index1])
            {
                case '0':
                    //index1 = indexTemp;
                    //index2 = 1;
                    locker = true;
                    MQ8(word, word2, index1, index2);
                    //MQ5(word, index1,1);
                    //MQ5(word2, index2,2);
                    break;
                case '1':
                    //index1 = indexTemp;
                    //index2 = 1;
                    locker = true;
                    MQ8(word, word2, index1, index2);
                    //MQ5(word, index1,1);
                    //MQ5(word2, index2,2);
                    break;
                case '_':
                    index1--;
                    index2--;
                    Task.Run(() => MQ4(word, index1,1));
                    Task.Run(() => MQ4(word2, index2,2));
                    break;
            }
        }

        private void MQ8(StringBuilder word, StringBuilder word2, int index1, int index2)
        {
            outMMT.Add("Q8 l1:" + word);
            outMMT.Add("Q8 l2:" + word2);
            countMMT++;
            if ((word[index1] == '0' || word[index1] == '1')&& word2[index2] == '_')
            {               
                index1--;
                MQ8(word, word2, index1, index2);
            }else if ((word[index1] == '0' || word[index1] == '1') && (word2[index2] == '0' || word2[index2] == '1'))
            {
                index1--;
                index2--;
                MQ8(word, word2, index1, index2);
            }
            else if(word[index1] == '0' || word[index1] == '1')
            {
                index1--;
                MQ8(word, word2, index1, index2);
            }else if((word2[index2] == '0' || word2[index2] == '1'))
            {
                index2--;
                MQ8(word, word2, index1, index2);
            }else if (word[index1] == '_' && word2[index2] == '_')
            {
                index1++;
                index2++;
                Task.Run(() => MQ5(word, index1));
                Task.Run(() => MQ5(word, index2));
            }
        }

        private void MQ4(StringBuilder word, int index,int l)
        {
            outMMT.Add("Q4 l1:" + word);
            outMMT.Add("Q4 l2:" + word2);
            countMMT++;
            switch (word[index])
            {
                case '0':
                    word[index] = '_';
                    index--;
                    MQ4(word, index,l);
                    break;
                case '1':
                    word[index] = '_';
                    index--;
                    MQ4(word, index,l);
                    break;
                case '_':
                    word[index] = '0';
                    word2[index] = '_';
                    return;
            }
        }

        private void MQ5(StringBuilder word, int index)
        {
            outMMT.Add("Q5 l1:" + word);
            outMMT.Add("Q5 l2:" + word2);
            countMMT++;

            switch (word[index])
            {
                case '0':
                    word[index] = '_';
                    index++;
                    MQ6(word, index);
                    break;
                case '1':
                    word[index] = '_';
                    index++;
                    MQ6(word, index);
                    break;
                case '_':
                    word[index] = '1';
                    indexesTemp.Add(index);
                    return;
            }
        }

        private void MQ6(StringBuilder word,int index)
        {
            outMMT.Add("Q6 l1:" + word);
            outMMT.Add("Q6 l2:" + word2);
            countMMT++;
            switch (word[index])
            {
                case '0':
                    word[index] = '_';
                    index++;
                    MQ5(word, index);
                    break;
                case '1':
                    word[index] = '_';
                    index++;
                    MQ5(word, index);
                    break;
                case '_':
                    word[index] = '0';
                    indexesTemp.Add(index);
                    return;
            }
        }

        private void MQ7(StringBuilder word, StringBuilder word2, int index1, int index2)
        {
            outMMT.Add("Q7 l1:" + word);
            outMMT.Add("Q7 l2:" + word2);
            countMMT++;
            if (word.ToString().Contains('0') && word2.ToString().Contains('1'))
            {
                word.Replace('0', '1');
                word2.Replace('1', '_');
            }
            else
            {
                int size = word.Length;
                word.Replace('0', '_').Replace('1','_');
                word2.Replace('0', '_').Replace('1', '_');
                word[index1] = '0';
                word2[index2] = '_';                
            }
            
        }

        #endregion

        #region Генерация
        





        void GenAllWords(int length)
        {
            for (int i = 0; i <= length; i++)
            {
                GenWords(length, i);
            }
        }



        void GenWords(int length, int pos) 
        {
            int count = 0;
            int numbers = 1 << length;


            for (int i = 0; i < numbers; i++)
            {

                string binary = Convert.ToString(i, 2);
                StringBuilder leading_zeroes = new StringBuilder((new string('0', length)).Substring(0, length - binary.Length));
                StringBuilder result = leading_zeroes;
                Console.WriteLine((result + binary).Insert(pos, "c"));
                listOfGenWords.Add((result + binary).Insert(pos, "c"));
                count++;
            }
            Console.WriteLine($"Количество сгенерированных чисел: {count}");
        }
        #endregion

        private void OutPutBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OutPutManyBox.Clear();
            Regex regex = new Regex(@"[0-1]?[c][0-1]?");
            word = new StringBuilder("_" + InputWordBox.Text + new string('_',10));
            
            int size = word.Length;
            word2 = new StringBuilder(new string('_',size));
            if (!regex.IsMatch(word.ToString()))
            {
                MessageBox.Show("Неверный формат строки!");
                return;
            }
            else if (word.ToString().Contains("cc") || !word.ToString().Contains("c"))
            {
                OutPutManyBox.Text += "Q1 l1:" + word + Environment.NewLine;
                OutPutManyBox.Text += "Q1 l2:" + word2 + Environment.NewLine;
                word.Clear();
                word = new StringBuilder(new string('_', 15));
                word[word.Length / 2] = '0';
                OutPutManyBox.Text += "Qz l1:" + word + Environment.NewLine;
                OutPutManyBox.Text += "Qz l2:" + word2 + Environment.NewLine;
                return;
            }
            else
            {
                StartManyTapeMT(word,word2);
            }
        }

        private void StartGenSingleTapeMT(StringBuilder word)
        {
            countOMT = 0;
            Qstart1(word, 1);


            listOfOMTresult.Add(word.ToString());
            if (countOMT > maxOMT)
                maxOMT = countOMT;
        }

        private void StartGenManyTapeMT(StringBuilder word, StringBuilder word2)
        {
            countMMT = 0;
            MQ1(word, word2, 1, 1);
            if (locker)
                MQ7(word, word2, indexesTemp[0], indexesTemp[1]);


            listOfMMTresult.Add((word.ToString(), word2.ToString()));
            if (countMMT > maxMMT)
                maxMMT = countMMT;
        }

        private async void CreateGraph_Click(object sender, EventArgs e)
        {
            await Task.Run(() => GenOMTWord());
            Thread.Sleep(1500);
            await Task.Run(() => GenMMTWord());


            

            int i = 0;

            this.DiffGraph.Series[0].Points.Clear();
            this.DiffGraph.Series[1].Points.Clear();

            while (i != 10)
            {
                this.DiffGraph.Series[0].Points.AddXY(listGraphOMT[i].Item1, listGraphOMT[i].Item2);
                this.DiffGraph.Series[1].Points.AddXY(listGraphMMT[i].Item1, listGraphMMT[i].Item2);
                i++;
            }

        }

        public void GenOMTWord()
        {
            StringBuilder temp = new StringBuilder(' ');            
            for(int j = 1;j <= 10; j++)
            {
                GenAllWords(j);
                temp = new StringBuilder(' ');
                for (int i = 0; i < listOfGenWords.Count; i++)
                {
                    temp.Clear();
                    //int size = listOfGenWords[i].Length;
                    temp = new StringBuilder("_" + listOfGenWords[i] + "_");
                    StartGenSingleTapeMT(temp);
                }
                listOfOMTresult.Clear();
                listOfGenWords.Clear();
                listGraphOMT.Add((j, maxOMT));
                maxOMT = 0;
            }
            
        }

        public void GenMMTWord()
        {
            for (int j = 1; j <= 10; j++)
            {
                GenAllWords(j);
                StringBuilder temp = new StringBuilder(' ');
                for (int i = 0; i < listOfGenWords.Count; i++)
                {
                    temp.Clear();
                    int size = listOfGenWords[i].Length;
                    word2 = new StringBuilder(new string('_', size + 2));
                    temp = new StringBuilder("_" + listOfGenWords[i] + "_");
                    StartGenManyTapeMT(temp, word2);                  
                }
                listOfMMTresult.Clear();
                listOfGenWords.Clear();
                listGraphMMT.Add((j, maxMMT));
                maxMMT = 0;
            }

        }
    }
}
