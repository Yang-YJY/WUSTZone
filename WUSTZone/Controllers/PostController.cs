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
            if (ModelState.IsValid)
            {

            }

            return View();
        }



    }
}
