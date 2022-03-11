using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WUSTZone.Domain.Enums;

namespace WUSTZone.Domain.Entityies
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "用户名")]
        [Required(ErrorMessage = "请输入用户名")]
        public string UserName { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }

        [Display(Name = "性别")]
        [Required(ErrorMessage = "请选择性别")]
        [MaxLength(2)]
        public string Gender { get; set; }

        [Display(Name = "头像")]
        public string PhotoPath { get; set; }

        [Display(Name = "学院")]
        [Required(ErrorMessage = "请选择学院")]
        [MaxLength(20)]
        public string College { get; set; }

        [Display(Name = "简介")]
        public string Brief { get; set; }
    }
}
