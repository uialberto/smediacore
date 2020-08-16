using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Smedia.WebApi.Responses;
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
            var response = new ApiResponse<IEnumerable<PostDto>>(postsDtos);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _repoPost.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _repoPost.Insert(post);
            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);            
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.PostId = id;
            var result =  await _repoPost.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {            
            var result = await _repoPost.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
