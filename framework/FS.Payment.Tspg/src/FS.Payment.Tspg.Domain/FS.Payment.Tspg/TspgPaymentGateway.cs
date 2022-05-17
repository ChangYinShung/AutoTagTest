using System;
using System.Collections.Generic;
using Volo.Abp.DependencyInjection;
using Volo.Payment.Gateways;
using Volo.Payment.Requests;

namespace FS.Payment.Tspg;

public class TspgPaymentGateway : IPaymentGateway, ITransientDependency
{
    public bool IsValid(PaymentRequest paymentRequest, Dictionary<string, object> properties)
    {
        return true;
        //var sessionId = properties["SessionId"]?.ToString();
        //if (sessionId.IsNullOrWhiteSpace())
        //{
        //    throw new Exception("Empty SessionId.");
        //}

        //var sessionService = new SessionService();
        //var session = sessionService.Get(sessionId);

        //if (!session.PaymentStatus.Equals("paid", StringComparison.InvariantCulture))
        //{
        //    throw new Exception("Session not paid.");
        //}

        //return session.Metadata["PaymentRequestId"] == paymentRequest.Id.ToString();
    }
}
