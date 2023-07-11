using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TypeTester.Authorization;

namespace TypeTester
{
    [DependsOn(
        typeof(TypeTesterCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TypeTesterApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TypeTesterAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TypeTesterApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
