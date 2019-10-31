using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using CalculatorApp.Web.MathOperator;
using CalculatorApp.Web.MathOperator.Default;
using log4net;

namespace CalculatorApp.Web
{
  //  TODO: Add unhandled error support - log the error
  public class MvcApplication : HttpApplication
  {
    protected void Application_Start()
    {
      var logger = InitializeLogger();

      AreaRegistration.RegisterAllAreas();

      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);

      var container = InitializeIoc(logger);

      GlobalConfiguration.Configuration.DependencyResolver =
        new AutofacWebApiDependencyResolver(container);
    }

    private IContainer InitializeIoc(ILog logger)
    {
      try
      {
        var builder = new ContainerBuilder();

        builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

        builder.Register(c => logger).As<ILog>().SingleInstance();

        builder.RegisterType<MathOperatorFactory>().SingleInstance();
        builder.RegisterType<AddMathOperator>().AsImplementedInterfaces().SingleInstance();
        builder.RegisterType<SubstractMathOperator>().AsImplementedInterfaces().SingleInstance();
        builder.RegisterType<DivisionMathOperator>().AsImplementedInterfaces().SingleInstance();
        builder.RegisterType<MultiplyMathOperator>().AsImplementedInterfaces().SingleInstance();

        return builder.Build();
      }
      catch (Exception e)
      {
        logger.Error("An error occurred while initializing the IoC module.", e);

        throw;
      }
    }

    private ILog InitializeLogger()
    {
      ILog logger;

      try
      {
        logger = LogManager.GetLogger("CalculatorApp.Server");
      }
      catch (Exception e)
      {
        Console.WriteLine(
          "An error occurred while initializing the logging module." +
          "\r\n\r\nException:\r\n" + e);

        throw;
      }

      return logger;
    }
  }
}