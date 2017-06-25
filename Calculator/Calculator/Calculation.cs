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
        public ArithmeticOperation Operation { get; set; }
        public bool IsEvaluable
        {
            get
            {
                return !Operation.Equals(ArithmeticOperation.NoOperation);
            }
        }

        public double GetResult()
        {
            switch (Operation)
            {
                case ArithmeticOperation.Addition:
                    return ArithmeticOperators.Addition(FirstNumber, SecondNumber);
                case ArithmeticOperation.Subtraction:
                    return ArithmeticOperators.Subtraction(FirstNumber, SecondNumber);
                case ArithmeticOperation.Multiplication:
                    return ArithmeticOperators.Multiplication(FirstNumber, SecondNumber);
                case ArithmeticOperation.Division:
                    return ArithmeticOperators.Division(FirstNumber, SecondNumber);
            }
            return -1;
        }

        public string PrintOperator()
        {
            switch (Operation)
            {
                case ArithmeticOperation.Addition:
                    return " + ";
                case ArithmeticOperation.Subtraction:
                    return " - ";
                case ArithmeticOperation.Multiplication:
                    return " * ";
                case ArithmeticOperation.Division:
                    return " / ";
            }
            return "No operation available";
        }

        public void Clean()
        {
            FirstNumber = 0;
            SecondNumber = 0;
            Operation = ArithmeticOperation.NoOperation;
        }
    }

    public enum ArithmeticOperation
    {
        NoOperation,
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
