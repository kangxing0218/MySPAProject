using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MySpaProject.Controllers
{
    public abstract class MySpaProjectControllerBase: AbpController
    {
        protected MySpaProjectControllerBase()
        {
            LocalizationSourceName = MySpaProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
