using NorthwindMVC.Models;
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


        public async Task AddProductsAsync(ProductDto productDto)
        {
            Product newProduct = new Product()
            {
                ProductName = productDto.Name,
                UnitPrice = productDto.UnitPrice
            };

            await _productRepository.AddAsync(newProduct);
        }

        public async Task DeleteProductsAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
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
