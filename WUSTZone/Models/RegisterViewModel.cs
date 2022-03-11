using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WUSTZone.Domain.Enums;

namespace WUSTZone.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "请输入用户名")]
        [RegularExpression(@"^[a-zA-Z_].{3,15}$", ErrorMessage = "以字母或下划线开头，长度为4-16")]
        public string UserName { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }

        [Display(Name = "确认密码")]
        [Required(ErrorMessage = "请再次输入密码")]
        [Compare("Password", ErrorMessage = "两次密码输入不一致")]
        public string PasswordConform { get; set; }

        [Display(Name = "性别")]
        [Required(ErrorMessage = "请选择性别")]
        [MaxLength(2)]
        public string Gender { get; set; }

        [Display(Name = "头像")]
        public IFormFile Photo { get; set; }

        [Display(Name = "学院")]
        [Required(ErrorMessage = "请选择学院")]
        public CollegeEnum? College { get; set; }

        [Display(Name = "简介")]
        public string Brief { get; set; }


        //用于回显数据

        [Display(Name = "头像路径")]
        public string PhotoPath { get; set; }

        [Display(Name ="学院名")]
        public string ColleageStr { get; set; }
    }
}
