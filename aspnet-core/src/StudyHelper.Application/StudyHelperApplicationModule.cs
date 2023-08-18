using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using StudyHelper.Authorization;

namespace StudyHelper
{
    [DependsOn(
        typeof(StudyHelperCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class StudyHelperApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<StudyHelperAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(StudyHelperApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
