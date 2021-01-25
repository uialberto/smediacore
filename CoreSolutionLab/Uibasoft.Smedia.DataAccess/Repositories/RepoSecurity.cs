using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.Interfaces;
using Uibasoft.Smedia.DataAccess.UnitOfWorks;

namespace Uibasoft.Smedia.DataAccess.Repositories
{
    public class RepoSecurity : BaseRepository<Security>, IRepoSecurity
    {
        public RepoSecurity(SmediaContext context) : base(context)
        {

        }

        public async Task<Security> GetLoginByCredential(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(ele => ele.Username == login.User);
        }
    }
}
