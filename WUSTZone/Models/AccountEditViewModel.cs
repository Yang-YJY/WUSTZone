using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WUSTZone.Models
{
    public class AccountEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "用户名")]
        [Required(ErrorMessage = "请输入用户名")]
        [RegularExpression(@"^[a-zA-Z_][a-zA-Z0-9_]{3,15}$", ErrorMessage = "以字母或下划线开头，由字母或数字或下划线组成，长度为4-16")]
        public string UserName { get; set; }

        [Display(Name = "性别")]
        [Required(ErrorMessage = "请选择性别")]
        [MaxLength(2)]
        public string Gender { get; set; }

        [Display(Name = "头像")]
        public IFormFile Photo { get; set; }

        public string ExistingPhotoPath { get; set; }

        [Display(Name = "学院")]
        [Required(ErrorMessage = "请选择学院")]
        [MaxLength(20)]
        public string College { get; set; }

        [Display(Name = "简介")]
        public string Brief { get; set; }
    }
}
