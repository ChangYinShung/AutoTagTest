namespace FS.EcPay;

public static class EcPayDbProperties
{
    public static string DbTablePrefix { get; set; } = "EcPay";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "EcPay";
}
