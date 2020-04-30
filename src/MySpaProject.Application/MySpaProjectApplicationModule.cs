using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MySpaProject.Authorization;

namespace MySpaProject
{
    [DependsOn(
        typeof(MySpaProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MySpaProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MySpaProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MySpaProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
