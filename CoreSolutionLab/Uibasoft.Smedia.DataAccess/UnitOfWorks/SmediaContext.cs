using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Uibasoft.Smedia.Core.Entities;

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
        public virtual DbSet<Security> Securities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CommentConfig());
            //modelBuilder.ApplyConfiguration(new PostConfig());
            //modelBuilder.ApplyConfiguration(new UserConfig());
            //modelBuilder.ApplyConfiguration(new SecurityConfig());            

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}
