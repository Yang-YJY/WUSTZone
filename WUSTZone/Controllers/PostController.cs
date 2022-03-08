using Microsoft.AspNetCore.Mvc;
using WUSTZone.Domain.Entityies;
using WUSTZone.Domain.Repositories;

namespace WUSTZone.Controllers
{
    public class PostController : Controller
    {

        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Add(Post post)
        {

            ////验证类型和内容非空
            //if (ModelState.IsValid)
            //{
            //    Post newPost = new Post()
            //    {
            //        UserId = post.UserId,
            //        TimeStamp = System.DateTime.Now,
            //        Category = post.Category,
            //        LikeCount = 0,
            //        CommentCount = 0,
            //        IsPinned = false,
            //        IsSelected = false,
            //        Content = post.Content

            //    };

            //    _postRepository.Add(newPost);

            //    //应该要跳转到首页，这里到时候需要改改
            //    return RedirectToAction("Index");


            //}

            return View(post);
        }



    }
}
