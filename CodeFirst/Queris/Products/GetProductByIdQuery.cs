using CodeFirst.Data.Repositories.Products;
using CodeFirst.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.Queris
{
    public class GetProductByIdQuery : IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }   
        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            if (product == null)
                return new ProductResponse();
            return new ProductResponse()
            {
                Id = product.Id,
                Name = product.Name
            };
        }
    }


}
