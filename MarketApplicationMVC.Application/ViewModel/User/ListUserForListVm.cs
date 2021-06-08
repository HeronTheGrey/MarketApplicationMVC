using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.User
{
    public class ListUserForListVm
    {
        public List<UserForListVm> Users { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public string SearchPhrase { get; set; }
        public int Count { get; set; }
    }
}
