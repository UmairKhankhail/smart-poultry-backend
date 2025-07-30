using Abp.Modules;
using Abp.Reflection.Extensions;
using SmartPoultry.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace SmartPoultry.Web.Host.Startup
{
    [DependsOn(
       typeof(SmartPoultryWebCoreModule))]
    public class SmartPoultryWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SmartPoultryWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SmartPoultryWebHostModule).GetAssembly());
        }
    }
}
