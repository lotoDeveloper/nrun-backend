using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Nrun.Authorization;

namespace Nrun
{
    [DependsOn(
        typeof(NrunCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class NrunApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<NrunAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(NrunApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
