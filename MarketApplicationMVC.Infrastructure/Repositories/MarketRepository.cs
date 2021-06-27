using MarketApplicationMVC.Domain.Interface;
using MarketApplicationMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketApplicationMVC.Infrastructure.Repositories
{
    class MarketRepository : IMarketRepository
    {
        private readonly Context _context;
        public MarketRepository(Context context)
        {
            _context = context;
        }
        public int AddOffer(Offer offer)
        {
            if(offer.UserId == 0)
            {
                offer.UserId = null;
            }
            _context.Offers.Add(offer);
            _context.SaveChanges();
            return offer.Id;
        }

        public void DeleteOffer(int id)
        {
            var offer = _context.Offers.Find(id);
            if(offer != null)
            {
                _context.Offers.Remove(offer);
                _context.SaveChanges();
            }
        }

        public IQueryable<OfferCategory> GetAllOfferCategories()
        {
            var offerCategories = _context.OfferCategories;
            return offerCategories;
        }

        public IQueryable<Offer> GetAllOffers()
        {
            var offers = _context.Offers;
            return offers;
        }

        public Offer GetOfferById(int id)
        {
            var offer = _context.Offers.Include(p => p.OfferCategory).FirstOrDefault(i => i.Id == id);
            return offer;
        }


    }
}
