namespace FS.Abp.EmailingManagement;

public static class EmailingManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "Abp";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "EmailingManagement";
}
