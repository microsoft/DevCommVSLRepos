using System;
using System.Collections.Generic;
using System.Globalization;
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
        double firstNumber, secondNumber, resultNumber = 0;
        bool calcDone = false;
        Operations operation = Operations.None;
        string separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        public MainWindow()
        {
            InitializeComponent();

            //Assign to the decimal button the separator from the current culture
            dec.Content = separator;
        }

        //List the possible numeric operations
        private enum Operations
        {
            None,
            Division,
            Multiplication,
            Subtraction,
            Sum
        }

        private void Window_KeyDownPreview(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                    Zero.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad1:
                    One.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad2:
                    Two.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad3:
                    Three.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad4:
                    Four.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad5:
                    Five.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad6:
                    Six.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad7:
                    Seven.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad8:
                    Eight.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad9:
                    Nine.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Decimal:
                    dec.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Add:
                    Plus.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Subtract:
                    Minus.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Multiply:
                    Multiply.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Divide:
                    Divide.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Enter:
                    Equals.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
            }
        }

        //Manage number buttons input
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (calcDone) //calculation already done
            {
                result.Content = $"{button.Content}";
                calcDone = false;
            }
            else //calculation not yet done
            {
                if (result.Content.ToString() == "0")
                {
                    result.Content = $"{button.Content}";
                }
                else
                {
                    result.Content = $"{result.Content}{button.Content}";
                }
            }

        }

        //Manage operation buttons input
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            //Evaluate button pressed
            switch (button.Content.ToString())
            {
                case "AC":
                    result.Content = "0";
                    break;
                case "+/-":
                    if (!(result.Content.ToString() == "0"))
                    {
                        result.Content = Convert.ToDouble(result.Content) * -1;
                    }
                    break;
                case "%":
                    if (!(result.Content.ToString() == "0"))
                    {
                        result.Content = Convert.ToDouble(result.Content) / 100;
                    }
                    break;
                case "÷":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Division;
                    result.Content = "0";
                    break;
                case "×":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Multiplication;
                    result.Content = "0";
                    break;
                case "-":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Subtraction;
                    result.Content = "0";
                    break;
                case "+":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Sum;
                    result.Content = "0";
                    break;
                case "=":
                    switch (operation)
                    {
                        case Operations.Division:
                            if (calcDone)
                            {
                                if (!(result.Content.ToString() == "ERROR"))
                                {
                                    result.Content = Convert.ToDouble(result.Content) / secondNumber;
                                }
                            }
                            else
                            {
                                //Check if division by 0
                                if (result.Content.ToString() == "0")
                                {
                                    result.Content = "ERROR";
                                    calcDone = true;
                                }
                                else
                                {
                                    secondNumber = Convert.ToDouble(result.Content);
                                    resultNumber = firstNumber / secondNumber;
                                    result.Content = resultNumber;
                                    calcDone = true;
                                }
                            }
                            break;
                        case Operations.Multiplication:
                            if (calcDone)
                            {
                                result.Content = Convert.ToDouble(result.Content) * secondNumber;
                            }
                            else
                            {
                                secondNumber = Convert.ToDouble(result.Content);
                                resultNumber = firstNumber * secondNumber;
                                result.Content = resultNumber;
                                calcDone = true;
                            }
                            break;
                        case Operations.Subtraction:
                            if (calcDone)
                            {
                                result.Content = Convert.ToDouble(result.Content) - secondNumber;
                            }
                            else
                            {
                                secondNumber = Convert.ToDouble(result.Content);
                                resultNumber = firstNumber - secondNumber;
                                result.Content = resultNumber;
                                calcDone = true;
                            }
                            break;
                        case Operations.Sum:
                            if (calcDone)
                            {
                                result.Content = Convert.ToDouble(result.Content) + secondNumber;
                            }
                            else
                            {
                                secondNumber = Convert.ToDouble(result.Content);
                                //MessageBox.Show($"{firstNumber} + {secondNumber}");
                                resultNumber = firstNumber + secondNumber;
                                result.Content = resultNumber;
                                calcDone = true;
                            }
                            break;
                    }
                    break;
                default:
                    if (!result.Content.ToString().Contains(separator))
                    {
                        result.Content = $"{result.Content}{button.Content}";
                    }
                    break;
            }
        }
    }
}
