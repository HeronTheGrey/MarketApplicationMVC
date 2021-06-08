using MarketApplicationMVC.Application.ViewModel.Forum;
using MarketApplicationMVC.Application.ViewModel.Market;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.Interfaces
{
    public interface IForumService
    {
        ListForumThreadForListVm ViewAllActiveThreads(int pageSize, int pageNumber, string searchPhrase);
        int AddForumThread(NewThreadVm newThread);
        ListForumPostForListVm ViewThreadPosts(int threadId, int pageSize, int currentPage);
        int AddThreadPost(NewPostVm newPost);
        int GetThreadPostsAmountByThreadId(int id);
    }
}
