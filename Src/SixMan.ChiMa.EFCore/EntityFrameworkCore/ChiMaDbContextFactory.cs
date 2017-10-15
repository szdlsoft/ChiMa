using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SixMan.ChiMa.Domain;
using SixMan.ChiMa.Domain.Configuration;
using SixMan.ChiMa.Domain.Web;

namespace SixMan.ChiMa.EFCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ChiMaDbContextFactory : IDesignTimeDbContextFactory<ChiMaDbContext>
    {
        public ChiMaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ChiMaDbContext>();
            //var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            //ChiMaDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ChiMaConsts.ConnectionStringName));
            ChiMaDbContextConfigurer.Configure(builder, "Server=localhost; Database=ChiMaDb; Trusted_Connection=True;");

            return new ChiMaDbContext(builder.Options);
        }
    }
}
