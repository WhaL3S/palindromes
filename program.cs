class Program
    {
        static string Palindrome(string myLine, char[] delimiters, ref int counter)
        {
            string[] words = myLine.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string palindrome = "";
            foreach (string word in words)
            {
                StringBuilder reversed = new StringBuilder();
                for (int i = word.Length - 1 ; i >= 0; i--)
                {
                    reversed.Append(word[i]);
                }
                if (reversed.ToString().ToUpper() == word.ToUpper())
                {
                    palindrome = word;
                    counter++;
                }
            }
            return palindrome;
        }
        static void Process(string fd, string fa, char[] delimeteres)
        {
            using (StreamReader reader = new StreamReader(fd))
            {
                using (StreamWriter writer = new StreamWriter(fa, false))
                {
                    string top = new string('-', 39);
                    writer.WriteLine(top);
                    writer.WriteLine("| Line number | Number of palindromes |");
                    writer.WriteLine(top);
                    string line;
                    int sum = 0;
                    int counter = 0;
                    int lineCounter = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lineCounter++;
                        string palindrome = Palindrome(line, delimeteres, ref counter);
                        writer.WriteLine("| {0, 11} | {1, 21} |", lineCounter, counter);
                        sum = sum + counter;
                        counter = 0;
                    }
                    writer.WriteLine(top);
                    writer.WriteLine();
                    writer.WriteLine("The total number of palindromes: " + sum);
                }
            }
        }
        const string CFd = "Data.txt";
        const string CFa = "Analysis.txt";
        static void Main(string[] args)
        {
            char[] delimeters = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            Process(CFd, CFa, delimeters);
        }
    }
