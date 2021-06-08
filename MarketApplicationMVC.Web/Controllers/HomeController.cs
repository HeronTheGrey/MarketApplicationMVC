using MarketApplicationMVC.Application.Interfaces;
using MarketApplicationMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApplicationMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult ListOfUsers()
        {
            List<User> list = new List<User>();
            list.Add(new Models.User(1, "Heron", "StandardUser"));
            list.Add(new Models.User(2, "Bartek1999", "Admin"));
            return View(list);
        }

        public IActionResult UserDetail()//metoda docelowo będzie pobierać informacje z bazy danych
        {
            UserDetails userDetails = new UserDetails("Heron", "Standard user", "Poland", "Warsaw", "Mickiewicza", "00-100", 5, 25);
            return View(userDetails);
        }
        public IActionResult Index()
        {
            return View();
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
