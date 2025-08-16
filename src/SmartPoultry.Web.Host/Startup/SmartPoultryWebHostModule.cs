using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SmartPoultry.Configuration;
using SmartPoultry.EntityFrameworkCore;

namespace SmartPoultry.Web.Host.Startup
{
    [DependsOn(
       typeof(SmartPoultryWebCoreModule),
       typeof(SmartPoultryEntityFrameworkModule)
        )]
    public class SmartPoultryWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SmartPoultryWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }
        public override void PreInitialize()
        {
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SmartPoultryWebHostModule).GetAssembly());
        }

    }
}
