using System;
using System.Configuration;
using System.Threading;
using System.Web.Http;
using Autofac.Integration.WebApi;
using CalculatorApp.Web.MathOperator;
using CalculatorApp.Web.Models;
using log4net;

namespace CalculatorApp.Web.Controllers.Api
{
  [AutofacControllerConfiguration]
  public class CalculatorController : ApiController
  {
    private readonly ILog _log;
    private readonly MathOperatorFactory _mathOperatorFactory;
    private readonly int? _calculationAddedDelay;

    public CalculatorController(ILog log, MathOperatorFactory mathOperatorFactory)
    {
      _log = log;
      _mathOperatorFactory = mathOperatorFactory;

      //  TODO: use ISettingProvider /w AutoFac instead of directly calling ConfigurationManager
      var calculationAddedDelay = ConfigurationManager.AppSettings["CalculationAddedDelay"];

      int calculationAddedDelayInt;

      if (int.TryParse(calculationAddedDelay, out calculationAddedDelayInt))
        _calculationAddedDelay = calculationAddedDelayInt;
    }

    //  Note: consider validation using Model Binding for request
    //  TODO: add caching mechanism for server (last X calculations) and client (?)
    public CalculateReponse GetResult(decimal? x, decimal? y, string op)
    {
      try
      {
        if (!x.HasValue)
          return new CalculateReponse { Error = string.Format("Missing X operand.") };

        if (!y.HasValue)
          return new CalculateReponse { Error = string.Format("Missing Y operand.") };

        var mathOperator = _mathOperatorFactory.GetMathOperatorBySign(op);

        if (mathOperator == null)
          return new CalculateReponse { Error = string.Format("Operator " + op + " is not implemented.") };

        if (_calculationAddedDelay.HasValue)
          Thread.Sleep(_calculationAddedDelay.Value);

        return new CalculateReponse { Result = mathOperator.Calculate(x.Value, y.Value) };
      }
      catch (Exception e)
      {
        _log.Error("Calculation failed.", e);

        return new CalculateReponse { Error = string.Format("Calculation failed. {0}.", e.Message) };
      }
    }
  }
}
