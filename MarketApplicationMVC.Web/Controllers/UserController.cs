using MarketApplicationMVC.Application.Interfaces;
using MarketApplicationMVC.Application.Services;
using MarketApplicationMVC.Application.ViewModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApplicationMVC.Web.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _userService.GetAllActiveUsersForList(5, 1, "");
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchPhrase)
        {
            if (pageNo is null) { pageNo = 1; }
            if (searchPhrase is null)
            {
                searchPhrase = String.Empty;
            }
            var model = _userService.GetAllActiveUsersForList(pageSize, (int)pageNo, searchPhrase);
            return View(model);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            var types = _userService.GetAllUserTypes();

            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var type in types)
            {
                listItems.Add(new SelectListItem
                {
                    Text = type.Name,
                    Value = type.Id.ToString()
                });
            }
            
            ViewData["Names"] = listItems;
            return View(new NewUserVm());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(NewUserVm model)
        {
            var id = _userService.AddUser(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var user = _userService.GetUserForEdit(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(NewUserVm model)
        {
            _userService.UpdateUser(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAddress(int id)
        {
            var address = _userService.GetUserAddress(id);
            ViewData["UserRef"] = id;
            return View(address);
        }

        [HttpPost]
        public IActionResult EditAddress(AddressEditVm model)
        {
            _userService.UpdateUserAddress(model);
            return RedirectToAction("ViewUserDetails", new { id = model.UserRef });
        }

        [HttpGet]
        public IActionResult AddContactInformation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContactInformation(ContactInformationVm model)
        {
            var id = _userService.AddContactInformation(model);
            return View();
        }
        public IActionResult ViewUserDetails(int id)
        {
            var model = _userService.ViewUserDetails(id);
            return View(model);
        }

    }
}
