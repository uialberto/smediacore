using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Smedia.WebApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.DTOs;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.Interfaces;
using Uibasoft.Smedia.Core.QueryFilters;
using Uibasoft.Smedia.Core.Services;

namespace Smedia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IServicePost _servicePost;
        private readonly IMapper _mapper;
        public PostController(IServicePost pServicePost, IMapper pMapper)
        {
            _servicePost = pServicePost ?? throw new ArgumentNullException(nameof(pServicePost));
            _mapper = pMapper ?? throw new ArgumentNullException(nameof(pMapper));
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<PostDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<PostDto>>))]
        public IActionResult GetPosts([FromQuery] PostQueryFilter filters)
        {
            var posts = _servicePost.GetPosts(filters);
            var postsDtos = _mapper.Map<IEnumerable<PostDto>>(posts);
            var response = new ApiResponse<IEnumerable<PostDto>>(postsDtos);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _servicePost.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _servicePost.Insert(post);
            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);            
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;
            var result = await  _servicePost.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {            
            var result = await _servicePost.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
