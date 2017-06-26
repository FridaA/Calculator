using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Calculator with numbers 0-9 and arithmetic operations +, -, *, /. Only one 
    /// arithmetic operator can be used in one calculation. Use the buttons in the application to
    /// perform the actions.
    /// </summary>
    public partial class MainWindow : Window
    {
        private string number;
        private Calculation calculation = new Calculation();
        private bool cleanMessageDisplay = true;
        private bool printOperator = true;

        public MainWindow()
        {

            InitializeComponent();
        }

        private void ZeroButton_Click(object sender, RoutedEventArgs e)
        {
            AddToNumber("0");
            UpdateMessageDisplay(0);
        }

        private void OneButton_Click(object sender, RoutedEventArgs e)
        {
            AddToNumber("1");
            UpdateMessageDisplay(1);
        }

        private void TwoButton_Click(object sender, RoutedEventArgs e)
        {
            AddToNumber("2");
            UpdateMessageDisplay(2);
        }

        private void ThreeButton_Click(object sender, RoutedEventArgs e)
        {
            AddToNumber("3");
            UpdateMessageDisplay(3);
        }

        private void FourButton_Click(object sender, RoutedEventArgs e)
        {
            AddToNumber("4");
            UpdateMessageDisplay(4);
        }

        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            AddToNumber("5");
            UpdateMessageDisplay(5);
        }

        private void SixButton_Click(object sender, RoutedEventArgs e)
        {
            AddToNumber("6");
            UpdateMessageDisplay(6);
        }

        private void SevenButton_Click(object sender, RoutedEventArgs e)
        {
            AddToNumber("7");
            UpdateMessageDisplay(7);
        }

        private void EightButton_Click(object sender, RoutedEventArgs e)
        {
            AddToNumber("8");
            UpdateMessageDisplay(8);
        }

        private void NineButton_Click(object sender, RoutedEventArgs e)
        {
            AddToNumber("9");
            UpdateMessageDisplay(9);
        }

        private void AdditionButton_Click(object sender, RoutedEventArgs e)
        {
            AddOperator(ArithmeticOperator.Addition);
            PrintOperator();
        }

        private void SubtractionButton_Click(object sender, RoutedEventArgs e)
        {
            AddOperator(ArithmeticOperator.Subtraction);
            PrintOperator();
        }

        private void MultiplicationButton_Click(object sender, RoutedEventArgs e)
        {
            AddOperator(ArithmeticOperator.Multiplication);
            PrintOperator();
        }

        private void DivisionButton_Click(object sender, RoutedEventArgs e)
        {
            AddOperator(ArithmeticOperator.Division);
            PrintOperator();
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!calculation.IsEvaluable)
            {
                ResultDisplay.Text = "No operator defined, try again!";
                return;
            }

            if (string.IsNullOrEmpty(number))
            {
                ResultDisplay.Text = "There is nothing to compute.";
                return;
            }

            calculation.SecondNumber = Int32.Parse(number);
            number = string.Empty;

            double result = calculation.GetResult();
            if (calculation.Operator.Equals(ArithmeticOperator.Division) && result == -1)
            {
                ResultDisplay.Text = "Can not divide by zero";
            }
            else
            {
                ResultDisplay.Text = result.ToString();
            }

            calculation.Clean();
            cleanMessageDisplay = true;
        }

        private void AddToNumber(string nr)
        {
            if (string.IsNullOrEmpty(number))
            {
                number = nr;
            }
            else
            {
                number += nr;
            }
        }

        private void UpdateMessageDisplay(int nr)
        {
            if (cleanMessageDisplay)
            {
                MessageDisplay.Text = nr.ToString();
                ResultDisplay.Text = "";
                cleanMessageDisplay = false;
            }
            else
            {
                MessageDisplay.Text += nr.ToString();
            }
        }

        private void AddOperator(ArithmeticOperator op)
        {
            if (calculation.IsEvaluable)
            {
                ResultDisplay.Text = "Only one arithmetic operation per calculation is allowed.";
                printOperator = false;
            }
            else if (!string.IsNullOrEmpty(number))
            {
                calculation.FirstNumber = double.Parse(number);
                number = string.Empty;

                calculation.Operator = op;
                printOperator = true;
            }
            else
            {
                MessageDisplay.Text = "Please enter a number.";
            }
        }

        private void PrintOperator()
        {
            if (calculation.Operator.Equals(ArithmeticOperator.NoOperator))
            {
                return;
            }
            
            if (printOperator)
            {
                MessageDisplay.Text += calculation.PrintOperator();
            }
        }
    }
}
