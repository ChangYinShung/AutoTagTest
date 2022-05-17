using EasyAbp.EShop.Orders.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Emailing;
using Volo.Abp.TextTemplating;
using Volo.Abp.Uow;

namespace CFTA.Emailing
{
    public class OrderPayEtoHandler :
        Volo.Abp.Domain.Services.DomainService,
        Volo.Abp.EventBus.Distributed.IDistributedEventHandler<OrderPaidEto>,
        Volo.Abp.DependencyInjection.ITransientDependency
    {
        private readonly IEmailSender _emailSender;
        private readonly ITemplateRenderer _templateRenderer;

        private readonly EmailingAppService _emailingAppService;
        public OrderPayEtoHandler(IEmailSender emailSender,
            ITemplateRenderer templateRenderer,
            EmailingAppService emailingAppService)
        {
            _emailSender = emailSender;
            _templateRenderer = templateRenderer;
            _emailingAppService = emailingAppService;
        }
        [UnitOfWork]
        public virtual async Task HandleEventAsync(OrderPaidEto eventData)//remerber to add virtual
        {

            var data = eventData.Order.ExtraProperties["email"];
            await _emailingAppService.GetOrderPayMailAsync(data.ToString(), "臺南市臺灣鋼鐵俱樂部");
        }
    }
}
