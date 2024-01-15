using MassTransit;
using Shared.PaymentEvents;
using Shared.Settings;

namespace Payment.API.Consumers
{
    public class PaymentStartedEventConsumer(ISendEndpointProvider sendEndpointProvider) : IConsumer<PaymentStartedEvent>
    {
        public async Task Consume(ConsumeContext<PaymentStartedEvent> context)
        {
            var endpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettings.StateMachineQueue}"));

            if(false)
            {
                // Payment process
                PaymentCompletedEvent paymentCompletedEvent = new(context.Message.CorrelationId);
                await endpoint.Send(paymentCompletedEvent);   
            }
            else
            {
                PaymentFailedEvent paymentFailedEvent = new(context.Message.CorrelationId)
                {
                    Message = "Payment Failed...",
                    OrderItems = context.Message.OrderItems
                };
                await endpoint.Send(paymentFailedEvent);
            }
        }
    }
}
