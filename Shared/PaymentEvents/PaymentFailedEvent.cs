using MassTransit;
using Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.PaymentEvents
{
    public class PaymentFailedEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; }
        public string Message { get; set; }
        public List<OrderItemMessage> OrderItems { get; set; }

        public PaymentFailedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
    }
}
