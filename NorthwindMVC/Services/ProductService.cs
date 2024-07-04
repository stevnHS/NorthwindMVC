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
            // 從 Repos 取道 Products表中所有資料
            IEnumerable<Product> products = await _productRepository.GetAllAsync();

            // 傳回 ProductDto 
            return products.Select(p => new ProductDto
            {
                Id = p.ProductId,
                Name = p.ProductName,
                UnitPrice = p.UnitPrice ?? 0,
                Status = p.Status switch
                {
                    1 => "上架中",
                    2 => "已下架",
                    3 => "已售出",
                    _ => throw new ArgumentException("Product 的 Status 的資料沒有在目前的 pattern 中")
                },
            });
        }

        public async Task<ProductDto> GetProductsByIdAsync(int id)
        {
            // 從 Repos 取 Products表中當筆資料
            Product? product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new Exception("Product 找不到");

            ProductDto currentProduct = new ProductDto()
            {
                Id = product.ProductId,
                Name = product.ProductName,
                UnitPrice = product.UnitPrice ?? 0,
            };

            // 回傳 ProductDto: 當筆的商品資訊
            return currentProduct;
        }

        public async Task UpdateProductsAsync(ProductDto ProductDto)
        {
            // 轉成 Product Entity，再呼叫Repos進行修改
            Product product = new Product()
            {
                ProductId = ProductDto.Id,
                ProductName = ProductDto.Name,
                UnitPrice = ProductDto.UnitPrice,
            };

            await _productRepository.UpdateAsync(product);
        }
    }
}
