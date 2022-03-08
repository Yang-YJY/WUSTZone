using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WUSTZone.Models
{
    /// <summary>
    /// 登录视图Request模型
    /// </summary>
    public class LoginViewModel
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "请输入用户名")]
        [RegularExpression(@"^[a-zA-Z_][a-zA-Z0-9_]{3,15}$", ErrorMessage = "以字母或下划线开头，由字母或数字或下划线组成，长度为4-16")]
        public string UserName { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }
    }
}
