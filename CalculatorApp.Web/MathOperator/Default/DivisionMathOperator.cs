namespace CalculatorApp.Web.MathOperator.Default
{
  public class DivisionMathOperator : IMathOperator
  {
    public string Sign { get { return "/"; } }

    public decimal Calculate(decimal x, decimal y)
    {
      return x / y;
    }
  }
}