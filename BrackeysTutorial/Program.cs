using System;
using System.Collections.Generic;
using System.Linq;


namespace BrackeysTutorial
{
    class Program
    {
        static decimal Calculation(char[] operators, string input)
        {
            List<string> splitTemp;
            decimal temp;
            decimal resultVar;
            string[] splitArray;
            var op = 'a';

            foreach (var opRaw in input)
            {
                if (!operators.Contains(opRaw)) continue;
                op = opRaw;
                break;
            }

            splitArray = input.Split(op, 2);
            splitTemp = splitArray.ToList();
            if (!Decimal.TryParse(splitTemp[1], out temp))
            {
                temp = Calculation(operators, splitTemp[1]);
                splitTemp.Remove(splitTemp[1]);
                splitTemp.Add(temp.ToString());
            }
            
            if (!decimal.TryParse(splitTemp[0].Replace(" ", ""), out resultVar)) return 0;
            switch (op)
            {
                case '*':
                    resultVar *= temp;
                    break;

                case '/':
                    resultVar /= temp;
                    break;

                case '\\':
                    resultVar /= temp;
                    break;

                case '+':
                    resultVar += temp;
                    break;

                case '-':
                    resultVar -= temp;
                    break;
            }
            return resultVar;
        }

        static void Main()
        {
            var givenOperators = new List<char>();
            if (givenOperators == null) throw new ArgumentNullException(nameof(givenOperators));
            char[] operators = { '*', '/', '\\', '-', '+' };

            Console.Write("Input an equation: ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            var result = Calculation(operators, input);
            
            Console.WriteLine(result);
        }
    }
}
