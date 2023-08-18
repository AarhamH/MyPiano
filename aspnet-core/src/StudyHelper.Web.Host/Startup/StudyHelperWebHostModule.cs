using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using StudyHelper.Configuration;

namespace StudyHelper.Web.Host.Startup
{
    [DependsOn(
       typeof(StudyHelperWebCoreModule))]
    public class StudyHelperWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public StudyHelperWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(StudyHelperWebHostModule).GetAssembly());
        }
    }
}
