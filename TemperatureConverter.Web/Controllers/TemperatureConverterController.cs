using Microsoft.AspNetCore.Mvc;
using TemperatureConverter.Web.Models;

namespace TemperatureConverter.Web.Controllers
{
    public class TemperatureConverterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new TemperatureConverterViewModel());
        }
    }
}
