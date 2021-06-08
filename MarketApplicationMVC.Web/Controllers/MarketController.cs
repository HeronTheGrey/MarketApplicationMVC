using MarketApplicationMVC.Web.Models;
using MarketApplicationMVC.Application.ViewModel.Market;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketApplicationMVC.Application.Interfaces;

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
            var model = _marketService.ViewAllActiveOffers(); 
            List<Offer> offerChoices = new List<Offer>();
            offerChoices.Add(new Offer(1, "Jabłka", 1.99m, 125));
            offerChoices.Add(new Offer(2, "Laptop", 2000, 1));
            offerChoices.Add(new Offer(3, "Filtry do kawy", 5, 57));
            offerChoices.Add(new Offer(4, "Walizki", 250, 3));
            offerChoices.Add(new Offer(5, "Czekolada", 4.99m, 99));
            offerChoices.Add(new Offer(6, "GTX 1060", 1599.99m, 5));
            return View(model);
        }
        [HttpGet]
        public IActionResult AddOffer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOffer(NewOfferVm model)
        {
            int id = _marketService.AddOffer(model);
            return View(model);
        }

        public IActionResult ViewOfferDetails(int id)
        {
            var model = _marketService.ViewOfferDetails(id);
            return View(model);
        }


    }
}
