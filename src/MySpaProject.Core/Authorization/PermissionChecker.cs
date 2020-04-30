using Abp.Authorization;
using MySpaProject.Authorization.Roles;
using MySpaProject.Authorization.Users;

namespace MySpaProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
