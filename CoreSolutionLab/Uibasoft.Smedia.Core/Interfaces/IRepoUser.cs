using System.Collections.Generic;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;

namespace Uibasoft.Smedia.Core.Interfaces
{
    public interface IRepoUser
    {        
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
    }
}