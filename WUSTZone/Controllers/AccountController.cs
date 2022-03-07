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
using WUSTZone.Models;

namespace WUSTZone.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AccountController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            // 判断账号密码正确性
            if (await _appDbContext.Users.AnyAsync(user => 
            user.UserName == loginViewModel.UserName && user.Password == loginViewModel.Password))
            {
                // 进行登录授权
                var claims = new List<Claim>()
                {
                    // 添加用户名数据
                    new Claim(ClaimTypes.Name, loginViewModel.UserName)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // 发送token给客户端，并生成cookies
                await HttpContext
                    .SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        // 永久登录 默认两个星期
                        IsPersistent = true
                    });
            }
            else
            {
                // 否则返回原视图
                return RedirectToAction("Login");
            }

            return RedirectToAction("Index", "home");
        }

        // 退出用await HttpContext.SignOut
    }
}
