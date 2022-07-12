using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Nrun.Authorization.Roles;
using Nrun.Authorization.Users;
using Nrun.MultiTenancy;

namespace Nrun.EntityFrameworkCore
{
    public class NrunDbContext : AbpZeroDbContext<Tenant, Role, User, NrunDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public NrunDbContext(DbContextOptions<NrunDbContext> options)
            : base(options)
        {
        }
    }
}
