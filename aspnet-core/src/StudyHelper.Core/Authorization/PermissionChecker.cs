using Abp.Authorization;
using StudyHelper.Authorization.Roles;
using StudyHelper.Authorization.Users;

namespace StudyHelper.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
