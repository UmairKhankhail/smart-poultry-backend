using Abp.Authorization;
using SmartPoultry.Authorization.Roles;
using SmartPoultry.Authorization.Users;

namespace SmartPoultry.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
