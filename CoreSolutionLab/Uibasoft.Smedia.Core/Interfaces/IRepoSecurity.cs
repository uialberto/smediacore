using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;

namespace Uibasoft.Smedia.Core.Interfaces
{
    public interface IRepoSecurity : IRepository<Security>
    {
        Task<Security> GetLoginByCredential(UserLogin login);
    }
}