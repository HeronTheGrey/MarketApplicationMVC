using MarketApplicationMVC.Application.ViewModel.Forum;
using MarketApplicationMVC.Application.ViewModel.Market;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketApplicationMVC.Application.Interfaces
{
    public interface IForumService
    {
        Task<ListForumThreadForListVm> ViewAllActiveThreads(int pageSize, int pageNumber, string searchPhrase);
        int AddForumThread(NewThreadVm newThread);
        ListForumPostForListVm ViewThreadPosts(int threadId, int pageSize, int currentPage);
        int AddThreadPost(NewPostVm newPost);
        int GetThreadPostsAmountByThreadId(int id);
        void DeletePost(int id);
        void DeleteThread(int id);
        public IEnumerable<ThreadForApiVm> GetAllThreadsForApi();
    }
}
