using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace FS.UnifyTheme.MongoDB
{
    public class UnifyThemeMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public UnifyThemeMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}