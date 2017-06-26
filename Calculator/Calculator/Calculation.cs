using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculation
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public ArithmeticOperator Operator { get; set; }
        public bool IsEvaluable
        {
            get
            {
                return !Operator.Equals(ArithmeticOperator.NoOperator);
            }
        }

        public double GetResult()
        {
            switch (Operator)
            {
                case ArithmeticOperator.Addition:
                    return ArithmeticOperators.Addition(FirstNumber, SecondNumber);
                case ArithmeticOperator.Subtraction:
                    return ArithmeticOperators.Subtraction(FirstNumber, SecondNumber);
                case ArithmeticOperator.Multiplication:
                    return ArithmeticOperators.Multiplication(FirstNumber, SecondNumber);
                case ArithmeticOperator.Division:
                    return ArithmeticOperators.Division(FirstNumber, SecondNumber);
            }
            return -1;
        }

        public string PrintOperator()
        {
            switch (Operator)
            {
                case ArithmeticOperator.Addition:
                    return " + ";
                case ArithmeticOperator.Subtraction:
                    return " - ";
                case ArithmeticOperator.Multiplication:
                    return " * ";
                case ArithmeticOperator.Division:
                    return " / ";
            }
            return "No operator available";
        }

        public void Clean()
        {
            FirstNumber = 0;
            SecondNumber = 0;
            Operator = ArithmeticOperator.NoOperator;
        }
    }

    public enum ArithmeticOperator
    {
        NoOperator,
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
