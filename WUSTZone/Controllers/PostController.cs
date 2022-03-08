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
        private readonly IWebHostEnvironment webHostEnvironment;

        public PostController(IPostRepository postRepository,IWebHostEnvironment webHostEnvironment)
        {
            _postRepository = postRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

    
        public IActionResult Add(PostViewModel model)
        {

            //验证类型和内容非空
            if (ModelState.IsValid)
            {
                List<string> photoList = new List<string>(); 

                string uniqueFileName = null;

                if (model.Photos!=null && model.Photos.Count > 0)
                {
                    foreach(var photo in model.Photos)
                    {
                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads", "post_photo");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));

                    }
                }

                uniqueFileName = "";

                for(int i = 0; i < photoList.Count-1; i++)
                {
                    uniqueFileName = uniqueFileName + photoList[i] + ":";
                }
                if(photoList.Count > 0)
                {
                    uniqueFileName = uniqueFileName + photoList[photoList.Count - 1];
                }
                

                Post newPost = new Post()
                {
                    UserId = model.UserId,
                    TimeStamp = System.DateTime.Now,
                    Category = PostEnumExtensions.GetString(model.Category),
                    LikeCount = 0,
                    CommentCount = 0,
                    IsPinned = false,
                    IsSelected = false,
                    Content = model.Content,
                    Photo = uniqueFileName
                };

                _postRepository.Add(newPost);

                return RedirectToAction("Index", "home");
            }
            return View(model);
        }



    }
}
