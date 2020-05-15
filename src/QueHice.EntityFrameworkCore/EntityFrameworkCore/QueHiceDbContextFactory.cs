using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using QueHice.Configuration;
using QueHice.Web;

namespace QueHice.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class QueHiceDbContextFactory : IDesignTimeDbContextFactory<QueHiceDbContext>
    {
        public QueHiceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<QueHiceDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            QueHiceDbContextConfigurer.Configure(builder, configuration.GetConnectionString(QueHiceConsts.ConnectionStringName));

            return new QueHiceDbContext(builder.Options);
        }
    }
}
