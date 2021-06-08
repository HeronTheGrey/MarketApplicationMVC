using MarketApplicationMVC.Application.ViewModel.Market;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.Interfaces
{
    public interface IMarketService
    {
        ListOfferForListVm ViewAllActiveOffers();
        int AddOffer(NewOfferVm newOffer);
        OfferDetailsVm ViewOfferDetails(int offerId);


    }
}
