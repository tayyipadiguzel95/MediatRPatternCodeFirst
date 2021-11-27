using CodeFirst.Data.Repositories.Products;
using CodeFirst.Requests;
using CodeFirst.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.Commands
{
    public class CreateProductCommand : IRequest<ProductResponse>
    {
        public CreateProductRequest CreateProduct { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productId = await _productRepository.CreateAsync(request.CreateProduct);
            if (productId == 0)
                return default;
            return new ProductResponse() { Id = productId };
        }
    }
}
