using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace SmartPoultry.Controllers
{
    public abstract class SmartPoultryControllerBase: AbpController
    {
        protected SmartPoultryControllerBase()
        {
            LocalizationSourceName = SmartPoultryConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
