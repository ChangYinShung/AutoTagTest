namespace FS.Entity;

public static class EntityDbProperties
{
    public static string DbTablePrefix { get; set; } = "Entity";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "EntityManagement";
}
