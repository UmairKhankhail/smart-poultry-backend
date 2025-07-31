using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SmartPoultry.Authorization;

namespace SmartPoultry
{
    [DependsOn(
        typeof(SmartPoultryCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SmartPoultryApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SmartPoultryAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SmartPoultryApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
