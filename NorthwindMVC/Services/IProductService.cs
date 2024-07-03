using NorthwindMVC.Services.DTOs;

namespace NorthwindMVC.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductsByIdAsync(int id);
        Task AddProductsAsync(ProductDto productDto);
        Task UpdateProductsAsync(ProductDto productDto);
        Task DeleteProductsAsync(int id);
    }
}
