using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using StudyHelper.Authorization.Roles;
using StudyHelper.Authorization.Users;
using StudyHelper.MultiTenancy;

namespace StudyHelper.EntityFrameworkCore
{
    public class StudyHelperDbContext : AbpZeroDbContext<Tenant, Role, User, StudyHelperDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public StudyHelperDbContext(DbContextOptions<StudyHelperDbContext> options)
            : base(options)
        {
        }
    }
}
