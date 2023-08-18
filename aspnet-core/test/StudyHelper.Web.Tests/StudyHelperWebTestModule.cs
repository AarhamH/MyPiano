using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using StudyHelper.EntityFrameworkCore;
using StudyHelper.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace StudyHelper.Web.Tests
{
    [DependsOn(
        typeof(StudyHelperWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class StudyHelperWebTestModule : AbpModule
    {
        public StudyHelperWebTestModule(StudyHelperEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(StudyHelperWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(StudyHelperWebMvcModule).Assembly);
        }
    }
}