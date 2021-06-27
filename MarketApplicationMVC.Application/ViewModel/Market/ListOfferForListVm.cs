using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.Market
{
    public class ListOfferForListVm
    {
        public List<OfferForListVm> Offers { get; set; }
        public int Count { get; set; }
        public string SearchPhrase { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }




    }
}
