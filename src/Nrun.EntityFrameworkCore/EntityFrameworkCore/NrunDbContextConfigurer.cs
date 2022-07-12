using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Nrun.EntityFrameworkCore
{
    public static class NrunDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<NrunDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<NrunDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
