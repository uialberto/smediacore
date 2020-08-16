using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.DTOs;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.Interfaces;

namespace Smedia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ValidationFilter]
    public class PostController : ControllerBase // Controller si se quiere usar MVC
    {
        private readonly IRepoPost _repoPost;
        private readonly IMapper _mapper;
        public PostController(IRepoPost repoPost, IMapper pMapper)
        {
            _repoPost = repoPost ?? throw new ArgumentNullException(nameof(repoPost));
            _mapper = pMapper ?? throw new ArgumentNullException(nameof(pMapper));
        }
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            //Validacion Manual
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var posts = await _repoPost.GetPosts();
            var postsDtos = _mapper.Map<IEnumerable<PostDto>>(posts);
            return Ok(postsDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _repoPost.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);
            return Ok(postDto);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _repoPost.Insert(post);
            return Ok(post);
        }
    }
}
