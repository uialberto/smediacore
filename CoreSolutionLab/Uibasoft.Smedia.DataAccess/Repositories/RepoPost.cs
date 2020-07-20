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
    public class RepoPost : IRepoPost
    {
        private readonly SmediaContext _context;
        public RepoPost(SmediaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Publicacion>> GetPosts()
        {
            var posts = await _context.Publicacion.ToListAsync();
            return posts;
        }
    }
}
