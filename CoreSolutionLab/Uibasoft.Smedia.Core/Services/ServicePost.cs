﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.CustomEntities;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.Exceptions;
using Uibasoft.Smedia.Core.Interfaces;
using Uibasoft.Smedia.Core.QueryFilters;

namespace Uibasoft.Smedia.Core.Services
{
    public class ServicePost : IServicePost
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public ServicePost(IUnitOfWork unitOfWork, IOptions<PaginationOptions> pOptions)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = pOptions.Value;
        }

        public async Task<bool> DeletePost(int id)
        {
           await _unitOfWork.RepoPost.Delete(id);
            await _unitOfWork.SaveChangesAsync();
           return true;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.RepoPost.GetById(id);
        }

        public PageList<Post> GetPosts(PostQueryFilter filters)
        {

            filters.PageIndex = filters.PageIndex == 0 ? _paginationOptions.DefaultPageIndex : filters.PageIndex;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var posts = _unitOfWork.RepoPost.GetAll();

            #region Filtros

            if (filters.UserId.HasValue)
            {
                posts = posts.Where(ele => ele.UserId == filters.UserId);
            }
            if (filters.Date.HasValue)
            {
                posts = posts.Where(ele => ele.Date.ToShortDateString() == filters.Date?.ToShortDateString());
            }
            if (!string.IsNullOrWhiteSpace(filters.Description))
            {
                posts = posts.Where(ele => ele.Description.ToLower().Contains(filters.Description.ToLower()));
            }

            #endregion


            #region Paginacion

            var pagePosts = PageList<Post>.Create(posts, filters.PageIndex, filters.PageSize);
            
            #endregion


            return pagePosts;
        }

        public async Task Insert(Post post)
        {
            var user = await _unitOfWork.RepoUser.GetById(post.UserId);
            
            // Regla Negocio 1:            
            if (user == null)
            {
                throw new BussinesException("Usuario no se encuentra registrado.");
            }
            
            // Regla Negocio 3:            
            var userPost = await _unitOfWork.RepoPost.GetPostsByUser(post.UserId);
            
            // Regla Negocio 2:
            if (userPost.Count() < 10)
            {
                var lastPost = userPost.OrderByDescending(ele => ele.Date).FirstOrDefault();
                if ((DateTime.Now - lastPost.Date).TotalDays < 7)
                {
                    throw new BussinesException("No esta habilitado para publicar Post");
                }
            }

            if (post.Description.Contains("Sexo"))
            {
                throw new BussinesException("Contenido no permitido.");
            }
            await _unitOfWork.RepoPost.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
            var existingPost = await _unitOfWork.RepoPost.GetById(post.Id);
            existingPost.Image = post.Image;
            existingPost.Description = post.Description;

            _unitOfWork.RepoPost.Update(existingPost);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
