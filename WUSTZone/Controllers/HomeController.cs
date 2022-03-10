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
        private readonly int _pageSize;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, IPostRepository postRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _postRepository = postRepository;
            _pageSize = 10;
        }


        public IActionResult Index(int? pageIndex)
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");
            ViewBag.PageCount = GetPosts(_pageSize, pageIndex ?? 1, false, null, out var subList , out int currentIndex);
            ViewBag.CurrentIndex = currentIndex;
            return View(trasfer(subList));
        }


        public IActionResult Gossip(int? pageIndex)
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");
            ViewBag.PageCount = GetPosts(_pageSize, pageIndex ?? 1, false, CategoryEnum.Gossip, out var subList, out int currentIndex);
            ViewBag.CurrentIndex = currentIndex;
            return View(trasfer(subList));

        }


        public IActionResult SeekHelp(int? pageIndex)
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");
            ViewBag.PageCount = GetPosts(_pageSize, pageIndex ?? 1, false, CategoryEnum.SeekHelp, out var subList, out int currentIndex);
            ViewBag.CurrentIndex = currentIndex;
            return View(trasfer(subList));

        }

        public IActionResult TreeHole(int? pageIndex)
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");
            ViewBag.PageCount = GetPosts(_pageSize, pageIndex ?? 1, false, CategoryEnum.TreeHole, out var subList, out int currentIndex);
            ViewBag.CurrentIndex = currentIndex;
            return View(trasfer(subList));

        }


        public IActionResult Selected(int? pageIndex)
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");
            ViewBag.PageCount = GetPosts(_pageSize, pageIndex ?? 1, true, null, out var subList, out int currentIndex);
            ViewBag.CurrentIndex = currentIndex;
            return View(trasfer(subList));

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /// <summary>
        /// 获取分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="posts"></param>
        /// <param name="category"></param>
        /// <returns>返回页面数量</returns>
        private int GetPosts(int pageSize, int pageIndex, bool selected, CategoryEnum? category, out List<Post> posts, out int currentIndex)
        {
            IEnumerable<Post> postList = null;
            if (selected)
            {
                postList = _postRepository.GetPostsBySelected();
            }
            else if (category == null)
            {
                postList = _postRepository.GetAllPosts();
            }
            else {
                switch (category)
                {
                    case CategoryEnum.Gossip: postList = _postRepository.GetPostsByCategory(CategoryEnum.Gossip); break;
                    case CategoryEnum.SeekHelp: postList = _postRepository.GetPostsByCategory(CategoryEnum.SeekHelp); break;
                    case CategoryEnum.TreeHole: postList = _postRepository.GetPostsByCategory(CategoryEnum.TreeHole); break;
                } 
            }
            // 总页数
            int pageCount = (int)Math.Ceiling((double)postList.Count() / pageSize);
            pageIndex = pageIndex >= pageCount ? pageCount : pageIndex;
            currentIndex = pageIndex;

            //分页，类似java 的subList操作
            posts = postList.Skip((int)((pageIndex - 1) * pageSize)).Take(pageSize).ToList();

            return pageCount;
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
                    //测试正常，UserName暂时定死，等有正式数据在改，不然会出现用户找不到的情况，
                    //UserName = "GM",
                    TimeStamp = post.TimeStamp,
                    Category = CategoryEnumExtensions.GetString(post.Category),
                    LikeCount = post.LikeCount,
                    CommentCount = post.CommentCount,
                    IsPinned = post.IsPinned,
                    IsSelected = post.IsSelected,
                    Condensed = post.Condensed,
                    PostId = post.Id
                });
            }
            return model;
        }



        public IActionResult MySpace(int?pageIndex)
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
            postList = _postRepository.GetPostsByUserId(currentUser.Id);
            //分页，类似java 的subList操作
            List<Post> subList = postList.Skip((int)((pageIndex - 1) * pageSize)).Take(pageSize).ToList();
            return View(trasfer(subList));
        }

    }
}
