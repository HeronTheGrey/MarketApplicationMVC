using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.Forum
{
    public class ListForumPostForListVm
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int ThreadId { get; set; }
        public string ThreadName { get; set; }
        public List<ForumPostForListVm> Posts { get; set; }
        public int Count { get; set; }
    }
}
