using System.Collections.Generic;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;

namespace Uibasoft.Smedia.Core.Interfaces
{
    public interface IRepoPost
    {
        Task<IEnumerable<Publicacion>> GetPosts();
    }
}
