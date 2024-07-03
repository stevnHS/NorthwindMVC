using NorthwindMVC.Repositories;
using NorthwindMVC.Services.DTOs;

namespace NorthwindMVC.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public Task AddProductsAsync(ProductDto ProductDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.ProductId,
                Name = p.ProductName,
                UnitPrice = p.UnitPrice ?? 0,
            });
        }

        public Task<ProductDto> GetProductsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductsAsync(ProductDto ProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
