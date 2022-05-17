using System.Text.Json.Serialization;

namespace FS.Tspg.Dtos;

public class CallBackDto
{
    [JsonPropertyName("ver")]
    public string Version { get; set; }
    [JsonPropertyName("mid")]
    public string MerchantId { get; set; }
    [JsonPropertyName("tid")]
    public string TerminalId { get; set; }
    [JsonPropertyName("pay_type")]
    public PayType PayType { get; set; }
    [JsonPropertyName("tx_type")]
    public TransactionType TransactionType { get; set; }

    /// <summary>
    /// <para>回傳值，不知為何台新文件沒有提到此欄位</para>
    /// <para>實際測試出來，此欄位不論什麼情形皆為0</para>
    /// </summary>
    [JsonPropertyName("ret_value")]
    public int ReturnValue { get; set; }
    [JsonPropertyName("params")]
    public CallBackParameter Parameters { get; set; }
}

public class CallBackParameter
{
    [JsonPropertyName("ret_code")]
    public string ReturnCode { get; set; }

    [JsonPropertyName("ret_msg")]
    public string ReturnMessage { get; set; }

    /// <summary>
    /// 狀態訂單碼
    /// </summary>
    [JsonPropertyName("order_no")]
    public string OrderNo { get; set; }
    /// <summary>
    /// 授權碼
    /// </summary>
    [JsonPropertyName("auth_id_resp")]
    public string AuthIdResponse { get; set; }

    /// <summary>
    /// 調單號碼
    /// </summary>
    [JsonPropertyName("rrn")]
    public string Rrn { get; set; }

    /// <summary>
    /// 信用卡載具資訊
    /// </summary>
    [JsonPropertyName("carrierId2")]
    public string CarrierId2 { get; set; }

    /// <summary>
    /// 狀態訂單碼
    /// </summary>
    [JsonPropertyName("order_status")]
    public string OrderStatus { get; set; }

    /// <summary>
    /// 授權方式(SSL/3D)
    /// </summary>
    [JsonPropertyName("auth_type")]
    public string AuthType { get; set; }

    /// <summary>
    /// 幣別
    /// </summary>
    [JsonPropertyName("cur")]
    public string Currency { get; set; }

    /// <summary>
    /// 採購日期
    /// </summary>
    [JsonPropertyName("purchase_date")]
    public string PurchaseDate { get; set; }

    /// <summary>
    /// <para>交易金額，包含兩位小數</para>
    /// <para>如100代表1.00元</para>
    /// </summary>
    [JsonPropertyName("tx_amt")]
    public string TransactionAmount { get; set; }

    /// <summary>
    /// 請款金額
    /// </summary>
    [JsonPropertyName("settle_amt")]
    public string settle_amt { get; set; }


    /// <summary>
    /// <para>退貨金額，包含兩位小數</para>
    /// <para>如100代表1.00元</para>
    /// </summary>
    [JsonPropertyName("refund_trans_amt")]
    public string RefundTransAmount { get; set; }

    public bool IsValid => ReturnCode == "00";
}