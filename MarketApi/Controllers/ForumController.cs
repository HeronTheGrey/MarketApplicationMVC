using MarketApplicationMVC.Application.Interfaces;
using MarketApplicationMVC.Application.ViewModel.Forum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApi.Controllers
{
    [Route("api/Forum")]
    [Authorize]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService;

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet]
        [Route("GetAllThreads")]
        public IEnumerable<ThreadForApiVm> GetAllThreads ()
        {
            var threads = _forumService.GetAllThreadsForApi();
            return threads;
        }

    }
}
