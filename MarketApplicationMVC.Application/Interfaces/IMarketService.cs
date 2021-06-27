using MarketApplicationMVC.Application.ViewModel.Market;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketApplicationMVC.Application.Interfaces
{
    public interface IMarketService
    {
        ListOfferForListVm ViewAllActiveOffers();
        Task<int> AddOffer(NewOfferVm newOffer);
        OfferDetailsVm ViewOfferDetails(int offerId);
        List<OfferCategoryVm> GetOfferTypes();
        void DeleteOffer(int id);
        ListOfferForListVm ViewAllActiveOffersForList(string searchPhrase, int currentPage, int pageSize);
    }
}
