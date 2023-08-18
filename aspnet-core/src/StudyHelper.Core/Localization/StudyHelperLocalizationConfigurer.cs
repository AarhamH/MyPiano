using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace StudyHelper.Localization
{
    public static class StudyHelperLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(StudyHelperConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(StudyHelperLocalizationConfigurer).GetAssembly(),
                        "StudyHelper.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
