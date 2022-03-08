using Microsoft.EntityFrameworkCore;
using WUSTZone.Domain.Entityies;

namespace WUSTZone.Domain
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1001,
                    UserId = 1,
                    TimeStamp = System.DateTime.Now,
                    Category = "树洞",
                    LikeCount = 0,
                    CommentCount = 0,
                    IsPinned = false,
                    IsSelected = false,
                    Content = "郭森泽二号",
                    Photo = "",
                    Condensed="",
                    Title = ""

                },
                new Post
                {
                    Id = 1002,
                    TimeStamp = System.DateTime.Now,
                    Category = "求助",
                    LikeCount = 0,
                    CommentCount = 0,
                    IsPinned = false,
                    IsSelected = false,
                    Content = "郭森泽一号",
                    Photo = "",
                    Condensed = "",
                    Title = ""

                },
                new Post
                {
                    Id = 1003,
                    TimeStamp = System.DateTime.Now,
                    Category = "闲聊",
                    LikeCount = 0,
                    CommentCount = 0,
                    IsPinned = false,
                    IsSelected = false,
                    Content = "郭森泽三号",
                    Photo = "",
                    Condensed = "",
                    Title = ""

                },
                new Post
                {
                    Id = 1004,
                    TimeStamp = System.DateTime.Now,
                    Category = "默认类型",
                    LikeCount = 0,
                    CommentCount = 0,
                    IsPinned = false,
                    IsSelected = false,
                    Content = "郭森泽四号",
                    Photo = "",
                    Condensed = "",
                    Title = ""

                }

                );
        }
    }
}
