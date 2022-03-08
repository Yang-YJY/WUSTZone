using System.ComponentModel.DataAnnotations;

namespace WUSTZone.Domain.Enums
{
    public enum PostEnum
    {
        [Display(Name = "默认类型")]
        DefaultType,
        [Display(Name = "闲聊")]
        Gossip,
        [Display(Name = "求助")]
        SeekHelp,
        [Display(Name = "树洞")]
        TreeHole

    }

    public static class PostEnumExtensions
    {
        public static string GetString(this PostEnum postEnum)
        {
            switch (postEnum)
            {
                case PostEnum.Gossip: return "闲聊";
                case PostEnum.SeekHelp: return "求助";
                case PostEnum.TreeHole: return "树洞";
                default: return "默认类型";
            }
        }
    }
}