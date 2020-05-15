using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QueHice.Authorization;

namespace QueHice
{
    [DependsOn(
        typeof(QueHiceCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class QueHiceApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<QueHiceAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(QueHiceApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
