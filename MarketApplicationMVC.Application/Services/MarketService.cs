using AutoMapper;
using MarketApplicationMVC.Application.Interfaces;
using MarketApplicationMVC.Application.ViewModel.Market;
using MarketApplicationMVC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper.QueryableExtensions;
using MarketApplicationMVC.Domain.Model;
using System.IO;
using System.Threading.Tasks;

namespace MarketApplicationMVC.Application.Services
{
    class MarketService : IMarketService
    {
        private readonly IMarketRepository _marketRepository;
        private readonly IMapper _mapper;

        public MarketService(IMarketRepository marketRepository, IMapper mapper)
        {
            _marketRepository = marketRepository;
            _mapper = mapper;
        }
        public async Task<int> AddOffer(NewOfferVm newOffer)
        {
            var offer = _mapper.Map<Offer>(newOffer);
            if (newOffer.Picture != null)
            {
                using(var memoryStream = new MemoryStream())
                {
                    await newOffer.Picture.CopyToAsync(memoryStream);
                    offer.Picture = memoryStream.ToArray();
                }
            }
            offer.IsActive = true;
            return _marketRepository.AddOffer(offer);
        }

        public void DeleteOffer(int id)
        {
            _marketRepository.DeleteOffer(id);
        }

        public List<OfferCategoryVm> GetOfferTypes()
        {
            var types = _marketRepository.GetAllOfferCategories();
            var typesVm = _mapper.ProjectTo<OfferCategoryVm>(types).ToList();
            return typesVm;
        }

        public ListOfferForListVm ViewAllActiveOffers()
        {
            var offers = _marketRepository.GetAllOffers().Where(p => p.IsActive == true).ProjectTo<OfferForListVm>(_mapper.ConfigurationProvider).ToList();
            var offersList = new ListOfferForListVm
            {
                Offers = offers,
                Count = offers.Count
            };
            return offersList;
        }

        public ListOfferForListVm ViewAllActiveOffersForList(string searchPhrase, int currentPage, int pageSize)
        {
            var offers = _marketRepository.GetAllOffers()
                .Where(p => p.IsActive == true)
                .Where(p => p.Name.Contains(searchPhrase))
                .ProjectTo<OfferForListVm>(_mapper.ConfigurationProvider)
                .ToList();
            var offersToShow = offers.Skip((pageSize * (currentPage - 1))).Take(pageSize).ToList();
            var usersList = new ListOfferForListVm()
            {
                PageSize = pageSize,
                CurrentPage = currentPage,
                SearchPhrase = searchPhrase,
                Offers = offersToShow,
                Count = offers.Count
            };
            return usersList;
        }

        public OfferDetailsVm ViewOfferDetails(int offerId)
        {
            var offer = _marketRepository.GetOfferById(offerId);
            var offerVm = _mapper.Map<OfferDetailsVm>(offer);
            return offerVm;
        }
    }
}
