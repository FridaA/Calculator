using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class ArithmeticOperators
    {
        public static double Addition(double a, double b)
        {
            return a + b;
        }

        public static double Subtraction(double a, double b)
        {
            return a - b;
        }

        public static double Multiplication(double a, double b)
        {
            return a * b;
        }

        public static double Division(double a, double b)
        {
            if (b == 0)
            {
                return -1;
            }

            {
                return a / b;
            }
        }
    }
}
