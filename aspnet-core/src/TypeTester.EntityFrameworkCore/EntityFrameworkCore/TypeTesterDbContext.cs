using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TypeTester.Authorization.Roles;
using TypeTester.Authorization.Users;
using TypeTester.MultiTenancy;

namespace TypeTester.EntityFrameworkCore
{
    public class TypeTesterDbContext : AbpZeroDbContext<Tenant, Role, User, TypeTesterDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TypeTesterDbContext(DbContextOptions<TypeTesterDbContext> options)
            : base(options)
        {
        }
    }
}
