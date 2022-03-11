using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using WUSTZone.Domain.Entityies;
using WUSTZone.Domain.Enums;
using WUSTZone.Domain.Repositories;
using WUSTZone.Models;

namespace WUSTZone.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PostController(IPostRepository postRepository, IUserRepository userRepository,ICommentRepository commentRepository, IWebHostEnvironment webHostEnvironment)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

    
        /// <summary>
        /// 处理Get请求，返回发帖页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Add()
        {
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");
            return View();
        }

        /// <summary>
        /// 处理发帖页面提交过来的表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                string photoNameCSV = "";
                if (postViewModel.Photos != null)
                {
                    foreach (var photo in postViewModel.Photos)
                    {
                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads", "post_photo");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
                        photoNameCSV += (uniqueFileName + ",");
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            // 流转换为文件存入文件夹
                            photo.CopyTo(fileStream);
                        }
                    }
                }
                // 新建Post实体
                Post newPost = new Post
                {
                    UserId = _userRepository.GetUser(User.Identity.Name).Id,
                    Title = postViewModel.Title,
                    Category = (CategoryEnum)postViewModel.Category,
                    Content = postViewModel.Content.Replace("\n","<br/>").Replace(" ", "&nbsp;"),
                    Photo = photoNameCSV == "" ? "" : photoNameCSV.Substring(0, photoNameCSV.Length - 1),
                    Condensed = postViewModel.Content.Substring(0, Math.Min(postViewModel.Content.Length - 1, 100)),
                    LikeCount = 0,
                    CommentCount = 0,
                    IsPinned = false,
                    IsSelected = false
                };
                _postRepository.Add(newPost);
                return RedirectToAction("index", "home");
            }
            return View();
        }


        //private static void recursionDelete(int id)
        //{
        //    List<Comment> commentList = _commentRepository.GetByFatherId(id);//一级评论下有子评论
        //    if(commentList != null)
        //    {
        //        foreach (Comment comment in commentList)
        //        {
        //            List<Comment> subCommnetList = _commentRepository.GetByFatherId(comment.FatherId);
        //            if(subCommnetList != null)
        //            {
        //                recursionDelete(comment.Id);
        //                _commentRepository.Delete(comment.Id);
        //            }
        //            else
        //            {
        //                _commentRepository.Delete(comment.Id);
        //            }
        //        }
        //    }
        //    else//一级评论下没有子评论
        //    {
        //        _commentRepository.Delete(id);
        //    }
        //}

        public IActionResult Delete(int id)
        {

            _postRepository.Delete(id);

            //List<Comment> commentList = _commentRepository.GetByPostId(id);

            //foreach (Comment comment in commentList)
            //{
            //    recursionDelete(comment.id);//找到所有一级评论
            //}


            return RedirectToAction("myspace", "home");


        }


        [HttpGet]
        public IActionResult Update(int id)
        {

            Post post = _postRepository.GetPost(id);           

            if(post == null)
            {
                return RedirectToAction("myspace", "home");
            }
            return View(post);
        }


        [HttpPost]
        public IActionResult Update(Post newPost)
        {
            Post post = _postRepository.GetPost(newPost.Id);

            post.Content = newPost.Content;

            post.Category = newPost.Category;

            post.Condensed = newPost.Content.Substring(0, Math.Min(newPost.Content.Length - 1, 100));

            _postRepository.Update(post);

            return RedirectToAction("myspace", "home");
        }
    }
}
