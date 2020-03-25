using Microsoft.AspNetCore.Mvc;

namespace DoctorOffice.Controllers
{
  public class HomeController : Controller
  {

    public ActionResult Index()
    {
      return View();
    }

  }
}