using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.Exceptions;
using Uibasoft.Smedia.Core.Interfaces;

namespace Uibasoft.Smedia.Core.Services
{
    public class ServicePost : IServicePost
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ServicePost(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

        public async Task<bool> DeletePost(int id)
        {
           await _unitOfWork.RepoPost.Delete(id);
           return true;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.RepoPost.GetById(id);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _unitOfWork.RepoPost.GetAll();
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
           await _unitOfWork.RepoPost.Update(post);
            return true;
        }
    }
}
