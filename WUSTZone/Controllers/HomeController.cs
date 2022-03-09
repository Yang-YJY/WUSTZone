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
using WUSTZone.Domain.Enums;
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

        public IActionResult Index(int? pageIndex)
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");

            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            //每一页大小
            int pageSize = 10;
            IEnumerable<Post> postList = null;
            postList = _postRepository.GetAllPosts();
            //分页，类似java 的subList操作
            List<Post> subList = postList.Skip((int)((pageIndex - 1) * pageSize)).Take(pageSize).ToList();
            return View(trasfer(subList));

        }

        public IActionResult Gossip(int? pageIndex)
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");
            //每一页大小
            int pageSize = 10;
            if(pageIndex == null)
            {
                pageIndex = 1;
            }
            IEnumerable<Post> postList = null;
            postList = _postRepository.GetPostsByCategory(CategoryEnum.Gossip);
            //分页，类似java 的subList操作
            List<Post> subList = postList.Skip((int)((pageIndex - 1) * pageSize)).Take(pageSize).ToList();
            return View(trasfer(subList));

        }


        public IActionResult SeekHelp(int? pageIndex)
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");
            //每一页大小
            int pageSize = 10;
            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            IEnumerable<Post> postList = null;
            postList = _postRepository.GetPostsByCategory(CategoryEnum.SeekHelp);
            //分页，类似java 的subList操作
            List<Post> subList = postList.Skip((int)((pageIndex - 1) * pageSize)).Take(pageSize).ToList();
            return View(trasfer(subList));

        }

        public IActionResult TreeHole(int? pageIndex)
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");
            //每一页大小
            int pageSize = 10;
            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            IEnumerable<Post> postList = null;
            postList = _postRepository.GetPostsByCategory(CategoryEnum.TreeHole);
            //分页，类似java 的subList操作
            List<Post> subList = postList.Skip((int)((pageIndex - 1) * pageSize)).Take(pageSize).ToList();
            return View(trasfer(subList));

        }


        public IActionResult Selected(int? pageIndex)
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");
            //每一页大小
            int pageSize = 10;
            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            IEnumerable<Post> postList = null;
            postList = _postRepository.GetPostsBySelected();
            //分页，类似java 的subList操作
            List<Post> subList = postList.Skip((int)((pageIndex - 1) * pageSize)).Take(pageSize).ToList();
            return View(trasfer(subList));

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<IndexViewModel> trasfer(List<Post> posts)
        {
            // 转换为IndexViewModel
            List<IndexViewModel> model = new List<IndexViewModel>();
            foreach (var post in posts)
            {
                model.Add(new IndexViewModel
                {
                    Title = post.Title,
                    UserName = _userRepository.GetUser(post.UserId).UserName,
                    TimeStamp = post.TimeStamp,
                    Category = post.Category.GetString(),
                    LikeCount = post.LikeCount,
                    CommentCount = post.CommentCount,
                    IsPinned = post.IsPinned,
                    IsSelected = post.IsSelected,
                    Condensed = post.Condensed
                });
            }
            return model;
        }
    }
}
