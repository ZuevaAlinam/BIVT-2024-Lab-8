using System;
namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output = Array.Empty<string>();
        
        public Blue_1(string input) : base(input) { }

        public string[] Output => _output;

        public override void Review()
        {
            string text = Input;
            if (string.IsNullOrEmpty(text))
            {
                _output = Array.Empty<string>();
                return;
            }

     
            int cntLines = 0;
            int first = 0;

            while (first < text.Length)
            {
                int length = Math.Min(50, text.Length - first);

                if (first + length < text.Length)
                {
                    int last = text.LastIndexOf(' ', first + length, length);
                    if (last > first)
                    {
                        length = last - first;
                    }
                }

                cntLines++;
                first += length;

                while (first < text.Length && text[first] == ' ')
                    first++;
            }

            _output = new string[cntLines];
            first = 0;
            int now = 0;

            while (first < text.Length)
            {
                int length = Math.Min(50, text.Length - first);

                if (first + length < text.Length)
                {
                    int lastSpace = text.LastIndexOf(' ', first + length, length);
                    if (lastSpace > first)
                    {
                        length = lastSpace - first;
                    }
                }

                _output[now] = text.Substring(first, length).Trim();
                now++;
                first += length;

                while (first < text.Length && text[first] == ' ')
                    first++;
            }
        }

        public override string ToString()
        {
            return string.Join("\r\n", _output);
        }
    }
}
