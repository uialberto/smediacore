using System;
using System.Collections.Generic;
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
        public Task<IEnumerable<Post>> GetPostsByUser(int idUser)
        {
            throw new NotImplementedException();
        }
    }
}
