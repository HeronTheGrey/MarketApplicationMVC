using MarketApplicationMVC.Application.ViewModel.Forum;
using MarketApplicationMVC.Application.ViewModel.Market;
using MarketApplicationMVC.Web.Models;
using MarketApplicationMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApplicationMVC.Web.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;
        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _forumService.ViewAllActiveThreads(5, 1, "");
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? currentPage, string searchPhrase)
        {
            if(searchPhrase is null)
            {
                searchPhrase = string.Empty;
            }
            if (currentPage is null)
            {
                currentPage = 1;
            }
            var model = _forumService.ViewAllActiveThreads(pageSize, (int)currentPage, searchPhrase);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddForumThread()
        {
            return View(new NewThreadVm());
        }
        [HttpPost]
        public IActionResult AddForumThread(NewThreadVm model)
        {
            int id = _forumService.AddForumThread(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ViewThreadPosts(int id, bool lastpage = false)
        {
            if(lastpage)
            {
                var threadPostAmount = _forumService.GetThreadPostsAmountByThreadId(id);
                var model = _forumService.ViewThreadPosts(id, 10, (int)Math.Ceiling((double)threadPostAmount / 10));
                return View(model);
            }
            else 
            {
                var model = _forumService.ViewThreadPosts(id, 10, 1);
                return View(model);
            }
            
        }

        [HttpPost]
        public IActionResult ViewThreadPosts(int threadId, int pageSize, int currentPage)
        {
            var model = _forumService.ViewThreadPosts(threadId, pageSize, currentPage);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddThreadPost(int threadId)
        {
            var newPost = new NewPostVm();
            newPost.ThreadId = threadId;
            return View(newPost);
        }
        [HttpPost]
        public IActionResult AddThreadPost(NewPostVm model)
        {
            _forumService.AddThreadPost(model);
            return RedirectToAction("ViewThreadPosts", new { id = model.ThreadId, lastpage = true });
        }
    }
}
