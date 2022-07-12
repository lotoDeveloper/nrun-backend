using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Nrun.EntityFrameworkCore;
using Nrun.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Nrun.Web.Tests
{
    [DependsOn(
        typeof(NrunWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class NrunWebTestModule : AbpModule
    {
        public NrunWebTestModule(NrunEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NrunWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(NrunWebMvcModule).Assembly);
        }
    }
}