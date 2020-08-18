using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.Interfaces;
using Uibasoft.Smedia.DataAccess.UnitOfWorks;

namespace Uibasoft.Smedia.DataAccess.Repositories
{
    public class RepoUser : IRepoUser
    {
        private readonly SmediaContext _context;
        public RepoUser(SmediaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var entities = await _context.Users.ToListAsync();
            return entities;
        }

        public async Task<User> GetUser(int id)
        {
            var entitie = await _context.Users.FirstOrDefaultAsync(ele => ele.UserId == id);
            return entitie;
        }
    }
}
