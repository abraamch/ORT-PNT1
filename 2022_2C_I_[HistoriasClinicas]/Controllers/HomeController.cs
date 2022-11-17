using _2022_2C_I__HistoriasClinicas_.Data;
using _2022_2C_I__HistoriasClinicas_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2022_2C_I__HistoriasClinicas_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly HistoriasClinicasContext _context;

       
        public HomeController(ILogger<HomeController> logger, HistoriasClinicasContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Medicos.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}