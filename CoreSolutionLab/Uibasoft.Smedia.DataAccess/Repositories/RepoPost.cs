using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uibasoft.Smedia.Core.Entities;

namespace Uibasoft.Smedia.DataAccess.Repositories
{
    public class RepoPost
    {
        public IEnumerable<Post> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(ele => new Post()
            {
                PostId = ele,
                Description = $"Descripcion {ele}",
                Date = DateTime.Now,
                Image = $"https://misapis.com/{ele}",
                UserId = ele * 2
            });

            return posts;
        }
    }
}
