using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SimpleCMS.Configuration;
using SimpleCMS.Web;

namespace SimpleCMS.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SimpleCMSDbContextFactory : IDesignTimeDbContextFactory<SimpleCMSDbContext>
    {
        public SimpleCMSDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SimpleCMSDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SimpleCMSDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SimpleCMSConsts.ConnectionStringName));

            return new SimpleCMSDbContext(builder.Options);
        }
    }
}
