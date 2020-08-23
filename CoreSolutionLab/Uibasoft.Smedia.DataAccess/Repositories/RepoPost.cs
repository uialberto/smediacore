using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.Interfaces;
using Uibasoft.Smedia.DataAccess.UnitOfWorks;

namespace Uibasoft.Smedia.DataAccess.Repositories
{
    public class RepoPost : BaseRepository<Post>, IRepoPost
    {
        public RepoPost(SmediaContext context): base(context)
        {

        }
        public async Task<IEnumerable<Post>> GetPostsByUser(int userId)
        {
            return await _entities.Where(ele => ele.UserId == userId).ToListAsync();
        }
    }
}
