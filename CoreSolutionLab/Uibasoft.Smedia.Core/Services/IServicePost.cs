using System.Collections.Generic;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.CustomEntities;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.QueryFilters;

namespace Uibasoft.Smedia.Core.Services
{
    public interface IServicePost
    {
        Task Insert(Post post);
        PageList<Post> GetPosts(PostQueryFilter filters);
        Task<Post> GetPost(int id);        
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }
}