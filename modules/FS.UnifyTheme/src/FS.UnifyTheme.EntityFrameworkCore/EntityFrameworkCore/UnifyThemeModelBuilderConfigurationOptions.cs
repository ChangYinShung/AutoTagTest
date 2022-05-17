using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace FS.UnifyTheme.EntityFrameworkCore
{
    public class UnifyThemeModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public UnifyThemeModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}