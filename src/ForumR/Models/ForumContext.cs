using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using CodeComb.AspNet.Upload;
using CodeComb.AspNet.Upload.Models;

namespace ForumR.Models
{
    public class ForumContext : IdentityDbContext<User, IdentityRole<long>, long>, IFileUploadDbContext
    {
        public DbSet<Forum> Forums { get; set; }

        public DbSet<Thread> Threads { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.SetupFiles();

            builder.Entity<Thread>(e =>
            {
                e.HasIndex(x => x.IsTop);
                e.HasIndex(x => x.CreationTime);
                e.HasIndex(x => x.LastReplyTime);
                e.HasIndex(x => x.IsAnnouncement);
            });

            builder.Entity<Post>(e =>
            {
                e.HasIndex(x => x.Time);
            });

            builder.Entity<Forum>(e =>
            {
                e.Property(x => x.ParentId).IsRequired(false);
                e.HasIndex(x => x.PRI);
            });

            builder.Entity<Message>(e =>
            {
                e.HasIndex(x => x.Time);
            });
        }
    }
}
