using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.Interfaces;

namespace Smedia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Se activan validaciones de modelo otras funcionales de http
    public class PostController : ControllerBase
    {
        private readonly IRepoPost _repoPost;
        public PostController(IRepoPost repoPost)
        {
            _repoPost = repoPost ?? throw new ArgumentNullException(nameof(repoPost));
        }
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _repoPost.GetPosts();
            return Ok(posts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _repoPost.GetPost(id);
            return Ok(post);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {
            await _repoPost.Insert(post);
            return Ok(post);
        }
    }
}
