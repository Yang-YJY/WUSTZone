using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WUSTZone.Domain;
using WUSTZone.Domain.Repositories;
using WUSTZone.Models;

namespace WUSTZone.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
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
    }
}
