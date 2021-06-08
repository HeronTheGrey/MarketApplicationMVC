using MarketApplicationMVC.Application.Interfaces;
using MarketApplicationMVC.Application.ViewModel.Forum;
using MarketApplicationMVC.Application.ViewModel.Market;
using MarketApplicationMVC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MarketApplicationMVC.Domain.Model;

namespace MarketApplicationMVC.Application.Services
{
    class ForumService : IForumService
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public ForumService(IForumRepository forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository;
            _mapper = mapper;
        }
        public int AddForumThread(NewThreadVm newThread)
        {
            var thread = _mapper.Map<ForumThread>(newThread);
            thread.IsActive = true;
            var id = _forumRepository.AddForumThread(thread);
            return id;
        }

        public int AddThreadPost(NewPostVm newPost)
        {
            var post = _mapper.Map<ForumPost>(newPost);
            var id = _forumRepository.AddForumPost(post);
            return id;
        }

        public int GetThreadPostsAmountByThreadId(int id)
        {
            var thread = _forumRepository.GetForumThreadById(id);
            var amount = thread.ForumPosts.Count();
            return amount;
        }

        public ListForumThreadForListVm ViewAllActiveThreads(int pageSize, int pageNumber, string searchPhrase)
        {
            var threads = _forumRepository.GetAllForumThreads()
                .Where(p => p.IsActive == true)
                .Where(p => p.Name.Contains(searchPhrase))
                .ProjectTo<ForumThreadForListVm>(_mapper.ConfigurationProvider).ToList();
            var threadsToShow = threads.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var threadsList = new ListForumThreadForListVm
            {
                PageSize = pageSize,
                CurrentPage = pageNumber,
                SearchPhrase = searchPhrase,
                Threads = threadsToShow,
                Count = threads.Count
            };
            return threadsList;
        }

        public ListForumPostForListVm ViewThreadPosts(int threadId, int pageSize, int currentPage)
        {
            var posts = _forumRepository.GetAllForumPosts().Where(s => s.ForumThreadId == threadId).ProjectTo<ForumPostForListVm>(_mapper.ConfigurationProvider).ToList();
            var threadName = _forumRepository.GetForumThreadById(threadId).Name;
            var postsToShow = posts.Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
            var postsList = new ListForumPostForListVm
            {
                ThreadId = threadId,
                ThreadName = threadName, 
                PageSize = pageSize,
                CurrentPage = currentPage, 
                Posts = postsToShow,
                Count = posts.Count
            };
            return postsList;
        }
    }
}
