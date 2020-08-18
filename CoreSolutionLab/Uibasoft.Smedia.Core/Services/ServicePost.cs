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
        private readonly IRepoPost _repoPost;
        private readonly IRepoUser _repoUser;
        public ServicePost(IRepoPost pRepoPost, IRepoUser pRepoUser)
        {
            _repoPost = pRepoPost;
            _repoUser = pRepoUser;
        }

        public async Task<bool> DeletePost(int id)
        {
           return await _repoPost.DeletePost(id);
        }

        public async Task<Post> GetPost(int id)
        {
            return await _repoPost.GetPost(id);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _repoPost.GetPosts();
        }

        public async Task Insert(Post post)
        {
            var user = await _repoUser.GetUser(post.UserId);
            if (user == null)
            {
                throw new Exception("Usuario no existe");
            }
            if (post.Description.Contains("Sexo"))
            {
                throw new Exception("Contiene Sexo.");
            }
            await _repoPost.Insert(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
           return  await _repoPost.UpdatePost(post);
        }
    }
}
