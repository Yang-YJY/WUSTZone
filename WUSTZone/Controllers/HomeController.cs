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

        public IActionResult Index(int? pageIndex)
        {
            if(pageIndex == null)
            {
                pageIndex = 1;
            }
            //每一页大小
            int pageSize = 10;
            //分页，类似java 的subList操作
            User currentUser = _userRepository.GetUser(User.Identity.Name);
            ViewData["UserPhotoPath"] = "/uploads/user_photo/" + (currentUser.PhotoPath ?? "default.png");

            IEnumerable<Post> postList = _postRepository.GetAllPosts();

            List<Post> subList =  postList.Skip((int)((pageIndex - 1) * pageSize)).Take(pageSize).ToList();

            return View(subList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
