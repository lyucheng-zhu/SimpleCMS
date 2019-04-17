using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SimpleCMS.Authorization;

namespace SimpleCMS
{
    [DependsOn(
        typeof(SimpleCMSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SimpleCMSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SimpleCMSAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SimpleCMSApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
