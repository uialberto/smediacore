using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.Interfaces;
using Uibasoft.Smedia.DataAccess.UnitOfWorks;

namespace Uibasoft.Smedia.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmediaContext _context;

        private readonly IRepoPost _repoPost;
        private readonly IRepository<User> _repoUser;
        private readonly IRepository<Comment> _repoComment;

        public UnitOfWork(SmediaContext context)
        {
            _context = context;
        }
        public IRepoPost RepoPost => _repoPost ?? new RepoPost(_context);

        public IRepository<User> RepoUser => _repoUser ?? new BaseRepository<User>(_context);

        public IRepository<Comment> RepoComment => _repoComment ?? new BaseRepository<Comment>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context?.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
