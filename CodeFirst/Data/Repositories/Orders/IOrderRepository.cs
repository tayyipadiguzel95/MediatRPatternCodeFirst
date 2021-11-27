using CodeFirst.Data.Entities;
using CodeFirst.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Data.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<Order> GetById(int id);
        IQueryable<Order> GetAll();
        Task<int> CreateOrder(CreateOrderRequest request);
        Task<List<Order>> GetByDeviceAsync(string device);
    }
}
