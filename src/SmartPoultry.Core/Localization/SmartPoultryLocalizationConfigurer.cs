using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace SmartPoultry.Localization
{
    public static class SmartPoultryLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SmartPoultryConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SmartPoultryLocalizationConfigurer).GetAssembly(),
                        "SmartPoultry.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
