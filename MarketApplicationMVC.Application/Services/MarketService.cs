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
using Microsoft.AspNetCore.Identity;

namespace MarketApplicationMVC.Application.Services
{
    class MarketService : IMarketService
    {
        private readonly IMarketRepository _marketRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public MarketService(IMarketRepository marketRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _marketRepository = marketRepository;
            _mapper = mapper;
            _userManager = userManager;
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

        public IEnumerable<OfferForApiVm> GetAllOffersForApi()
        {
            var offers = _marketRepository.GetAllOffers().Where(p => p.IsActive == true);
            var offersVm = _mapper.ProjectTo<OfferForApiVm>(offers);
            return offersVm;
        }

        public OfferForEditVm GetOfferForEdit(int id)
        {
            var offer = _marketRepository.GetOfferById(id);
            var offerVm = _mapper.Map<OfferForEditVm>(offer);
            return offerVm;
        }

        public List<OfferCategoryVm> GetOfferTypes()
        {
            var types = _marketRepository.GetAllOfferCategories();
            var typesVm = _mapper.ProjectTo<OfferCategoryVm>(types).ToList();
            return typesVm;
        }

        public async Task UpdateOffer(OfferForEditVm model)
        {
            var offer = _mapper.Map<Offer>(model);
            if (model.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Picture.CopyToAsync(memoryStream);
                    offer.Picture = memoryStream.ToArray();
                }
            }
            _marketRepository.UpdateOffer(offer);
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

        public async Task<OfferDetailsVm> ViewOfferDetails(int offerId)
        {
            var offer = _marketRepository.GetOfferById(offerId);
            var offerVm = _mapper.Map<OfferDetailsVm>(offer);
            if (offer.UserId != null)
            {
                var user = await _userManager.FindByIdAsync(offer.UserId);
                offerVm.SellerName = user.UserName;
            }
            else
            {
                offerVm.SellerName = "";
            }
            return offerVm;
        }

    }
}
