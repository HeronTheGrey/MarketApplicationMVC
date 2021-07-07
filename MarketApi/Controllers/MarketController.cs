using MarketApplicationMVC.Application.Interfaces;
using MarketApplicationMVC.Application.ViewModel.Market;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApi.Controllers
{
    [Route("api/Market")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly IMarketService _marketService;

        public MarketController(IMarketService marketService)
        {
            _marketService = marketService;
        }

        [HttpGet]
        [Route("GetOfferTypes")]
        public IEnumerable<OfferCategoryVm> GetAllOfferTypes()
        {
            var types = _marketService.GetOfferTypes();
            return types;
        }

        [Route("GetAllOffers")]
        [HttpGet]
        public IEnumerable<OfferForApiVm> GetAllOffers()
        {
            var offers = _marketService.GetAllOffersForApi();
            return offers;
        }
    }
}
