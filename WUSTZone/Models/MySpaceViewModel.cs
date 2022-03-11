using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WUSTZone.Models
{
    public class MySpaceViewModel
    {
        public string UserName { get; set; }
        public string UserPhotoPath { get; set; }
        public string Gender { get; set; }
        public string College { get; set; }
        public string Brief { get; set; }
        public List<IndexViewModel> Posts { get; set; }
    }
}
