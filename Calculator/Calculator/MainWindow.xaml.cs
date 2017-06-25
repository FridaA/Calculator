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
    /// </summary>
    public partial class MainWindow : Window
    {
        private string number;
        private Calculation calculation = new Calculation();
        private bool cleanMessageDisplay = true;

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
            AddOperation(ArithmeticOperation.Addition);
            PrintOperation();
        }

        private void SubtractionButton_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(ArithmeticOperation.Subtraction);
            PrintOperation();
        }

        private void MultiplicationButton_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(ArithmeticOperation.Multiplication);
            PrintOperation();
        }

        private void DivisionButton_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(ArithmeticOperation.Division);
            PrintOperation();
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            calculation.SecondNumber = Int32.Parse(number);
            number = string.Empty;

            double result = calculation.GetResult();
            if (calculation.Operation.Equals(ArithmeticOperation.Division) && result == -1)
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
                cleanMessageDisplay = false;
            }
            else
            {
                MessageDisplay.Text += nr.ToString();
            }
        }

        private void AddOperation(ArithmeticOperation op)
        {
            if (calculation.IsEvaluable)
            {
                ResultDisplay.Text = "No! Only one arithmetic operation is allowed.";
            }
            else if (!string.IsNullOrEmpty(number))
            {
                calculation.FirstNumber = double.Parse(number);
                number = string.Empty;

                calculation.Operation = op;
            }
            else
            {
                MessageDisplay.Text = "Please enter a number";
            }
        }

        private void PrintOperation()
        {
            if (!calculation.Operation.Equals(ArithmeticOperation.NoOperation))
            {
                MessageDisplay.Text += calculation.PrintOperator();
            }
        }
    }
}
