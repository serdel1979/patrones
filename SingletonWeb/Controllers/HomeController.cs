using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SingletonWeb.Models;
using SingletonWeb.Configuration;
using System.Diagnostics;
using Tool;

namespace SingletonWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly IOptions<Config> _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public HomeController(IOptions<Config> config, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
                string ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();

                Log.GetInstance(_configuration.Value.PathLog).Save($"Entró a Index desde ip {ipAddress} -- {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n");
                return View();
           
        }

        public IActionResult Privacy()
        {
            string ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            Log.GetInstance(_configuration.Value.PathLog).Save($"Entró a Privacy  desde ip {ipAddress} -- {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
