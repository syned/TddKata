using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorLib
{
    public class Calculator
    {
        readonly List<string> _delimiters = new List<string>() { ",", "\n" };
        private const string BeginAreaDelimiters = "//";
        private const char EndAreaDelimiters = '\n';
        private const char DelimiterStart = '[';
        private const char DelimiterEnd = ']';

        public int Add(string numbers)
        {
            GetDelimiters(ref numbers);

            var intNumbers = numbers.Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(Int32.Parse)
                .ToArray();

            CheckNegatives(intNumbers);

            return SumPositiveNumbersLessOrEqual1000(intNumbers);
        }

        private static int SumPositiveNumbersLessOrEqual1000(IEnumerable<int> intNumbers)
        {
            return intNumbers.Where(n => n <= 1000).Sum();
        }

        private static void CheckNegatives(IEnumerable<int> intNumbers)
        {
            var negatives = String.Join(", ", intNumbers.Where(n => n < 0).ToArray());
            if (negatives.Length > 0)
                throw new ArgumentException(String.Format("negatives not allowed {0}", negatives));
        }

        private void GetDelimiters(ref string numbers)
        {
            if (numbers.StartsWith(BeginAreaDelimiters))
            {
                var delimitersArea = numbers.Substring(BeginAreaDelimiters.Length, numbers.IndexOf(EndAreaDelimiters) - BeginAreaDelimiters.Length);
                _delimiters.AddRange(delimitersArea.Split(new[] { DelimiterStart, DelimiterEnd }, StringSplitOptions.RemoveEmptyEntries).ToArray());
                numbers = numbers.Remove(0, numbers.IndexOf(EndAreaDelimiters));
            }            
        }
    }
}