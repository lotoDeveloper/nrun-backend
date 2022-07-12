using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Nrun.Configuration;
using Nrun.Web;

namespace Nrun.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class NrunDbContextFactory : IDesignTimeDbContextFactory<NrunDbContext>
    {
        public NrunDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NrunDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            NrunDbContextConfigurer.Configure(builder, configuration.GetConnectionString(NrunConsts.ConnectionStringName));

            return new NrunDbContext(builder.Options);
        }
    }
}
