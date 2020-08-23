using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;

namespace Uibasoft.Smedia.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepoPost RepoPost { get; }
        IRepository<User> RepoUser { get; }
        IRepository<Comment> RepoComment { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
