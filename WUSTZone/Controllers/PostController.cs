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
    public class PostController : Controller
    {

        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PostController(IPostRepository postRepository, IUserRepository userRepository,IWebHostEnvironment webHostEnvironment)
        {
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
                string photoNameCSV = null;
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
                    Content = postViewModel.Content,
                    Photo = photoNameCSV,
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


        public IActionResult Delete(int id)
        {
            _postRepository.Delete(id);
            return RedirectToAction("myspace", "home");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
           
            return View(_postRepository.GetPost(id));
        }
        [HttpPost]
        public IActionResult Update(Post post)
        {
            

            return RedirectToAction("myspace", "home");
        }
    }
}
