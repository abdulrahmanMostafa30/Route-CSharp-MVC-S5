using IKEA.BLL.DTO.DepartmentDTO;
using IKEA.BLL.Services.DepartmentServices;
using IKEA.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IKEA.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
