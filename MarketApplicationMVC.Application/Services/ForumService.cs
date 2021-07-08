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
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using MarketApplicationMVC.Domain.Model;

namespace MarketApplicationMVC.Application.Services
{
    class ForumService : IForumService
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public ForumService(IForumRepository forumRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _forumRepository = forumRepository;
            _mapper = mapper;
            _userManager = userManager;
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

        public void DeletePost(int id)
        {
            _forumRepository.DeleteForumPost(id);
        }

        public void DeleteThread(int id)
        {
            _forumRepository.DeactivateThread(id);
        }

        public int GetThreadPostsAmountByThreadId(int id)
        {
            var thread = _forumRepository.GetForumThreadById(id);
            var amount = thread.ForumPosts.Count();
            return amount;
        }

        public IEnumerable<ThreadForApiVm> GetAllThreadsForApi()
        {
            var threads = _forumRepository.GetAllForumThreads().Where(p => p.IsActive == true);
            var threadsVm = _mapper.ProjectTo<ThreadForApiVm>(threads);
            return threadsVm;
        }

        public async Task<ListForumThreadForListVm> ViewAllActiveThreads(int pageSize, int pageNumber, string searchPhrase)
        {
            var threads = _forumRepository.GetAllForumThreads()
                .Where(p => p.IsActive == true)
                .Where(p => p.Name.Contains(searchPhrase))
                .ProjectTo<ForumThreadForListVm>(_mapper.ConfigurationProvider).ToList();
            var threadsToShow = threads.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            foreach(var thread in threadsToShow)
            {
                var user = await _userManager.FindByIdAsync(thread.UserId);
                if (user != null)
                {
                    thread.AuthorName = user.UserName;
                }
            }
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

        public async Task<ListForumPostForListVm> ViewThreadPosts(int threadId, int pageSize, int currentPage)
        {
            var posts = _forumRepository.GetAllForumPosts().Where(s => s.ForumThreadId == threadId).ProjectTo<ForumPostForListVm>(_mapper.ConfigurationProvider).ToList();
            var threadName = _forumRepository.GetForumThreadById(threadId).Name;
            var postsToShow = posts.Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();

            foreach(var post in postsToShow)
            {
                if(post.UserId != null)
                {
                    var user = await _userManager.FindByIdAsync(post.UserId);
                    if (user != null)
                    {
                        post.UserName = user.UserName;
                    }
                }
            }

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
