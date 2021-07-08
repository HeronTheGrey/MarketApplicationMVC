using MarketApplicationMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApplicationMVC.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("Users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _userService.GetListOfAllUsers("", 1, 5);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int pageSize, int? pageNo, string searchPhrase)
        {
            if (pageNo is null) { pageNo = 1; }
            if (searchPhrase is null)
            {
                searchPhrase = String.Empty;
            }
            var model = await _userService.GetListOfAllUsers(searchPhrase, (int)pageNo, pageSize);
            return View(model);
        }
    }
}
