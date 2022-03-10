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
        private readonly ICommentRepository _commentRepository;
        private readonly int _pageSize;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _postRepository = postRepository;
            _commentRepository = commentRepository;
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

        /// <summary>
        /// 查看id为id的留言内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Detail(int id)
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");
            Post post = _postRepository.GetPost(id);
            List<Comment> comments = _commentRepository.GetByPostId(id);
            User postUser = _userRepository.GetUser(post.UserId);
            // 构建ViewModel
            PostDetailViewModel model = new PostDetailViewModel
            {
                Id = post.Id,
                UserName = postUser.UserName,
                UserPhotoPath = "/uploads/user_photo/" + (postUser.PhotoPath ?? "default.png"),
                TimeStamp = post.TimeStamp,
                Title = post.Title,
                Category = post.Category,
                IsSelected = post.IsSelected,
                Content = post.Content,
                PhotoPaths = post.Photo == null ? new List<string>() : post.Photo.Split(',').ToList(),
                LikeCount = post.LikeCount,
                CommentCount = post.CommentCount
            };
            // 构建ViewModel中的Comments
            List<CommentViewModel> commentViewModels = new List<CommentViewModel>();
            foreach (var comment in comments)
            {
                User commentUser = _userRepository.GetUser(comment.UserId);
                CommentViewModel commentViewModel = new CommentViewModel
                {
                    Id = comment.Id,
                    UserName = commentUser.UserName,
                    UserPhotoPath = "/uploads/user_photo/" + (commentUser.PhotoPath ?? "default.png"),
                    TimeStamp = comment.TimeStamp,
                    Content = comment.Content
                };
                // 构建Comments中的SubComments
                List<BasicCommentViewModel> basicCommentViewModels = new List<BasicCommentViewModel>();
                List<Comment> subComments = _commentRepository.GetByFatherId(comment.Id);
                foreach (var subComment in subComments)
                {
                    User subCommentUser = _userRepository.GetUser(subComment.UserId);
                    basicCommentViewModels.Add(new BasicCommentViewModel {
                        Id = subComment.Id,
                        UserName = subCommentUser.UserName,
                        UserPhotoPath = "/uploads/user_photo/" + (subCommentUser.PhotoPath ?? "default.png"),
                        TimeStamp = subComment.TimeStamp,
                        Content = subComment.Content
                    });
                }
                commentViewModel.SubComments = basicCommentViewModels;
                commentViewModels.Add(commentViewModel);
            }
            model.Comments = commentViewModels;

            return View(model);
        }

        public IActionResult MySpace(int? pageIndex)
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");
            ViewBag.PageCount = GetPosts(_pageSize, pageIndex ?? 1, false, currentUser.Id, out var subList, out int currentIndex);
            ViewBag.CurrentIndex = currentIndex;
            return View(trasfer(subList));
        }

        /// <summary>
        /// 给某个帖子点赞
        /// </summary>
        /// <param name="postId"></param>
        [HttpPost]
        public IActionResult LikePost(int postId)
        {
            Post post = _postRepository.GetPost(postId);
            post.LikeCount += 1;
            _postRepository.Update(post);
            return RedirectToAction("detail", new { id = postId });
        }

        /// <summary>
        /// 给某个帖子评论
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CommentPost(int postId, string comment)
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            Comment newComment = new Comment
            {
                PostId = postId,
                FatherId = 0,
                Content = comment,
                UserId = currentUser.Id
            };
            _commentRepository.Add(newComment);
            Post post = _postRepository.GetPost(postId);
            post.CommentCount += 1;
            _postRepository.Update(post);

            return RedirectToAction("detail", new { id = postId });
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
                    PostId = post.Id,
                    Content = post.Content,
                    
                }); ;
            }
            return model;
        }


        //重构函数，不要删除
        private int GetPosts(int pageSize, int pageIndex, bool selected, int id, out List<Post> posts, out int currentIndex)
        {
            IEnumerable<Post> postList = null;
            if (selected)
            {
                postList = _postRepository.GetPostsBySelected();
            }
            postList = _postRepository.GetPostsByUserId(id);
            // 总页数
            int pageCount = (int)Math.Ceiling((double)postList.Count() / pageSize);
            pageIndex = pageIndex >= pageCount ? pageCount : pageIndex;
            currentIndex = pageIndex;

            //分页，类似java 的subList操作
            posts = postList.Skip((int)((pageIndex - 1) * pageSize)).Take(pageSize).ToList();

            return pageCount;
        }


    }
}
