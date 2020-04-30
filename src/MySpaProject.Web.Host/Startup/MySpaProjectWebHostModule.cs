using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MySpaProject.Configuration;

namespace MySpaProject.Web.Host.Startup
{
    [DependsOn(
       typeof(MySpaProjectWebCoreModule))]
    public class MySpaProjectWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MySpaProjectWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MySpaProjectWebHostModule).GetAssembly());
        }
    }
}
