using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TypeTester.Configuration;

namespace TypeTester.Web.Host.Startup
{
    [DependsOn(
       typeof(TypeTesterWebCoreModule))]
    public class TypeTesterWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TypeTesterWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TypeTesterWebHostModule).GetAssembly());
        }
    }
}
