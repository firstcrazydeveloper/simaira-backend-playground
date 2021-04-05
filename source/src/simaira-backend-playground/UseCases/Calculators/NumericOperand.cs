namespace simaira_backend_playground.UseCases.Calculators
{
    public class NumericOperand : IBasicArithmeticExpression
    {
        public double Addition(double leftNumber, double rightNumber)
        {
           return leftNumber + rightNumber;
        }

        public double Division(double leftNumber, double rightNumber)
        {
            return leftNumber / rightNumber;
        }

        public double Multiplication(double leftNumber, double rightNumber)
        {
            return leftNumber * rightNumber;
        }

        public double Substraction(double leftNumber, double rightNumber)
        {
            return leftNumber - rightNumber;
        }
    }
}
