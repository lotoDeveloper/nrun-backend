using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Nrun.Controllers
{
    public abstract class NrunControllerBase: AbpController
    {
        protected NrunControllerBase()
        {
            LocalizationSourceName = NrunConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
