using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TypeTester.EntityFrameworkCore;
using TypeTester.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace TypeTester.Web.Tests
{
    [DependsOn(
        typeof(TypeTesterWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class TypeTesterWebTestModule : AbpModule
    {
        public TypeTesterWebTestModule(TypeTesterEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TypeTesterWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TypeTesterWebMvcModule).Assembly);
        }
    }
}