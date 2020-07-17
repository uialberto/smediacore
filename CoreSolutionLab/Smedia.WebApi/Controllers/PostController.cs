using Microsoft.AspNetCore.Mvc;
using Uibasoft.Smedia.DataAccess.Repositories;

namespace Smedia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts = new RepoPost().GetPosts();
            return Ok(posts);
        }
    }
}
