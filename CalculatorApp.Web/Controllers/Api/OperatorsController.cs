using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Autofac.Integration.WebApi;
using CalculatorApp.Web.MathOperator;
using log4net;

namespace CalculatorApp.Web.Controllers.Api
{
  [AutofacControllerConfiguration]
  public class OperatorsController : ApiController
  {
    private readonly ILog _log;
    private readonly MathOperatorFactory _mathOperatorFactory;

    public OperatorsController(ILog log, MathOperatorFactory mathOperatorFactory)
    {
      _log = log;
      _mathOperatorFactory = mathOperatorFactory;
    }

    public IEnumerable<string> Get()
    {
      try
      {
        return _mathOperatorFactory.GetOperatorSigns();
      }
      catch (Exception e)
      {
        _log.Error("Failed to get operator signs.", e);

        throw new HttpResponseException(HttpStatusCode.InternalServerError);
      }
    }

    public string Get(int id)
    {
      throw new HttpResponseException(HttpStatusCode.NotImplemented);
    }

    public void Post([FromBody]string value)
    {
      throw new HttpResponseException(HttpStatusCode.NotImplemented);
    }

    public void Put(int id, [FromBody]string value)
    {
      throw new HttpResponseException(HttpStatusCode.NotImplemented);
    }

    public void Delete(int id)
    {
      throw new HttpResponseException(HttpStatusCode.NotImplemented);
    }
  }
}
