using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Nrun.Authorization.Roles;
using Nrun.Authorization.Users;
using Nrun.Domain;
using Nrun.MultiTenancy;

namespace Nrun.EntityFrameworkCore
{
    public class NrunDbContext : AbpZeroDbContext<Tenant, Role, User, NrunDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<Like> Likes { get; set; }

        public NrunDbContext(DbContextOptions<NrunDbContext> options)
            : base(options)
        {
        }
    }
}
