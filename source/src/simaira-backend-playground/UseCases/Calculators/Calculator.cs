namespace simaira_backend_playground.UseCases.Calculators
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Calculator : ICloneable
    {
        private IBasicArithmeticExpression _basicArithmeticExpression;
        private Stack<Calculator> _states = new Stack<Calculator>();
        private Queue<string> _inputs = new Queue<string>();        
        private double _rightValue;
        private double _result;
        private string _operatorPatterns = @"^[+\-*\/=]*$";
        private string _numberInputPatterns = @"^[0-9$]";
        private string _expectedPattenrs;
        private string _operator;

        public Calculator()
        {
            _expectedPattenrs = _numberInputPatterns;
            _basicArithmeticExpression = new NumericOperand();
            _result = 0;
            _rightValue = 0;
            _operator = "+";
        }

        public string Result { get { return _result.ToString();  } }

        public void SetInput(string input)
        {
            if (!IsValidInput(input))
            {
                throw new NotSupportedException();
            }

            _inputs.Enqueue(input);

            if (IsOperator(input))
            {
                _result = PerformOperation(_operator);
                _states.Push((Calculator)this.Clone());
                _expectedPattenrs = _numberInputPatterns;
                _operator = input;

            } 
            else
            {
                _result = _operator.Equals("=") ? 0 : _result;
                _rightValue = Convert.ToDouble( input);
                _expectedPattenrs = _operatorPatterns;
            }
        }

        public void Undo()
        {
            _states.Pop();
            var lastObject = _states.Peek();
            _result = lastObject._result;
            _rightValue = lastObject._rightValue;
            _inputs = lastObject._inputs;

        }

        public string GetHistory()
        {
            StringBuilder response = new StringBuilder();
            foreach (var input in _inputs)
            {
                response = string.IsNullOrEmpty(response.ToString()) ? response.Append(input) : response.Append(" " + input);
            }

            return response.ToString();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public bool IsValidInput(string input)
        {
            Regex rg = new Regex(_expectedPattenrs);
            return rg.IsMatch(input);
            
        }

        private bool IsOperator(string input)
        {
            Regex rg = new Regex(_operatorPatterns);
            return rg.IsMatch(input);
        }

        private double PerformOperation(string action)
        {
            switch(action)
            {
                case "+":
                    return _basicArithmeticExpression.Addition(_result, _rightValue);
                case "-":
                    return _basicArithmeticExpression.Substraction(_result, _rightValue);
                case "*":
                    return _basicArithmeticExpression.Multiplication(_result, _rightValue);
                case "/":
                    return _basicArithmeticExpression.Division(_result, _rightValue);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
