using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.UnifyTheme.MongoDB
{
    public static class UnifyThemeMongoDbContextExtensions
    {
        public static void ConfigureUnifyTheme(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new UnifyThemeMongoModelBuilderConfigurationOptions(
                UnifyThemeDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}