using System.Collections.Generic;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;

namespace Uibasoft.Smedia.Core.Services
{
    public interface IServicePost
    {
        Task Insert(Post post);
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(int id);        
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }
}