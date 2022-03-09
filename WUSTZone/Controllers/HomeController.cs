using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WUSTZone.Domain.Entityies;
using WUSTZone.Domain.Repositories;
using WUSTZone.Models;

namespace WUSTZone.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, IPostRepository postRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");
            IEnumerable<Post> posts = _postRepository.GetAllPosts();
            // 处理为Index页面要展示的内容
            List<IndexViewModel> model = new List<IndexViewModel>();
            foreach (var post in posts)
            {
                model.Add(new IndexViewModel
                {
                    Title = post.Title,
                    UserName = _userRepository.GetUser(post.UserId).UserName,
                    TimeStamp = post.TimeStamp,
                    Category = post.Category,
                    Condensed = post.Condensed,
                    IsPinned = post.IsPinned,
                    IsSelected = post.IsSelected,
                    CommentCount = post.CommentCount,
                    LikeCount = post.LikeCount
                });
            }
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
