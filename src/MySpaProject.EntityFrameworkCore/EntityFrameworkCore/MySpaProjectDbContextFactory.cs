using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MySpaProject.Configuration;
using MySpaProject.Web;

namespace MySpaProject.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MySpaProjectDbContextFactory : IDesignTimeDbContextFactory<MySpaProjectDbContext>
    {
        public MySpaProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MySpaProjectDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MySpaProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MySpaProjectConsts.ConnectionStringName));

            return new MySpaProjectDbContext(builder.Options);
        }
    }
}
