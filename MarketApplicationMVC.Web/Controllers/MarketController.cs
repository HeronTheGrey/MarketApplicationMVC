using MarketApplicationMVC.Web.Models;
using MarketApplicationMVC.Application.ViewModel.Market;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketApplicationMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;
using System.IO;

namespace MarketApplicationMVC.Web.Controllers
{
    public class MarketController : Controller
    {
        private readonly IMarketService _marketService;
        public MarketController(IMarketService marketService)
        {
            _marketService = marketService;
        }
        public IActionResult Index()
        {
            var model = _marketService.ViewAllActiveOffersForList("", 1, 5);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchPhrase)
        {
            if (pageNo is null) { pageNo = 1; }
            if (searchPhrase is null)
            {
                searchPhrase = String.Empty;
            }
            var model = _marketService.ViewAllActiveOffersForList(searchPhrase, (int)pageNo, pageSize);
            return View(model);
        }


        [HttpGet]
        public IActionResult AddOffer()
        {
            var types = _marketService.GetOfferTypes();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var type in types)
            {
                listItems.Add(new SelectListItem
                {
                    Text = type.Name,
                    Value = type.Id.ToString()
                });
            }

            ViewData["Categories"] = listItems;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOffer(NewOfferVm model)
        {
            int id = await _marketService.AddOffer(model);
            var types = _marketService.GetOfferTypes();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var type in types)
            {
                listItems.Add(new SelectListItem
                {
                    Text = type.Name,
                    Value = type.Id.ToString()
                });
            }

            ViewData["Categories"] = listItems;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewOfferDetails(int id)
        {
            ViewBag.Image = null;
            var model = _marketService.ViewOfferDetails(id);
            ViewBag.Image = ViewImage(model.Picture);
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteOffer(int id)
        {
            _marketService.DeleteOffer(id);
            return RedirectToAction("Index");
        }

        [NonAction]
        private string ViewImage(byte[] arrayImage)
        {
            string base64String = Convert.ToBase64String(arrayImage, 0, arrayImage.Length);
            return "data:image/png;base64," + base64String;
        }
    }
}
