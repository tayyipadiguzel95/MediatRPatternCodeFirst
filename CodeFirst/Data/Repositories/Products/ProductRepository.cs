using CodeFirst.Data.Entities;
using CodeFirst.Data.Repositories.Products;
using CodeFirst.Requests;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IQueryable<Product> GetAll()
        {
            return _dataContext.Products;
        }

        public async Task<Product> GetById(int id)
        {
            return await _dataContext.Products.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<int> CreateAsync(CreateProductRequest request)
        {
            var product = new Product() { Name = request.Name };
            await _dataContext.Products.AddAsync(product);
            await _dataContext.SaveChangesAsync();
            return product.Id;
        }
    }
}
