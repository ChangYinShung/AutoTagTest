namespace FS.Tspg
{
    public enum PayType
    {
        信用卡 = 1,
        銀聯卡 = 2
    }

    public enum TransactionType
    {
        授權 = 1,
        請款 = 3,
        取消請款 = 4,
        退貨 = 5,
        取消退貨 = 6,
        查詢 = 7,
        取消授權 = 8
    }
}