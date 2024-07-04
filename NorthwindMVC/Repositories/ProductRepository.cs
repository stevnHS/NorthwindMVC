using Microsoft.EntityFrameworkCore;
using NorthwindMVC.Models;

namespace NorthwindMVC.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindContext _context;
        public ProductRepository(NorthwindContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletedProduct = await _context.Products.FindAsync(id);
            if (deletedProduct == null) return;
            // 如果找不到就不刪除
            _context.Products.Remove(deletedProduct);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            // 找到特定ID的資料，若找不到則回傳空的Product物件
            var currentProduct = await _context.Products.FindAsync(id);
            if (currentProduct == null) return new Product();
            return currentProduct;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }


}
