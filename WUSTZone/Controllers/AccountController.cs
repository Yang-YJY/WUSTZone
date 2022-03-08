using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WUSTZone.Domain;
using WUSTZone.Domain.Entityies;
using WUSTZone.Domain.Enums;
using WUSTZone.Domain.Repositories;
using WUSTZone.Models;

namespace WUSTZone.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AccountController(IUserRepository userRepository, IWebHostEnvironment webHostEnvironment)
        {
            _userRepository = userRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 用户登录视图，返回用户登录视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        /// <summary>
        /// 处理用户登录请求，登陆成功则跳转至主页面
        /// </summary>
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                // 判断账号密码正确性
                var user = _userRepository.GetUser(loginViewModel.UserName, loginViewModel.Password);
                if (user != null)
                {
                    // 进行登录授权
                    var claims = new List<Claim>()
                    {
                        // 添加用户ID
                        new Claim(ClaimTypes.Sid, user.Id.ToString()),
                        // 添加用户名数据
                        new Claim(ClaimTypes.Name, user.UserName)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // 发送token给客户端，并生成cookies
                    HttpContext
                        .SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        new AuthenticationProperties
                        {
                            // 永久登录 默认两个星期
                            IsPersistent = true
                        });
                    return RedirectToAction("Index", "home");
                }
            }
            // 否则返回原视图
            return View();
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("login");
        }

        /// <summary>
        /// 处理注册用户的Get请求，返回注册页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        /// <summary>
        /// 处理注册用户的Poat请求，处理数据
        /// </summary>
        /// <param name="registerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                // 头像上传路径
                string uniqueFileName = null;
                if (registerViewModel.Photo != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads", "user_photo");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + registerViewModel.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        // 流转换为文件存入文件夹
                        registerViewModel.Photo.CopyTo(fileStream);
                    }

                    CollegeEnum college = (CollegeEnum)registerViewModel.College;

                    // 创建新用户
                    User newUser = new User
                    {
                        UserName = registerViewModel.UserName,
                        Password = registerViewModel.Password,
                        Gender = registerViewModel.Gender,
                        PhotoPath = uniqueFileName,
                        College = college.GetString(),
                        Brief = registerViewModel.Brief
                    };

                    _userRepository.AddUser(newUser);
                    return RedirectToAction("login");
                }
            }
            return View();
        }
    }
}
