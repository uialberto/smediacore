using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(ele => ele.PostId == id);
            return post;
        }

        public async Task Insert(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }
    }
}
