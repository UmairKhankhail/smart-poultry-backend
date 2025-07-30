using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SmartPoultry.Configuration;
using SmartPoultry.EntityFrameworkCore;
using SmartPoultry.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace SmartPoultry.Migrator;

[DependsOn(typeof(SmartPoultryEntityFrameworkModule))]
public class SmartPoultryMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public SmartPoultryMigratorModule(SmartPoultryEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(SmartPoultryMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            SmartPoultryConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(SmartPoultryMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
