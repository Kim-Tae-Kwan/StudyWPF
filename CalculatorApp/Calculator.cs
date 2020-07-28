using System;

namespace CalculatorApp
{
    public class Calculator
    {
        public Calculator()
        {
        }

        public  double Add(double a, double b)
        {
            double result = 0;
            result = a + b;

            return result;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiple(double a, double b)
        {
            double result = 0;
            result = a * b;

            return result;
        }

        public double Divide(double a, double b)
        {
            return a/b;
        }
    }
}