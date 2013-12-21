using System.Collections.Generic;
using System.Linq;

namespace CalculatorApp.Web.MathOperator
{
  public class MathOperatorFactory
  {
    private readonly Dictionary<string, IMathOperator> _mathOperators;
    private readonly string[] _mathOperatorSigns;

    public MathOperatorFactory(ICollection<IMathOperator> mathOperators)
    {
      _mathOperators = mathOperators.ToDictionary(o => o.Sign);
      _mathOperatorSigns = _mathOperators.Keys.ToArray();
    }

    public IMathOperator GetMathOperatorBySign(string sign)
    {
      IMathOperator mathOperator;

      if (!_mathOperators.TryGetValue(sign, out mathOperator))
        return null;

      return mathOperator;
    }

    public string[] GetOperatorSigns()
    {
      return _mathOperatorSigns;
    }
  }
}