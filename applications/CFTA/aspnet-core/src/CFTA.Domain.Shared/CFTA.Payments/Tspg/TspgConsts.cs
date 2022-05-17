namespace CFTA.Payments.Tspg;

public class TspgConsts
{
    /// <summary>
    /// 對應 FS.Tspg.PaymentService.PaymentMethod
    /// </summary>
    public const string GatewayName = "Tspg";

    /// <summary>
    /// UI 顯示名稱
    /// </summary>
    public const string GatewayDisplayName = "信用卡";

    /// <summary>
    /// UI 導至付款頁
    /// </summary>
    public const string PrePaymentUrl = "/e-shop/payment-service/tspg/pre-payment";

    /// <summary>
    /// UI 付款導回頁
    /// </summary>
    public const string PostPaymentUrl = "/e-shop/payment-service/tspg/post-payment";
}
