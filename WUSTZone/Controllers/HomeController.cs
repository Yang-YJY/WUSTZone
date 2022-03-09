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

        private List<IndexViewModel> getAnsList(List<Post> postList)
        {
            List<IndexViewModel> ansList = new List<IndexViewModel>();
            foreach (Post post in postList)
            {
                IndexViewModel ans = new IndexViewModel();
                ans.Title = post.Title;
                ans.UserName = User.Identity.Name;
                ans.TimeStamp = post.TimeStamp;
                //ans.Category = post.Category;
                ans.LikeCount = post.LikeCount;
                ans.CommentCount = post.LikeCount;
                ans.IsPinned = post.IsPinned;
                ans.IsSelected = post.IsSelected;
                ans.Condensed = post.Condensed;
            }

            return ansList;
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
            List<IndexViewModel> ansList = getAnsList(subList);
            return View(ansList);

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
            postList = _postRepository.GetPostsByCategory(1);
            //分页，类似java 的subList操作
            List<Post> subList = postList.Skip((int)((pageIndex - 1) * pageSize)).Take(pageSize).ToList();
            List<IndexViewModel> ansList = getAnsList(subList);
            return View(ansList);

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
            postList = _postRepository.GetPostsByCategory(2);
            //分页，类似java 的subList操作
            List<Post> subList = postList.Skip((int)((pageIndex - 1) * pageSize)).Take(pageSize).ToList();
            List<IndexViewModel> ansList = getAnsList(subList);
            return View(ansList);

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
            postList = _postRepository.GetPostsByCategory(3);
            //分页，类似java 的subList操作
            List<Post> subList = postList.Skip((int)((pageIndex - 1) * pageSize)).Take(pageSize).ToList();
            List<IndexViewModel> ansList = getAnsList(subList);
            return View(ansList);

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
            List<IndexViewModel> ansList = getAnsList(subList);
            return View(ansList);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
