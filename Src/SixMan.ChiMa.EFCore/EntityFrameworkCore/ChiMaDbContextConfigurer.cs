using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SixMan.ChiMa.EFCore
{
    public static class ChiMaDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ChiMaDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ChiMaDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
