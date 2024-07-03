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
        public Task AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
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
