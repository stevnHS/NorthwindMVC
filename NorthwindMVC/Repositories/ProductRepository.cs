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

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }


}
