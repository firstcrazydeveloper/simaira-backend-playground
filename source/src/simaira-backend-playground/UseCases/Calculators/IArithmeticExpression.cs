namespace simaira_backend_playground.UseCases.Calculators
{
    public interface IBasicArithmeticExpression
    {
        double Addition(double leftNumber, double rightNumber);
        double Substraction(double leftNumber, double rightNumber);
        double Multiplication(double leftNumber, double rightNumber);
        double Division(double leftNumber, double rightNumber);
    }
}
