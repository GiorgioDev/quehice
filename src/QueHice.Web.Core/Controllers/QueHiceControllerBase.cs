using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace QueHice.Controllers
{
    public abstract class QueHiceControllerBase: AbpController
    {
        protected QueHiceControllerBase()
        {
            LocalizationSourceName = QueHiceConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
