using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace QueHice.Localization
{
    public static class QueHiceLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(QueHiceConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(QueHiceLocalizationConfigurer).GetAssembly(),
                        "QueHice.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
