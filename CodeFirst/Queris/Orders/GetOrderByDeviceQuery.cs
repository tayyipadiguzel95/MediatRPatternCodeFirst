using CodeFirst.Data.Repositories.Orders;
using CodeFirst.Responses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.Queris.Orders
{
    public class GetOrderByDeviceQuery : IRequest<List<OrderResponse>>
    {
        public string Device { get; set; }
    }
    public class GetOrderByDeviceQueryHandler : IRequestHandler<GetOrderByDeviceQuery, List<OrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderByDeviceQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<OrderResponse>> Handle(GetOrderByDeviceQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Device))
            {
                var orders = await _orderRepository.GetByDeviceAsync(request.Device);
                if (!orders.Any())
                    return null;
                return orders.Select(a => new OrderResponse() { Id = a.Id }).ToList();
            }
            return null;
        }
    }
}
