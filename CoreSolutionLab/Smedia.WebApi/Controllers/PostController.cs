using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Interfaces;
using Uibasoft.Smedia.DataAccess.Repositories;

namespace Smedia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IRepoPost _repoPost;
        public PostController(IRepoPost  repoPost)
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
    }
}
