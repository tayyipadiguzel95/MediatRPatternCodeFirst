using CodeFirst.Data.Entities;
using CodeFirst.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Data.Repositories.Products
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);
        IQueryable<Product> GetAll();
        Task<int> CreateAsync(CreateProductRequest request);
    }
}
