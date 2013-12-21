using System.Web.Mvc;
using Autofac.Integration.WebApi;

namespace CalculatorApp.Web.Controllers
{
  [AutofacControllerConfiguration]
  public class TestController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}
