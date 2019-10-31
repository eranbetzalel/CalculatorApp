using System.Web.Http;

namespace CalculatorApp.Web
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      config.Routes.MapHttpRoute(
        "DefaultApi",
        "api/{controller}/{action}");

      config.Routes.MapHttpRoute(
        "RestApi",
        "api/{controller}");
    }
  }
}
