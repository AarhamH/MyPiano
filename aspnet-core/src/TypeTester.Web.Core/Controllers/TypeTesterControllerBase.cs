using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TypeTester.Controllers
{
    public abstract class TypeTesterControllerBase: AbpController
    {
        protected TypeTesterControllerBase()
        {
            LocalizationSourceName = TypeTesterConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
