using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TypeTester.EntityFrameworkCore
{
    public static class TypeTesterDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TypeTesterDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TypeTesterDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
