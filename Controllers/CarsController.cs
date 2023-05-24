using Microsoft.AspNetCore.Mvc;

namespace Better.Way.To.Configure.EFCore.Controllers;

public class CarsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}