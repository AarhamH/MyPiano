using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace StudyHelper.EntityFrameworkCore
{
    public static class StudyHelperDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<StudyHelperDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<StudyHelperDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
