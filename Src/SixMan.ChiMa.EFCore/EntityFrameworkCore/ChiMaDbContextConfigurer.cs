using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Pomelo.EntityFrameworkCore.MySql;

namespace SixMan.ChiMa.EFCore
{
    public static class ChiMaDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ChiMaDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder
                //.UseLoggerFactory(MyLoggerFactory)
                .UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ChiMaDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection);
        }

        public static readonly LoggerFactory MyLoggerFactory
                    = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });
    }

}
