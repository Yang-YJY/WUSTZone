using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WUSTZone.Domain.Enums
{
    public enum CategoryEnum
    {
        [Display(Name ="闲聊")]
        Gossip,
        [Display(Name ="求助")]
        SeekHelp,
        [Display(Name ="树洞")]
        TreeHole
    }

    public static class CategoryEnumExtensions
    {
        public static string GetString(this CategoryEnum category)
        {
            switch (category)
            {
                case CategoryEnum.Gossip: return "闲聊";
                case CategoryEnum.SeekHelp: return "求助";
                case CategoryEnum.TreeHole: return "树洞";
                default: return "默认";
            }
        }
    }
}
