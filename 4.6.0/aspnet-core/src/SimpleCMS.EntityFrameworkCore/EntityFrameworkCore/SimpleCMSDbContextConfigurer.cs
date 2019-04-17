using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SimpleCMS.EntityFrameworkCore
{
    public static class SimpleCMSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SimpleCMSDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SimpleCMSDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
