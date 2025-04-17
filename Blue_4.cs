using System;
namespace Lab_8
{
    public class Blue_4: Blue
    {

        private int _output;
        public int Output => _output;
        public Blue_4(string input) : base(input) { _output = 0; }

        private string WhereNumb(string str, ref int whereStart)
        {
            if (String.IsNullOrEmpty(str) || whereStart < 0 || whereStart > str.Length - 1) return null;

            string number = "";
            //int index = from;
            while (whereStart < str.Length && !Char.IsDigit(str[whereStart])) 
                whereStart++;
            if (whereStart == str.Length) return null; 
            if (whereStart != 0 && str[whereStart - 1] == '-') number += '-';
            else number += '+';

            while (whereStart < str.Length && Char.IsDigit(str[whereStart])) 
            {
                number += str[whereStart];
                whereStart++;
            }

            return number;
        }
        private int Znach(char plusOrMinus)
        {
            switch (plusOrMinus)
            {
                case '+': return 1;
                case '-': return -1;
                default: return 0;
            }
        }
        private double ToInt(string str)
        {
            if (String.IsNullOrEmpty(str)) return double.NaN;

            double chislo = 0;

            int digitNum = str.Length - 1;
            for (int k = 1; k < str.Length; k++)
            {
                int digit = (int)str[k] - (int)'0';
                chislo += digit * Math.Pow(10, (digitNum - k));
            }
            chislo *= Znach(str[0]);
            return chislo;
        }
        private void AddNumber(double number)
        {
            if (number == double.NaN) return;
            _output += (int)number;
        }
        public override void Review()
        {
            if (String.IsNullOrEmpty(Input)) return;

            int index = 0;
            while (index < Input.Length)
            {
                string strNumber = WhereNumb(Input, ref index);
                if (strNumber == null) return;
                double number = ToInt(strNumber);
                AddNumber(number);
            }
        }

        public override string ToString()
        {
            string str = $"{_output}";
            return str;
        }
    }
}


