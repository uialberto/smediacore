using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;
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
            if (user == null)
            {
                throw new Exception("Usuario no existe");
            }
            if (post.Description.Contains("Sexo"))
            {
                throw new Exception("Contiene Sexo.");
            }
            await _unitOfWork.RepoPost.Add(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
           await _unitOfWork.RepoPost.Update(post);
            return true;
        }
    }
}
