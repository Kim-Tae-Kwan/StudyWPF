using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            double a = 4.5, b = 2.5;

            double result = calc.Add(a, b);
            Console.WriteLine($"result = {result}");

            double result2 = calc.Subtract(a, b);
            Console.WriteLine($"result2 = {result2}");

            double result3 = calc.Multiple(a, b);
            Console.WriteLine($"result3 = {result3}");

            double result4 = calc.Divide(a, b);
            Console.WriteLine($"result4 = {result4}");
            
        }
    }
}
