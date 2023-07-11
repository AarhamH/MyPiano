using Abp.Authorization;
using TypeTester.Authorization.Roles;
using TypeTester.Authorization.Users;

namespace TypeTester.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
