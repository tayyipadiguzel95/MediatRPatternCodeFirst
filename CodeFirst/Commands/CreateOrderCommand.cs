using CodeFirst.Data.Repositories.Orders;
using CodeFirst.Requests;
using CodeFirst.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.Commands
{
    public class CreateOrderCommand : IRequest<OrderResponse>
    {
        public CreateOrderRequest Request { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderResponse> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            if (command.Request != null)
            {
                var orderId = await _orderRepository.CreateOrder(new CreateOrderRequest { Amount = command.Request.Amount, Tax = command.Request.Tax, DeviceInfo = command.Request.DeviceInfo });
                if (orderId != default)
                    return new OrderResponse() { Id = orderId };
            }
            return new OrderResponse();
        }
    }
}
