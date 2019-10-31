using System.Web.Mvc;
using System.Web.Routing;

namespace CalculatorApp.Web
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
        "Default",
        "{controller}/{action}",
        new { Controller = "Test", Action = "Index" });
    }
  }
}