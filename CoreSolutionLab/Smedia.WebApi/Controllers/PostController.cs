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
    [ApiController] // Se activan validaciones de modelo otras funcionales de http
    public class PostController : ControllerBase
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
            var posts = await _repoPost.GetPosts();
            var postsDtos = _mapper.Map<IEnumerable<PostDto>>(posts);
            //var postsDtos = posts.Select(ele => new PostDto()
            //{
            //    PostId = ele.PostId,
            //    Date = ele.Date,
            //    Description = ele.Description,
            //    Image = ele.Image,
            //    UserId = ele.UserId
            //});
            return Ok(postsDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _repoPost.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);
            //var postDto = new PostDto()
            //{
            //    PostId = post.PostId,
            //    Date = post.Date,
            //    Description = post.Description,
            //    Image = post.Image,
            //    UserId = post.UserId
            //};
            return Ok(postDto);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            //var post = new Post()
            //{                
            //    Date = postDto.Date,
            //    Description = postDto.Description,
            //    Image = postDto.Image,
            //    UserId = postDto.UserId
            //};
            var post = _mapper.Map<Post>(postDto);
            await _repoPost.Insert(post);
            return Ok(post);
        }
    }
}
