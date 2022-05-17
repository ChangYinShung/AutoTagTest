using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FS.EcPay.EcPayHttpClient
{
    public class EcPayHttpClientTest : EcPayDomainTestBase
    {
        private FS.EcPay.HttpClient.EcPayHttpClient ecPayHttpClient;

        private const string CreatePaymentTestResult = "<!DOCTYPE html><head><script type='text/javascript'>window.onload = function() {document.forms['form'].submit();}</script></head><body><form name='form' action='https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5' method='post'><input type='hidden' name='MerchantID' value='2000132' /><input type='hidden' name='MerchantTradeNo' value='ecpay20220401133030' /><input type='hidden' name='MerchantTradeDate' value='2022/04/01 13:30:30' /><input type='hidden' name='PaymentType' value='aio' /><input type='hidden' name='TotalAmount' value='1000' /><input type='hidden' name='TradeDesc' value='Test' /><input type='hidden' name='ItemName' value='Test Item 1#Test Item 2' /><input type='hidden' name='ReturnURL' value='https://www.ecpay.com.tw/receive.php/PaymentId' /><input type='hidden' name='ChoosePayment' value='Credit' /><input type='hidden' name='ClientBackURL' value='https://www.ecpay.com.tw/receive.php/PaymentId' /><input type='hidden' name='EncryptType' value='1' /><input type='hidden' name='NeedExtraPaidInfo' value='Y' /><input type='hidden' name='CheckMacValue' value='04C0A4ABA09DC2737F0CA5FA9C4971D181348CF32F3BB098573742C7C26E2EBB' /></form></body></html>";

        public EcPayHttpClientTest()
        {
            this.ecPayHttpClient = GetRequiredService<FS.EcPay.HttpClient.EcPayHttpClient>();
        }

        [Fact]
        public async Task Create_Payment_Test()
        {
            // Arrange
            var paymentDate = new DateTime(2022, 4, 1, 13, 30, 30);
            var request = new HttpClient.CreatePayment()
            {
                PaymentId = "PaymentId",
                PaymentNo = "ecpay" + paymentDate.ToString("yyyyMMddHHmmss"),
                PaymentDate = paymentDate,
                Amount = 1000,
                Description = "Test",
                ItemNames = new List<string>()
                {
                    "Test Item 1",
                    "Test Item 2"
                }
            };

            // Act
            var result = await this.ecPayHttpClient.CreatePaymentAsync(request);

            // Assert
            result.ShouldBe(CreatePaymentTestResult);
        }

        [Fact]
        public async Task Get_Payment_Test()
        {
            // Arrange
            var paymentDate = new DateTime(2022, 4, 1, 13, 30, 30);
            var paymentNo = "ecpay20220406101731";
            var request = new HttpClient.GetPayment()
            {
                PaymentNo = paymentNo,
                Date = paymentDate
            };

            // Act
            var result = await this.ecPayHttpClient.GetPaymentAsync(request);

            // Assert
            // 非本日建立的金流，在測試站查詢必定失敗。
            // 本詢日期不為現時點的 3 分內，查詢必定失敗。
            // 因此 result 僅驗證金流單號，其餘欄位不做驗證
            result.PaymentNo.ShouldBe(paymentNo);
        }

    }
}
