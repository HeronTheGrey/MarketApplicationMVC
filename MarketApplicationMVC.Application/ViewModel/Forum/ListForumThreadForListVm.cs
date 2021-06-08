using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.Forum
{
    public class ListForumThreadForListVm
    {
        public int PageSize { get; set; }
        public string SearchPhrase { get; set; }
        public int CurrentPage { get; set; }
        public List<ForumThreadForListVm> Threads { get; set; }
        public int Count { get; set; }
    }
}
