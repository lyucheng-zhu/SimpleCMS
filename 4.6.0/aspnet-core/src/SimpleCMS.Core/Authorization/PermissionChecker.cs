using Abp.Authorization;
using SimpleCMS.Authorization.Roles;
using SimpleCMS.Authorization.Users;

namespace SimpleCMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
