namespace CalculatorApp.Web.MathOperator.Default
{
  public class SubstractMathOperator : IMathOperator
  {
    public string Sign => "-";

    public decimal Calculate(decimal x, decimal y)
    {
      return x - y;
    }
  }
}