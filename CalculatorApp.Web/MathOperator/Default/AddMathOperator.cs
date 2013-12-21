namespace CalculatorApp.Web.MathOperator.Default
{
  public class AddMathOperator : IMathOperator
  {
    public string Sign { get { return "+"; } }

    public decimal Calculate(decimal x, decimal y)
    {
      return x + y;
    }
  }
}