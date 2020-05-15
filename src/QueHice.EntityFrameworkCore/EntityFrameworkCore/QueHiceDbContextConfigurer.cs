using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace QueHice.EntityFrameworkCore
{
    public static class QueHiceDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<QueHiceDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<QueHiceDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
