using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace SixMan.ChiMa.Domain.Localization
{
    public static class ChiMaLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Languages.Add(new LanguageInfo("en","English", "famfamfam-flags gb"));
            localizationConfiguration.Languages.Add(new LanguageInfo("zh-CN", "China", "famfamfam-flags cn", true));

            //var _assembly = typeof(ChiMaLocalizationConfigurer).GetAssembly();
            //var _rootNamespace = "SixMan.ChiMa.Domain.Localization.SourceFiles";
            //var resourceNames = _assembly.GetManifestResourceNames();
            //foreach (var resourceName in resourceNames)
            //{
            //    if (resourceName.StartsWith(_rootNamespace))
            //    {

            //    }
            //}

            //var provider = new XmlEmbeddedFileLocalizationDictionaryProvider(
            //            _assembly,
            //            _rootNamespace
            //        );
            //provider.Initialize(ChiMaConsts.LocalizationSourceName);

            //var source = new DictionaryBasedLocalizationSource(ChiMaConsts.LocalizationSourceName,
            //        provider
            //    );

            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ChiMaConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ChiMaLocalizationConfigurer).GetAssembly(),
                        "SixMan.ChiMa.Domain.Localization.SourceFiles"
                    )
                )
            );

            //localizationConfiguration.Sources.Add(
            //    source
            //);
        }
    }
}
