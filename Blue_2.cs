using Lab_8;
using System;
public class Blue_2 : Blue
{
        private string _search;
        private string _output;
        public string Output => _output;

        public Blue_2(string input, string search) : base(input)
        {
            _search = search;
            _output = null;
        }        


        public override void Review()
        {
            _output = Input;

            while (true)
            {
                (int first, int last) = SearchBy(_output, _search);
                if (first == -1) break;

                _output = Udal(_output, first, last);
                if (first == 0)
                {
                    if (Char.IsWhiteSpace(_output[0]))
                    {
                        _output = _output.Remove(0, 1);
                    }
                }
                else
                {
                    if (Char.IsWhiteSpace(_output[first - 1]))
                    {
                        _output = _output.Remove(first - 1, 1);
                    }
                }
            }
        }

    private (int, int) SearchBy(string str, string search)
    {
        if (String.IsNullOrEmpty(str) || String.IsNullOrEmpty(search)) return (-1, 0);

        (int start, int end) = Searching(str, 0);

        while (end < str.Length)
        {
            string word = str.Substring(start, end - start + 1);
            if (word.Contains(search)) return (start, end);
            (start, end) = Searching(str, end + 1);
        }
        return (start, end);
    }


    private (int, int) Searching(string str, int ind)
    {
        if (String.IsNullOrEmpty(str) || ind < 0 || ind > str.Length - 1) return (-1, str.Length);

        int first = ind;
        while (first < str.Length && !Char.IsLetter(str[first]))
        {
            first++;
        }
        if (first == str.Length) return (-1, str.Length);

        int last = first;
        while (last < str.Length && (Char.IsLetter(str[last]) || str[last] == '\'') || str[last] == '-')
        {
            last++;
        }
        last--;
        return (first, last);
    }


    private string Udal(string str, int firstind, int lastind)
    {
        if (firstind < 0 || lastind > str.Length - 1) return str;
        return str.Remove(firstind, lastind - firstind + 1);
    }

    public override string ToString()
        {
            if (String.IsNullOrEmpty(Output)) return null;
            return Output;
        }
    }
