using MarketApplicationMVC.Application.ViewModel.Forum;
using MarketApplicationMVC.Application.ViewModel.Market;
using MarketApplicationMVC.Web.Models;
using MarketApplicationMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace MarketApplicationMVC.Web.Controllers
{
    [Authorize]
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;
        private readonly UserManager<IdentityUser> _userManager;
        public ForumController(IForumService forumService, UserManager<IdentityUser> userManager)
        {
            _forumService = forumService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _forumService.ViewAllActiveThreads(5, 1, "");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int pageSize, int? currentPage, string searchPhrase)
        {
            if(searchPhrase is null)
            {
                searchPhrase = string.Empty;
            }
            if (currentPage is null)
            {
                currentPage = 1;
            }
            var model = await _forumService.ViewAllActiveThreads(pageSize, (int)currentPage, searchPhrase);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddForumThread()
        {
            return View(new NewThreadVm());
        }

        [HttpPost]
        public async Task<IActionResult> AddForumThread(NewThreadVm model)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            model.UserId = userId;
            int id = _forumService.AddForumThread(model);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ViewThreadPosts(int id, bool lastpage = false, int currentPage = 1, int pageSize = 10)
        {
            if(lastpage)
            {
                var threadPostAmount = _forumService.GetThreadPostsAmountByThreadId(id);
                var model = await _forumService.ViewThreadPosts(id, pageSize, (int)Math.Ceiling((double)threadPostAmount / 10));
                return View(model);
            }
            else 
            {
                var model = await _forumService.ViewThreadPosts(id, pageSize, currentPage);
                return View(model);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> ViewThreadPosts(int threadId, int pageSize, int currentPage)
        {
            var model = await _forumService.ViewThreadPosts(threadId, pageSize, currentPage);
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
        public async Task<IActionResult> AddThreadPost(NewPostVm model)
        {
            var user = await _userManager.GetUserAsync(User);
            model.UserId = user.Id;
            _forumService.AddThreadPost(model);
            return RedirectToAction("ViewThreadPosts", new { id = model.ThreadId, lastpage = true });
        }

        [HttpGet]
        public IActionResult DeleteThreadPost(int id, int threadId, int pageSize, int currentPage)
        {
            _forumService.DeletePost(id);
            return RedirectToAction("ViewThreadPosts", new { id = threadId, pageSize = pageSize, currentPage = currentPage});
        }

        [HttpGet]
        public IActionResult DeleteThread(int id)
        {
            _forumService.DeleteThread(id);
            return RedirectToAction("Index");
        }

    }
}
