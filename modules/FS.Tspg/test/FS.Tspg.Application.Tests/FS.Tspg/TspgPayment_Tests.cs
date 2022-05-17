using System.Threading.Tasks;
using Shouldly;
using Xunit;
using FS.Tspg;
using FS.Tspg.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using FS.Tspg.Core.options;
using FS.Tspg.Core;
using FS.Tspg.HttpClient.Dtos;

namespace FS.Tspg;

public class TspgPayment_Tests : TspgApplicationTestBase
{
    private readonly TspgHttpClient client;
    public TspgPayment_Tests()
    {
        var option=Options.Create(new HttpClientOptions()
        {
            MerchantId = "999812770060250",
            TerminalId = "T0000000",
            BaseUrl = "https://tspg-t.taishinbank.com.tw/tspgapi/restapi/"
        });
        var logger= GetRequiredService<ILogger<TspgHttpClient>>();

        client = new TspgHttpClient(option, logger);
    }

    [Fact]
    public async Task GetPaymentAsync()
    {
        var input = new GetPaymentRequest()
        {
            PaymentNo = "2022030299002"
        };

        var result = await client.GetPaymentAsync(input);

        Assert.Equal("00", result.ReturnCode);
        Assert.Equal("NTD", result.Currency);
        Assert.Equal(1200, result.TransactionAmount);

    }

    [Fact]
    public async Task CreatePaymentAsync()
    {
        var PaymentNo = DateTime.Now.ToString("99yyyyMMddhhmmss");
        var input = new CreatePaymentRequest()
        {
            PaymentNo = PaymentNo,
            Amount = 120,
            Currency = "NTD",
            PostBackUrl = "http://www.google.com.tw",
            WehHookUrl= "http://www.google.com.tw"
        };

        var result = await client.CreatePaymentAsync(input);

        //Url是否正確
        Assert.True(Uri.TryCreate(result.PaymentUrl, UriKind.Absolute, out _));
    }

    [Fact]
    public async Task CancelPayment()
    {
        //沒辦法重複退，僅驗證可連通
        //TODO:buisinese exception
        await Assert.ThrowsAsync<Exception>(() => client.CancelPaymentAsync(
            new CancelPaymentRequest()
            {
                PaymentNo = "2022030299002"
            })
        );
    }

    [Fact]
    public async Task RefundPayment()
    {
        //沒辦法重複退，僅驗證可連通
        //TODO:buisinese exception
        await Assert.ThrowsAsync<Exception>(() => client.RefundPaymentAsync(
            new RefundPaymentRequest()
            {
                PaymentNo = "2022030299002",
                RefundAmount = 120
            })
        );
    }
}
