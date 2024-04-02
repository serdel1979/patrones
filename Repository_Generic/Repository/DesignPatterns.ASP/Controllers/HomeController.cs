using DesignPatterns.ASP.Models;
using DesignPatterns.Respository;
using Microsoft.AspNetCore.Mvc;
using Patterns.UnitOW.Entities;
using System.Diagnostics;

namespace DesignPatterns.ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IRepository<Beer> _respository;
        public HomeController(ILogger<HomeController> logger, IRepository<Beer> repository)
        {
            _logger = logger;
            _respository = repository;
        }

        public IActionResult Index()
        {

            IEnumerable<Beer> lst = _respository.Get();

            return View("Index",lst);
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
