using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace StudyHelper.Controllers
{
    public abstract class StudyHelperControllerBase: AbpController
    {
        protected StudyHelperControllerBase()
        {
            LocalizationSourceName = StudyHelperConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
