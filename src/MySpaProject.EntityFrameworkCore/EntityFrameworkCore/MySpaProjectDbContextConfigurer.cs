using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MySpaProject.EntityFrameworkCore
{
    public static class MySpaProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MySpaProjectDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MySpaProjectDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
