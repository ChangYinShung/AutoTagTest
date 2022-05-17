namespace FS.Abp.Emailing;

public static class AbpDbProperties
{
    public static string DbTablePrefix { get; set; } = "Abp";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "EmailingManagement";
}
