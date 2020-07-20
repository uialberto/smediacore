using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.DataAccess.Mapping;

namespace Uibasoft.Smedia.DataAccess.UnitOfWorks
{
    public partial class SmediaContext : DbContext
    {
        public SmediaContext()
        {
        }

        public SmediaContext(DbContextOptions<SmediaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration(new PostConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
        
    }
}
