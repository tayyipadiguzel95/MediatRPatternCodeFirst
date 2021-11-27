using CodeFirst.Data.Entities;
using CodeFirst.Requests;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Data.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;
        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<int> CreateOrder(CreateOrderRequest request)
        {
            var order = new Order()
            {
                Amount = request.Amount,
                Tax = request.Tax,
                DeviceInfo = request.DeviceInfo
            };
            await _dataContext.Orders.AddAsync(order);
            await _dataContext.SaveChangesAsync();
            return order.Id;
        }

        public IQueryable<Order> GetAll()
        {
            return _dataContext.Orders;
        }

        public async Task<Order> GetById(int id)
        {
            return await _dataContext.Orders.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Order>> GetByDeviceAsync(string device)
        {
            return await GetAll().Where(a => a.DeviceInfo.Device.Equals(device)).ToListAsync();
        }
    }
}
