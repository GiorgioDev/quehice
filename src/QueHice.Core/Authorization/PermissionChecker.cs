using Abp.Authorization;
using QueHice.Authorization.Roles;
using QueHice.Authorization.Users;

namespace QueHice.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
