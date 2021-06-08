using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketApplicationMVC.Domain.Interface
{
    public interface IMarketRepository
    {
        int AddOffer(Offer offer);
        Offer GetOfferById(int id);
        IQueryable<Offer> GetAllOffers();
        void DeleteOffer(int id);

        IQueryable<OfferCategory> GetAllOfferCategories();
    }
}
