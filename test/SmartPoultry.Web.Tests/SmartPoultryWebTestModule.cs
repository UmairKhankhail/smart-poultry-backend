using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SmartPoultry.EntityFrameworkCore;
using SmartPoultry.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace SmartPoultry.Web.Tests
{
    [DependsOn(
        typeof(SmartPoultryWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SmartPoultryWebTestModule : AbpModule
    {
        public SmartPoultryWebTestModule(SmartPoultryEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SmartPoultryWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SmartPoultryWebMvcModule).Assembly);
        }
    }
}