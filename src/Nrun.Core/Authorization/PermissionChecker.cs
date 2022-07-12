using Abp.Authorization;
using Nrun.Authorization.Roles;
using Nrun.Authorization.Users;

namespace Nrun.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
