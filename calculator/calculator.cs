using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace calculator
{
    public class calculator
    {
        private double _currentValue = 0;
        private string _operator = "";
        private bool _isNewInput = false;

        public string getInput() => _currentValue.ToString();

        public void appendInput(string value, TextBox display)
        {
            if (_isNewInput)
            {
                display.Text = "";
                _isNewInput = false;
            }
            display.Text += value;
        }
        public double setOperator(string newOperator, string displayText)
        {
            double newValue;
            if (!double.TryParse(displayText, out newValue)) return _currentValue;

            if (!string.IsNullOrEmpty(_operator))
            {
                // perform calculation before updating operator
                _currentValue = evaluate(newValue);
            }
            else
            {
                _currentValue = newValue;
            }

            _operator = newOperator;
            _isNewInput = true;

            return _currentValue;
        }

        public double evaluate(double newValue)
        {
            
            switch (_operator)
            {
                case "+": return _currentValue + newValue;
                case "-": return _currentValue - newValue;
                case "X": return _currentValue * newValue;
                case "/": return newValue != 0 ? _currentValue / newValue : double.NaN;
                case "AC": return 0;
                case "%": return _currentValue / 100;
                case "+/-": return _currentValue + newValue;
                default:
                    return newValue;
            }
        }

        public double finalEvaluate(string displayText)
        {
            if (!double.TryParse(displayText, out double newValue)) return _currentValue;

            double result = evaluate(newValue);
            _operator = "";
            return result;
        }

        public void clear()
        {
            _currentValue = 0;
            _operator = "";
            _isNewInput = false;
            
        }
    }
}
